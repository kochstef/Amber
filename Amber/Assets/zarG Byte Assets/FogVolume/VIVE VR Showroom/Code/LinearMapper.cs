//======= Copyright (c) Rod Lopez / David Miranda, All rights reserved. ===============
// 
//=============================================================================

using UnityEngine;
using System.Collections;
using Valve.VR.InteractionSystem;
using UnityEngine.Events;

[System.Serializable]
public class MapperEventFloat 	: UnityEvent<float>	{};
[System.Serializable]
public class MapperEventInt 	: UnityEvent<int>	{};

public class LinearMapper : LinearMapping
{
	public 	float 				minRange 			= 0;
	public 	float 				maxRange 			= 1;
	public 	MapperEventFloat 	onFloatValueChanged;
	public 	MapperEventInt 		onIntValueChanged;
	public int 				oldMappedInt		= 0;

	public void OnEnable()
	{
		ScaleAndInvoke ();
	}
	//NOTE: Can be used to invert the mapping by swapping min and max with minscale maxscale:
	//This, other than rounding issues, will always be true
	// float input = 3;
	// double thin = Scale(input, 0,15, 0, 130);
	// Console.WriteLine(Scale(thin, 0,130, 0, 15) == input);
	static private float Scale(float value , float min, float max, float minScale, float maxScale)
	{
		float scaled = minScale + (float)((value - min)/(max-min)) * (maxScale - minScale);
		return scaled;
	}

	private void ScaleAndInvoke()
	{
		float mappedValue = Scale(base.value, 0, 1, minRange, maxRange);
		//release float event
		onFloatValueChanged.Invoke(mappedValue);
		int newMappedInt = Mathf.RoundToInt (mappedValue);
		//release int event
		if (newMappedInt != oldMappedInt)
		{
			onIntValueChanged.Invoke (newMappedInt);
			oldMappedInt = newMappedInt;
		}
	}

	#if !BASE_CLASS_CAN_LET_US_OVERRIDE
	private float localVal = float.NaN;
	void Update()
	{
		if (base.value != localVal)
		{
			ScaleAndInvoke ();
			localVal = base.value;
		}
	}
	#else
	public override float value
	{
		get
		{
			return base.value;
		}
		set
		{
			//Using this as Valve uses "value" for variable name, which doesn't play nice with setters/getters 	
			ScaleAndInvoke();
			Base.value = value;
		}
	}
	#endif
}
