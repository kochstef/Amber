using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HandGrabbingBehavior : OVRGrabber
{
    private OVRHand m_hand;
    private float pinchThreshhold = 0.5f;

    private OVRSkeleton _ovrSkeleton;
    
    //
    // Start is called before the first frame update
    private GameObject grabbedObject;
    public List<OVRBone> _bones;
    void Start()
    {
        base.Start();
        m_hand = GetComponent<OVRHand>();
        _ovrSkeleton = GetComponent<OVRSkeleton>();
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();    
        CheckIndexPinch();
    }

    

    void CheckIndexPinch()
    {
        float pinchStrength = m_hand.GetFingerPinchStrength(OVRHand.HandFinger.Index);

        if(!m_grabbedObj && pinchStrength > pinchThreshhold && m_grabCandidates.Count > 0)
        {
            //TODO: write my own fuction this one is bad. 
            //_bones = deepCopyHandPose(_ovrSkeleton.getHandPose());
            // return the Gameobject grabbed to get the hand pose and the offset of the object
            grabbedObject = GrabBegin();
            _bones = grabbedObject.GetComponent<ItemGrabbable>()._bones;
            _ovrSkeleton.getDataFromItem = true;


        }
        else if (m_grabbedObj && !(pinchStrength > pinchThreshhold))
        {
            GrabEnd();
            _ovrSkeleton.getDataFromItem = false;
        }
        
        //this code to get the pose of the hand and the offset of
        //the position of the object relative to the hand
        //if(_bones != null) Debug.Log(_bones[1].Transform.right);
        /*if (Input.GetKeyDown("space"))
        {
            _ovrSkeleton.getDataFromItem = !_ovrSkeleton.getDataFromItem;
            _bones = deepCopyHandPose(_ovrSkeleton.getHandPose());
            //_bones[0].Id = new 
            print("space key was pressed");
            print(_bones);
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {    
            
            print("enter key was pressed");
        }*/
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
    /*
    protected virtual void GrabItemBegin()
    {
        float closestMagSq = float.MaxValue;
		OVRGrabbable closestGrabbable = null;
        Collider closestGrabbableCollider = null;

        // Iterate grab candidates and find the closest grabbable candidate
		foreach (OVRGrabbable grabbable in m_grabCandidates.Keys)
        {
            bool canGrab = !(grabbable.isGrabbed && !grabbable.allowOffhandGrab);
            if (!canGrab)
            {
                continue;
            }

            for (int j = 0; j < grabbable.grabPoints.Length; ++j)
            {
                Collider grabbableCollider = grabbable.grabPoints[j];
                // Store the closest grabbable
                Vector3 closestPointOnBounds = grabbableCollider.ClosestPointOnBounds(m_gripTransform.position);
                float grabbableMagSq = (m_gripTransform.position - closestPointOnBounds).sqrMagnitude;
                if (grabbableMagSq < closestMagSq)
                {
                    closestMagSq = grabbableMagSq;
                    closestGrabbable = grabbable;
                    closestGrabbableCollider = grabbableCollider;
                }
            }
        }

        // Disable grab volumes to prevent overlaps
        GrabVolumeEnable(false);

        if (closestGrabbable != null)
        {
            if (closestGrabbable.isGrabbed)
            {
                closestGrabbable.grabbedBy.OffhandGrabbed(closestGrabbable);
            }

            m_grabbedObj = closestGrabbable;
            m_grabbedObj.GrabBegin(this, closestGrabbableCollider);

            m_lastPos = transform.position;
            m_lastRot = transform.rotation;

            // Set the postition for the grabbed object desired position relative to hand.
            m_grabbedObjectPosOff = m_gripTransform.localPosition;
            Vector3 newPosition = m_grabbedObj.snapOffset.position;
            m_lastPos = newPosition;    
         

            if (m_grabbedObj.snapOrientation)
            {
                //TODO: CHANGE THIS TO WICHED ROTATION
                m_grabbedObjectRotOff = m_gripTransform.localRotation;
                if(m_grabbedObj.snapOffset)
                {
                    m_grabbedObjectRotOff = m_grabbedObj.snapOffset.rotation * m_grabbedObjectRotOff;
                }
            }
            else
            {
                Quaternion relOri = Quaternion.Inverse(transform.rotation) * m_grabbedObj.transform.rotation;
                m_grabbedObjectRotOff = relOri;
            }

            // NOTE: force teleport on grab, to avoid high-speed travel to dest which hits a lot of other objects at high
            // speed and sends them flying. The grabbed object may still teleport inside of other objects, but fixing that
            // is beyond the scope of this demo.
            MoveGrabbedObject(m_lastPos, m_lastRot, true);

            // NOTE: This is to get around having to setup collision layers, but in your own project you might
            // choose to remove this line in favor of your own collision layer setup.
            SetPlayerIgnoreCollision(m_grabbedObj.gameObject, true);

            if (m_parentHeldObject)
            {
                m_grabbedObj.transform.parent = transform;
            }
        }
    }*/

}
