using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEditor;

public class HandItemSetup : HandGrabbingBehavior
{
    private float pinchThreshhold = 0.5f;
    



    private GameObject _grabbableItem;


    private string handPose = "";

    private List<OVRBone> _bones;

    private Transform _transform;



    // public List<OVRBone> _bones;
    // Start is called before the first frame update
    void Start()
    {
      //  base.Start();
       // m_hand = GetComponent<OVRHand>();
       // _ovrSkeleton = GetComponent<OVRSkeleton>();
        //_itemsToSetUp = Resources.LoadAll("pls").Cast<GameObject>().ToArray();
        //_itemsToSetUp = Resources.LoadAll<GameObject>("pls");
    }

    // Update is called once per frame
    void Update()
    {
        //base.Update();
       
    }

}