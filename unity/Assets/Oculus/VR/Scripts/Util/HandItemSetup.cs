using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandItemSetup : OVRGrabber
{
    private OVRHand m_hand;
    private float pinchThreshhold = 0.5f;

    private OVRSkeleton _ovrSkeleton;

    public GameObject itemToSetUP;

    private GrabbableItem _grabbableItem;

   
    
    
    private string handPose = "";
    
    private List<OVRBone> _bones;

    private Transform _transform;
   // public List<OVRBone> _bones;
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        m_hand = GetComponent<OVRHand>();
        _ovrSkeleton = GetComponent<OVRSkeleton>();
        _grabbableItem = itemToSetUP.GetComponent<GrabbableItem>();
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();    
        checkForSetupOfHandPose();
     
    }

    

    void checkForSetupOfHandPose()
    {
        
        //this code to get the pose of the hand and the offset of
        //the position of the object relative to the hand
        //if(_bones != null) Debug.Log(_bones[1].Transform.right);
        if (Input.GetKeyDown("space"))
        {
            //_ovrSkeleton.getDataFromItem = !_ovrSkeleton.getDataFromItem;
            _bones = deepCopyHandPose(_ovrSkeleton.getHandPose());
            
            SerializedHand test = Serializer.serializeBones(_bones);
            itemToSetUP.transform.parent = transform;
            itemToSetUP.GetComponent<GrabbableItem>().handPose =  JsonUtility.ToJson(test);
            itemToSetUP.GetComponent<GrabbableItem>().position = itemToSetUP.transform.localPosition;
            itemToSetUP.GetComponent<GrabbableItem>().rotation = itemToSetUP.transform.localRotation;
            itemToSetUP.GetComponent<GrabbableItem>()._bones = _bones;
            _ovrSkeleton.getDataFromItem = true;
            GrabBegin();
            //Debug.Log(Application.persistentDataPath);
            print("space key was pressed");
            //print(_bones);
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {    
            //_ovrSkeleton.getDataFromItem = !_ovrSkeleton.getDataFromItem;
            print("enter key was pressed");
        }
    }

    private List<OVRBone> deepCopyHandPose(List<OVRBone> bonesToCopy)
    {
        List<OVRBone> bonesCopy = new List<OVRBone>();
        foreach (var bone in bonesToCopy)
        {
           
            bonesCopy.Add(new OVRBone(bone.Id, bone.ParentBoneIndex,  Instantiate(bone.Transform)));
        }
        if(bonesCopy.Count == 0) Debug.Log("Copying the hand pose did not work.");
        return bonesCopy; 
    }
    
}
