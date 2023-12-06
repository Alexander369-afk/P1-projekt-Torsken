using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening; // Enables DOTween in the script

public class Movement11year : MonoBehaviour
{
    [Range(0f, 10f), SerializeField] private float _duration = 0.2f;
    private float _fast = 0.1f;
    private float _flip = 1f;
    private float _rotation = 180f;
    void Start()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(transform.DOMove(new Vector2(15,2), _duration).SetEase(Ease.InOutSine));
        sequence.Append(transform.DORotate(new Vector3(0, _rotation, 0), _flip).SetEase(Ease.InOutSine));
        sequence.Append(transform.DOMove(new Vector2(15, -2), _fast));
        sequence.Append(transform.DOScale(new Vector3(0.2f, 0.2f, 0.2f), _fast));
        sequence.Append(transform.DOMove(new Vector2(-15,-2), _duration).SetEase(Ease.InOutSine));
        sequence.Append(transform.DORotate(new Vector3(0, _rotation), _flip).SetEase(Ease.InOutSine));

        sequence.SetLoops(-1, LoopType.Restart);
    }
}