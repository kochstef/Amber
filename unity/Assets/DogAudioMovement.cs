using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class DogAudioMovement : MonoBehaviour
{
    
    AudioSource dogAudio;
    public Transform start;
    public Transform end;
    public float duration;
    private void Start()
    { 
        dogAudio = GetComponent<AudioSource>();
    }

    public void StartDogAttack()
    {
        
        dogAudio.Play(0);
        transform.position = start.position;
        Tweener tweener = transform.DOMove(end.position, duration);
        tweener.SetEase(Ease.InOutQuad);
        //tweener.SetLoops(int.MaxValue, LoopType.Yoyo);
    }
}
