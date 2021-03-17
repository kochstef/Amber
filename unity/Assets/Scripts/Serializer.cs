using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Serializer : MonoBehaviour
{
    
    
    //Because Transforms cant because Serialized
    public static SerializedHand serializeBones(List<OVRBone> ovrBones)
    {
        //We create a new list that actually isn't ruined by object orientation. 
        List<SerializedBone> serializedBonesList = new List<SerializedBone>();
        foreach (var bone in ovrBones)
        {
            serializedBonesList.Add(new SerializedBone((int)bone.Id, bone.Transform, bone.ParentBoneIndex));
        }
            
        return new SerializedHand(serializedBonesList);
    }

    public static List<OVRBone> deserializeHand(SerializedHand serializedHand)
    {
        
        List<OVRBone> bonesCopy = new List<OVRBone>();
        foreach (var bone in serializedHand._serializedBones)
        {
           
            var boneGO = new GameObject(bone.BoneID.ToString());
            
            boneGO.transform.localPosition = new Vector3(bone.serializedTransform._position[0],bone.serializedTransform._position[1],
                bone.serializedTransform._position[2]);;
            boneGO.transform.localRotation = new Quaternion(bone.serializedTransform._rotation[0], bone.serializedTransform._rotation[1], 
                bone.serializedTransform._rotation[2], bone.serializedTransform._rotation[3]);
            
            bonesCopy.Add(new OVRBone((OVRSkeleton.BoneId)bone.BoneID, bone.ParentBoneIndex,  boneGO.transform));
            
            
        }
        return bonesCopy; 
       // return 
    }
}

[Serializable]
public class SerializedHand
{
    public List<SerializedBone> _serializedBones = null;

    public SerializedHand(List<SerializedBone> boneList)
    {
        this._serializedBones = boneList;
    }
}


[Serializable]
public class SerializedBone
{
    public int BoneID = 0;
    public SerializedTransform serializedTransform = null;
    public short ParentBoneIndex = 0;

    public SerializedBone(int boneId, Transform transform, short parentBoneIndex)
    {
        this.BoneID = boneId;
        this.serializedTransform = new SerializedTransform(transform);
        this.ParentBoneIndex = parentBoneIndex;
    }
    
}


[Serializable]
public class SerializedTransform
{
    public float[] _position = new float[3];
    public float[] _rotation = new float[4];
    public float[] _scale = new float[3];

    public SerializedTransform(Transform transform)
    {
        _position[0] = transform.localPosition.x;
        _position[1] = transform.localPosition.y;
        _position[2] = transform.localPosition.z;

        _rotation[0] = transform.localRotation.x;
        _rotation[1] = transform.localRotation.y;
        _rotation[2] = transform.localRotation.z;
        _rotation[3] = transform.localRotation.w;

        _scale[0] = transform.localScale.x;
        _scale[1] = transform.localScale.y;
        _scale[2] = transform.localScale.z;
    }
}
