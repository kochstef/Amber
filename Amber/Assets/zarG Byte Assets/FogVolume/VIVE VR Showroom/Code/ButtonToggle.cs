using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using UnityEngine.Events;

[RequireComponent( typeof( Interactable ) )]

public class ButtonToggle : MonoBehaviour
{
    public	GameObject 	Object;
    bool 	Active 						= true;
    public 	GameObject 	Button;
    public 	Color 		ActiveColor 	= Color.green, 
						NonActiveColor 	= Color.red;

    void SetButtonColor()
    {
		Button.GetComponent<Renderer>().material.SetColor("_EmissionColor", ((Active)?ActiveColor : NonActiveColor) * 3);
    }

    void OnEnable()
    {
        SetButtonColor();
    }

	private void HandHoverUpdate( Hand hand )
	{
    // !!! SteamVR 2 problem
		//if ( hand.GetStandardInteractionButtonDown() || ( ( hand.controller != null ) && hand.controller.GetPressDown( Valve.VR.EVRButtonId.k_EButton_Grip ) ) )
		//{
		//	Toggle ();
		//}
	}

	//to be called throught he event system
	public void Toggle()
    {       
		Active = !Active;
		Object.SetActive(Active);
		SetButtonColor();
    }
}