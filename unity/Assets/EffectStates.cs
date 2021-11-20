using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EffectStates : MonoBehaviour
{
    // Start is called before the first frame update
    public static EffectStates Instance = null;
    public bool startDog = false;
  

    private void Awake()
    {
        startDog = false;
        Instance = this;
    }

    void Start()
    {
        
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
}
