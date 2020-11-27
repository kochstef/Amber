using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class HandGrabbingBehavior : MonoBehaviour
{
    public OVRGrabbable m_grabbedObj = null;
    public List<OVRBone> _bones;
    
    private OVRHand m_hand;
    private float pinchThreshhold = 0.2f;
    private OVRSkeleton _ovrSkeleton;
    private Dictionary<OVRGrabbable, int> m_grabCandidates = new Dictionary<OVRGrabbable, int>();
    private Transform m_gripTransform = null;
    private Collider[] m_grabVolumes;
    private bool m_grabVolumeEnabled = false;
    //
    private bool m_moveHandPosition = false;
  //  private OVRGrabbable m_grabbedObj = null;
    // Start is called before the first frame update


    //private GameObject grabbedObject;

    protected virtual void Awake()
    {
        // If we are being used with an OVRCameraRig, let it drive input updates, which may come from Update or FixedUpdate.
        OVRCameraRig rig = transform.GetComponentInParent<OVRCameraRig>();
        if (rig != null)
        {
            rig.UpdatedAnchors += (r) => { OnUpdatedAnchors(); };
        }
        else
        {
            Debug.Log("You have to use the camera Rig");
        }
    }
    //m_grabCandidates


    void Start()
    {
        //base.Start();
        m_hand = GetComponent<OVRHand>();
        _ovrSkeleton = GetComponent<OVRSkeleton>();
    }

    // Update is called once per frame
    void Update()
    {
        //base.Update();    
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
            m_grabbedObj = GrabBegin();
        }
        else if (m_grabbedObj && !(pinchStrength > pinchThreshhold))
        { 
            GrabEnd();
            //GrabVolumeEnable(true);
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

    private void findClosestGrabbable(ref OVRGrabbable closestGrabbable, ref Collider closestGrabbableCollider)
    {
        float closestMagSq = float.MaxValue;
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
                Vector3 closestPointOnBounds = grabbableCollider.ClosestPointOnBounds(transform.position);
                float grabbableMagSq = (transform.position - closestPointOnBounds).sqrMagnitude;
                if (grabbableMagSq < closestMagSq)
                {
                    closestMagSq = grabbableMagSq;
                    closestGrabbable = grabbable;
                    closestGrabbableCollider = grabbableCollider;
                }
            }
        }
    }

    void moveItemToHand()
    {
        m_grabbedObj.transform.localPosition = m_grabbedObj.GetComponent<GrabbableItem>().position;
        m_grabbedObj.transform.localRotation = m_grabbedObj.GetComponent<GrabbableItem>().rotation;
    }

    protected virtual OVRGrabbable GrabBegin()
    {
        OVRGrabbable closestGrabbable = null;
        Collider closestGrabbableCollider = null;

        // Iterate grab candidates and find the closest grabbable candidate
        findClosestGrabbable(ref closestGrabbable, ref closestGrabbableCollider);
        
        // Disable grab volumes to prevent overlaps
        
        //TODO: NOT SURE IF THIS IS SUFICE
        //GrabVolumeEnable(false);
        //------------------------------------------------
        
        if (closestGrabbable == null) return null;
        
        if (closestGrabbable.isGrabbed && m_grabbedObj == closestGrabbable)
        {
            Rigidbody rb = gameObject.GetComponent<Rigidbody>();
            rb.isKinematic = false;
            m_grabbedObj.m_grabbedBy = null;
            m_grabbedObj.m_grabbedCollider = null; 
            m_grabbedObj.transform.parent = null;
            m_grabbedObj = null;
        }
        
        m_grabbedObj = closestGrabbable; 
        m_grabbedObj.GrabBegin(this, closestGrabbableCollider);
        
        m_grabbedObj.transform.parent = transform; 
        //Move to right position and rotation
        moveItemToHand(); 
        //set the gesture for holding the item
        _bones = m_grabbedObj.GetComponent<GrabbableItem>()._bones; 
        _ovrSkeleton.getDataFromItem = true; 
        return m_grabbedObj;
        
    }

    public void GrabEnd()
    {
        Rigidbody rb = m_grabbedObj.GetComponent<GrabbableItem>().GetComponent<Rigidbody>();
        rb.isKinematic = false;
        m_grabbedObj.GetComponent<GrabbableItem>().m_grabbedBy = null;
        m_grabbedObj.GetComponent<GrabbableItem>().m_grabbedCollider = null;
        m_grabbedObj.transform.parent = null;
        m_grabbedObj = null;
        _ovrSkeleton.getDataFromItem = false;
      //  GrabVolumeEnable(true);
    }

    void OnUpdatedAnchors()
    {
        /*
        Vector3 destPos = m_parentTransform.TransformPoint(m_anchorOffsetPosition);
        Quaternion destRot = m_parentTransform.rotation * m_anchorOffsetRotation;

        if (m_moveHandPosition)
        {
            GetComponent<Rigidbody>().MovePosition(destPos);
            GetComponent<Rigidbody>().MoveRotation(destRot);
        }

        
        
        float prevFlex = m_prevFlex;
        // Update values from inputs
        m_prevFlex = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, m_controller);

        CheckForGrabOrRelease(prevFlex);
        */    
    }
    
    void OnTriggerEnter(Collider otherCollider)
    {
        // Get the grab trigger
        OVRGrabbable grabbable = otherCollider.GetComponent<OVRGrabbable>() ?? otherCollider.GetComponentInParent<OVRGrabbable>();
        if (grabbable == null) return;

        // Add the grabbable
        Debug.Log("Found grabbable added to List");
        int refCount = 0;
        m_grabCandidates.TryGetValue(grabbable, out refCount);
        m_grabCandidates[grabbable] = refCount + 1;
    }
    
    void OnTriggerExit(Collider otherCollider)
    {
        OVRGrabbable grabbable = otherCollider.GetComponent<OVRGrabbable>() ?? otherCollider.GetComponentInParent<OVRGrabbable>();
        if (grabbable == null) return;

        // Remove the grabbable
        int refCount = 0;
        bool found = m_grabCandidates.TryGetValue(grabbable, out refCount);
        if (!found)
        {
            return;
        }

        if (refCount > 1)
        {
            m_grabCandidates[grabbable] = refCount - 1;
        }
        else
        {
            m_grabCandidates.Remove(grabbable);
        }
    }
    
    //WE now now that this ugly code is completely  useless 
    private void GrabVolumeEnable(bool enabled)
    {
        if (m_grabVolumeEnabled == enabled)
        {
            return;
        }

        m_grabVolumeEnabled = enabled;
        foreach (var grabVolume in m_grabVolumes)
        {
            grabVolume.enabled = m_grabVolumeEnabled;
        }

        if (!m_grabVolumeEnabled)
        {
            m_grabCandidates.Clear();
        }
    }


}
