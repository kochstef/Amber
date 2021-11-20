using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogEffectTrigger : MonoBehaviour
{
    // Start is called before the first frame update
 
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            Debug.Log("TRIGGERED !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            EffectStates.Instance.startDog = true;
        }
    }
}
