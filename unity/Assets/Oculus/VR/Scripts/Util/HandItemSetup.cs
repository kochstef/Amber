using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEditor;

public class HandItemSetup : HandGrabbingBehavior
{
    private OVRHand m_hand;
    private float pinchThreshhold = 0.5f;

    private OVRSkeleton _ovrSkeleton;

    public IEnumerable<GameObject> _itemsToSetUp;
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
       // _grabbableItem = itemToSetUP.GetComponent<GrabbableItem>();
            
            try
            {
                _itemsToSetUp = Resources.LoadAll("ItemsToSetup", typeof(GameObject)).Cast<GameObject>();
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
            }
            
            //_itemsToSetUp = Resources.LoadAll("pls").Cast<GameObject>().ToArray();
            //_itemsToSetUp = Resources.LoadAll<GameObject>("pls");
            
    }

    // Update is called once per frame
    void Update()
    {
        //base.Update();
        //checkForSetupOfHandPose();
    }


    void checkForSetupOfHandPose()
    {
        //this code to get the pose of the hand and the offset of

        //the position of the object relative to the hand
        if (Input.GetKeyDown("space") && GetComponent<OVRHand>().HandType == OVRHand.Hand.HandLeft )
        {
            if (_ovrSkeleton.getDataFromItem == false)
            {
                //_ovrSkeleton.getDataFromItem = !_ovrSkeleton.getDataFromItem;
                _bones = deepCopyHandPose(_ovrSkeleton.getHandPose());

                SerializedHand test = Serializer.serializeBones(_bones);
                itemToSetUP.transform.parent = transform;
                itemToSetUP.GetComponent<GrabbableItem>()._bonesLeft = _bones;
                itemToSetUP.GetComponent<GrabbableItem>()._rotationLeft = itemToSetUP.transform.localRotation;
                itemToSetUP.GetComponent<GrabbableItem>()._positionLeft = itemToSetUP.transform.localPosition;

                itemToSetUP.GetComponent<GrabbableItem>()._handPoseLeft = JsonUtility.ToJson(test);
                
                _ovrSkeleton.getDataFromItem = true;
                GrabBegin();
                //Debug.Log(Application.persistentDataPath);
                print("space key was pressed");
            }
            else
            {
                GrabEnd();
            }

            //print(_bones);
        }
        //if(_bones != null) Debug.Log(_bones[1].Transform.right);

        if (Input.GetKeyDown(KeyCode.Return) && GetComponent<OVRHand>().HandType == OVRHand.Hand.HandRight )
        {
            if (_ovrSkeleton.getDataFromItem == false)
            {
                _bones = deepCopyHandPose(_ovrSkeleton.getHandPose());

                SerializedHand test = Serializer.serializeBones(_bones);
                itemToSetUP.transform.parent = transform;
                itemToSetUP.GetComponent<GrabbableItem>()._handPoseRight = JsonUtility.ToJson(test);
                itemToSetUP.GetComponent<GrabbableItem>()._rotationRight = itemToSetUP.transform.localRotation;
                itemToSetUP.GetComponent<GrabbableItem>()._positionRight = itemToSetUP.transform.localPosition;
                itemToSetUP.GetComponent<GrabbableItem>()._bonesRight = _bones;
                _ovrSkeleton.getDataFromItem = true;
                GrabBegin();
                //_ovrSkeleton.getDataFromItem = !_ovrSkeleton.getDataFromItem;
                print("enter key was pressed");
            }
            else
            {
                GrabEnd();
            }
        }
        
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            foreach (var setUpItem in _itemsToSetUp)
            {
                try
                {
                    //GameObject contentsRoot = PrefabUtility.LoadPrefabContents(Application.dataPath + "/Resources/ItemsToSetup/" + ölkj.name  + ".prefab");
                    //Debug.Log(contentsRoot.name);
                    //we need do unpack it to be able to delete the other items. 
                    GameObject instanceRoot = (GameObject)PrefabUtility.InstantiatePrefab(setUpItem);
                    PrefabUtility.UnpackPrefabInstance(instanceRoot, PrefabUnpackMode.Completely, InteractionMode.AutomatedAction); 

                    PrefabUtility.SaveAsPrefabAsset(instanceRoot, Application.dataPath + "/Resources/SetupItems/" + instanceRoot.name  + ".prefab");
                    Debug.Log(setUpItem.name);
                }
                catch (Exception e)
                {
                    Debug.Log(e);
                }
            }
        }
    }

    private List<OVRBone> deepCopyHandPose(List<OVRBone> bonesToCopy)
    {
        List<OVRBone> bonesCopy = new List<OVRBone>();
        foreach (var bone in bonesToCopy)
        {
            bonesCopy.Add(new OVRBone(bone.Id, bone.ParentBoneIndex, Instantiate(bone.Transform)));
        }

        if (bonesCopy.Count == 0) Debug.Log("Copying the hand pose did not work.");
        return bonesCopy;
    }
}