using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening; // Enables DOTween in the script

public class Movement11year : MonoBehaviour
{
    [Range(0f, 10f), SerializeField] private float _duration = 0.2f; // Duration of the tween
    private float _speed = 0.1f; // Speed of the tween
    private float _flip = 1f; // Flip speed of the tween
    private float _rotation = 180f; // Rotation of the tween

    // https://www.youtube.com/watch?v=PLFQp0TvsK0 was used to understand sequencing in Unity
    void Start()
    {
        // Creating a sequence of tweens to move the GameObject
        // .SetEase sets the easing of the tween meaning it affects the acceleration and deceleration of the tween. Here we use Ease.InOutSine
        var sequence = DOTween.Sequence();
        sequence.Append(transform.DOMove(new Vector2(15,2), _duration).SetEase(Ease.InOutSine));
        sequence.Append(transform.DORotate(new Vector3(0, _rotation, 0), _flip).SetEase(Ease.InOutSine));
        sequence.Append(transform.DOMove(new Vector2(15, -2), _speed));
        sequence.Append(transform.DOScale(new Vector3(0.2f, 0.2f, 0.2f), _speed));
        sequence.Append(transform.DOMove(new Vector2(-15,-2), _duration).SetEase(Ease.InOutSine));
        sequence.Append(transform.DORotate(new Vector3(0, _rotation), _flip).SetEase(Ease.InOutSine));

        // This sequence refers to the first sequence and will loop it infinitely
        sequence.SetLoops(-1, LoopType.Restart);
    }
}