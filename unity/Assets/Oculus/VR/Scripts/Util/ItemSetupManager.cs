using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class ItemSetupManager : MonoBehaviour
{
    //TODO: Undo comment crashes unrelated build dont know why
    /*
    public HandItemSetup itemSetupLeft;
    public HandItemSetup itemSetupRight;
    
    
    public List<GameObject> _itemsToSetUp;
    public GameObject itemToSetUP;
    private int indexCurrentItem = 0;
    // Start is called before the first frame update
    void Start()
    {
        _itemsToSetUp = new List<GameObject>();
        
        GameObject[] tmpItemsToSetUp = null; 
        try
        {
            tmpItemsToSetUp = Resources.LoadAll("ItemsToSetup", typeof(GameObject)).Cast<GameObject>().ToArray();
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }

        
        foreach (var setUpItem in tmpItemsToSetUp)
        {
            Debug.Log("dölkfjasöldfjaklösdflköjajslköfdlköjashdlöjk");
            try
            {
                //GameObject contentsRoot = PrefabUtility.LoadPrefabContents(Application.dataPath + "/Resources/ItemsToSetup/" + ölkj.name  + ".prefab");
                //Debug.Log(contentsRoot.name);
                //we need do unpack it to be able to delete the other items. 
                GameObject instanceRoot = (GameObject) PrefabUtility.InstantiatePrefab(setUpItem);

                PrefabUtility.UnpackPrefabInstance(instanceRoot, PrefabUnpackMode.Completely,
                    InteractionMode.AutomatedAction);
                _itemsToSetUp.Add(instanceRoot);
                instanceRoot.SetActive(false);
                Debug.Log(setUpItem.name);
            }
            catch (Exception e)
            {
                Debug.Log(e);
            }
        }

        indexCurrentItem = 0;
        itemToSetUP = _itemsToSetUp[indexCurrentItem];
        itemToSetUP.SetActive(true);
       
    }

    // Update is called once per frame
    void Update()
    {
                //the position of the object relative to the hand
        if (Input.GetKeyDown("space"))
        {
            if (itemSetupLeft._ovrSkeleton.getDataFromItem == false)
            {
                //_ovrSkeleton.getDataFromItem = !_ovrSkeleton.getDataFromItem;
                itemSetupLeft._bones = deepCopyHandPose(itemSetupLeft._ovrSkeleton.getHandPose());

                SerializedHand test = Serializer.serializeBones(itemSetupLeft._bones);
                itemToSetUP.transform.parent = itemSetupLeft.transform;
                itemToSetUP.GetComponent<GrabbableItem>()._bonesLeft = itemSetupLeft._bones;
                itemToSetUP.GetComponent<GrabbableItem>()._rotationLeft = itemToSetUP.transform.localRotation;
                itemToSetUP.GetComponent<GrabbableItem>()._positionLeft = itemToSetUP.transform.localPosition;

                itemToSetUP.GetComponent<GrabbableItem>()._handPoseLeft = JsonUtility.ToJson(test);

                itemSetupLeft._ovrSkeleton.getDataFromItem = true;
                itemSetupLeft.GrabBegin();
                //Debug.Log(Application.persistentDataPath);
                print("space key was pressed");
            }
            else
            {
                itemSetupLeft.GrabEnd();
            }

            //print(_bones);
        }
        //if(_bones != null) Debug.Log(_bones[1].Transform.right);

        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (itemSetupRight._ovrSkeleton.getDataFromItem == false)
            {
                itemSetupRight._bones = deepCopyHandPose(itemSetupRight._ovrSkeleton.getHandPose());

                SerializedHand test = Serializer.serializeBones(itemSetupRight._bones);
                itemToSetUP.transform.parent = itemSetupRight.transform;
                itemToSetUP.GetComponent<GrabbableItem>()._handPoseRight = JsonUtility.ToJson(test);
                itemToSetUP.GetComponent<GrabbableItem>()._rotationRight = itemToSetUP.transform.localRotation;
                itemToSetUP.GetComponent<GrabbableItem>()._positionRight = itemToSetUP.transform.localPosition;
                itemToSetUP.GetComponent<GrabbableItem>()._bonesRight = itemSetupRight._bones;
                itemSetupRight._ovrSkeleton.getDataFromItem = true;
                itemSetupRight.GrabBegin();
                //_ovrSkeleton.getDataFromItem = !_ovrSkeleton.getDataFromItem;
                print("enter key was pressed");
            }
            else
            {
                itemSetupRight.GrabEnd();
            }
        }


        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            itemToSetUP.SetActive(false);
            indexCurrentItem += 1;
            if (indexCurrentItem < _itemsToSetUp.Count)
            {
                itemToSetUP = _itemsToSetUp[indexCurrentItem];
            }
            else
            {
                indexCurrentItem = 0;
                itemToSetUP = _itemsToSetUp[indexCurrentItem];
            }
            itemToSetUP.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            itemToSetUP.SetActive(false);
            indexCurrentItem -= 1;
            if (indexCurrentItem >= 0)
            {
                itemToSetUP = _itemsToSetUp[indexCurrentItem];
            }
            else
            {
                indexCurrentItem = _itemsToSetUp.Count - 1;
                itemToSetUP = _itemsToSetUp[indexCurrentItem];
                
            }
            itemToSetUP.SetActive(true);
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
                 //   GameObject instanceRoot = (GameObject) PrefabUtility.InstantiatePrefab(setUpItem);
                  //  PrefabUtility.UnpackPrefabInstance(instanceRoot, PrefabUnpackMode.Completely,
                  //      InteractionMode.AutomatedAction);

                    setUpItem.SetActive(true);
                    PrefabUtility.SaveAsPrefabAsset(setUpItem,
                        Application.dataPath + "/Resources/SetupItems/" + setUpItem.name + ".prefab");
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
    }*/
}
