using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening; // enables DOTween in the script

public class MovementBehavior : MonoBehaviour
{
    [Range(1.0f, 10.0f), SerializeField] private float _moveDuration = 2.0f; // Change move duration in inspector
    [SerializeField] private Ease _moveEase = Ease.Linear; // Change the smoothness of the movement in inspector

    //Waypoint system built into the inspector
    // Referenced from https://www.youtube.com/watch?v=XQkDAzr-0Xo, explains how to make a simple waypoint system using DOTween
    [SerializeField] private PathType _pathSystem = PathType.CatmullRom;
    public Vector3[] _wayPoints = new Vector3[3]; // Creates an array for the waypoints

    void Start()
    {
        // Referenced from https://youtu.be/Y8cv-rF5j6c?si=yMQX-ejtFz6z2c-2&t=1, gives an overview on DOTween how to write with it and how to sequence
        var sequence = DOTween.Sequence(); { // Creates a sequence using DOTween

            sequence.Append(transform.DOMove(new Vector3(650,500,2), _moveDuration).SetEase(_moveEase)); // Moves the GameObject to the set Vector3.
        }

        sequence.OnComplete(() => { // Once the first Transform is completed the sequence follows to the next line of code
            {
            sequence.Append(transform.DOPath(_wayPoints, _moveDuration, _pathSystem).SetEase(_moveEase).SetLoops(-1,LoopType.Yoyo)); // The GameObject now follows the set path, using the Waypoints created in Inspector
            }
        });
    }
}
