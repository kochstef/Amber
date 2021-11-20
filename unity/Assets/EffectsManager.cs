using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsManager : MonoBehaviour
{
    // Start is called before the first frame update
    public ShadowEffect shadowEffect;
    public DogAudioMovement dogAudioMovement;
    void Start()
    {
        
    }

    public void invokeShadowEffect()
    {
        shadowEffect.StartDogAttack();
    }


    private void startDogEffect()
    {
        dogAudioMovement.StartDogAttack();
        Invoke(nameof(invokeShadowEffect), 0.5f); //2 is the time
    }

    // Update is called once per frame
    void Update()
    {
        if (EffectStates.Instance.startDog)
        {
            startDogEffect();
            EffectStates.Instance.startDog = false;
        }
    }
}
