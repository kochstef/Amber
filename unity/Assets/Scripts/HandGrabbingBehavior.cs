using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OculusSampleFramework;


public class HandGrabbingBehavior : OVRGrabber
{
    private OVRHand m_hand;
    private float pinchThreshhold = 0.7f;

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        m_hand = GetComponent<OVRHand>();
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
            GrabBegin();
        }
        else if (m_grabbedObj && !(pinchStrength > pinchThreshhold))
        {
            GrabEnd();
        }
    }

}
