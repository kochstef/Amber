using UnityEngine;
using Valve.VR.InteractionSystem;

public class SliderText : MonoBehaviour
{
    public TextMesh go;
	private string Precision = "0.00";
    public string DisplayText = "Value: ";
	private float lastFloat = float.NaN;

	public void SetValue(int val)
	{
		go.text = DisplayText + val.ToString ();
	}

	public void SetValue(float val)
	{
		lastFloat = val;
		go.text = DisplayText + val.ToString (Precision);
	}
}