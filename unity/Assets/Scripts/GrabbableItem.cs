using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using OculusSampleFramework;
public class GrabbableItem : OVRGrabbable
{
    //The hand pose when grabing the item
    public List<OVRBone> _bonesLeft = null;
    public List<OVRBone> _bonesRight = null;
    //The offset of the hand compared to the hand
    public string _handPoseLeft = "";
    public string _handPoseRight = "";

    public Vector3 _positionLeft;
    public Quaternion _rotationLeft;
    public Vector3 _positionRight;
    public Quaternion _rotationRight;
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
    
        if (_handPoseLeft == "" || _handPoseRight == "")
        {
            Debug.Log("You forgot to set up the hand pose for grabbing the item");
        }
        else
        {
            _bonesLeft = Serializer.deserializeHand(JsonUtility.FromJson<SerializedHand>(_handPoseLeft));
            _bonesRight = Serializer.deserializeHand(JsonUtility.FromJson<SerializedHand>(_handPoseRight));
        }
    }
}
