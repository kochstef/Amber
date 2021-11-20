using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ShadowEffect : MonoBehaviour
{
    // Start is called before the first frame update
   
    public Transform start;
    public Transform end;
    public float duration;
   

    public void StartDogAttack()
    {
        transform.position = start.position;
        Tweener tweener = transform.DOMove(end.position, duration);
        tweener.SetEase(Ease.Flash);
        //tweener.SetLoops(int.MaxValue, LoopType.Yoyo);
    }
}
