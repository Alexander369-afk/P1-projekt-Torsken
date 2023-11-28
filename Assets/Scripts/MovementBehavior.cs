using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MovementBehavior : MonoBehaviour
{
    [SerializeField] private float _cycleLength = 2;
   // [SerializeField] private Transform[] _Fish;
    // Start is called before the first frame update
    void Start()
    {

        var sequence = DOTween.Sequence();

 {
            sequence.Append(transform.DOMove(new Vector3(650,500,2), _cycleLength).SetEase(Ease.InOutSine));
        }

        sequence.OnComplete(() => {
        {
            transform.DOMove(new Vector3(1500,500,2), _cycleLength).SetEase(Ease.InOutSine).SetLoops(-1,LoopType.Yoyo);
            }
        });


        

        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
