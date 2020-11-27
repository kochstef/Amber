using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using OculusSampleFramework;
public class GrabbableItem : OVRGrabbable
{
    //The hand pose when grabing the item
    
    public List<OVRBone> _bones = null;

    public bool setupLeftDone = false;
    //The offset of the hand compared to the hand
    public string handPose = "";
    public Vector3 position;
    public Quaternion rotation;
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
    
        if (handPose == "")
        {
            Debug.Log("You forgot to set up the hand pose for grabbing the item");
        }
        else
        {
            _bones = Serializer.deserializeHand(JsonUtility.FromJson<SerializedHand>(handPose));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_bones != null) setupLeftDone = true;
        else setupLeftDone = false;
    }
}
