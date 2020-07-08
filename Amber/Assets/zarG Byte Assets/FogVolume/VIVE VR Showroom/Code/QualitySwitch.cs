using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

[RequireComponent( typeof( Interactable ) )]
public class QualitySwitch : MonoBehaviour
{
    public 	GameObject 	OptimalConfig;
    public 	GameObject 	ComplexConfig;
    		bool 		OptimalActive = true, ComplexActive = false;
    public 	GameObject 	Button;
    public 	Color 		OptimalColor = Color.green, ComplexColor = Color.red;

    void SetButtonColor()
    {
		Button.GetComponent<Renderer>().material.SetColor("_EmissionColor", ((OptimalActive)?OptimalColor : ComplexColor) * 3);
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
    //	Switch ();
    //}
  }

  public void Switch()
    {
        OptimalActive = !OptimalActive;
        ComplexActive = !ComplexActive;
        OptimalConfig.SetActive(OptimalActive);
        ComplexConfig.SetActive(ComplexActive);
        SetButtonColor();
    }
}