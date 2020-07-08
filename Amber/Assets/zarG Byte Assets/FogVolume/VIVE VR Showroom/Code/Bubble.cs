using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

[RequireComponent(typeof(Interactable))]
public class Bubble : MonoBehaviour
{
  [Header("Animation")]
  [Range(0, 10)]
  public float Amplitude = .1f;
  [Range(0, 1)]
  public float Speed = .1f;
  float Y = 0;
  float accum = 0;
  float initialYpos;
  [Header("Controller")]
  public float InteractionRadius = .3f;
  [SerializeField]

  Vector3 Destination = Vector3.zero;
  Vector3 LastPosition = Vector3.zero;
  Vector3 Idle;
  [Range(10, 30)]
  public float RelocationSmooth = 10;
  [Range(0, 0.2f)]
  public float BubbleDestinationOffset = 0.0567f;
  GameObject BubblePoint;
  bool grabbing = false;

  void OnEnable()
  {
    BubblePoint = new GameObject();
    BubblePoint.hideFlags = HideFlags.DontSave | HideFlags.HideInHierarchy;
    BubblePoint.name = "BubblePoint";
    BubblePoint.transform.position = Vector3.zero;
    BubblePoint.transform.rotation = Quaternion.Euler(0, 0, 0);
    Destination = transform.position;
    LastPosition = Destination;
    Idle = LastPosition;
  }

  private Vector3 oldPosition;
  private Quaternion oldRotation;

  private void HandHoverUpdate(Hand hand)
  {
    // !!! SteamVR 2 problem
    ////If we are actively holding the object
    //if (hand.GetStandardInteractionButton () || ((hand.controller != null) && hand.controller.GetPress (Valve.VR.EVRButtonId.k_EButton_Grip)))
    //{
    //	OnGrabbed (hand);
    //	// Call this to continue receiving HandHoverUpdate messages, and prevent the hand from hovering over anything else
    //	hand.HoverLock (GetComponent<Interactable> ());
    //}
    //else
    //{
    //	OnReleased (hand);
    //	// Call this to undo HoverLock
    //	hand.HoverUnlock( GetComponent<Interactable>() );
    //}
  }

  //-------------------------------------------------
  // Called when this GameObject becomes attached to the hand
  //-------------------------------------------------
  private void OnGrabbed(Hand hand)
  {
    grabbing = true;
    BubblePoint.transform.parent = hand.gameObject.transform;
    BubblePoint.transform.localPosition = Vector3.zero;
    BubblePoint.transform.localRotation = Quaternion.Euler(0, 0, 0);
    BubblePoint.transform.localPosition = Vector3.forward * BubbleDestinationOffset;
    LastPosition = BubblePoint.transform.position;
    Destination = Vector3.Lerp(Destination, BubblePoint.transform.position, 1.0f / RelocationSmooth);
    gameObject.transform.position = new Vector3(Destination.x, Destination.y, Destination.z);
  }

  //-------------------------------------------------
  // Called when this GameObject is detached from the hand
  //-------------------------------------------------
  private void OnReleased(Hand hand)
  {
    grabbing = false;
  }

  void Animation()
  {
    if (!grabbing)
    {
      accum += Time.deltaTime;
      Y = Mathf.Sin(accum * Speed) * Amplitude / 100;
      Idle = new Vector3(LastPosition.x, LastPosition.y + Y, LastPosition.z);
      Destination = Vector3.Lerp(Destination, Idle, 1.0f / RelocationSmooth);
      gameObject.transform.position = Destination;
    }
  }

  void FixedUpdate()
  {
    Animation();
  }
}
