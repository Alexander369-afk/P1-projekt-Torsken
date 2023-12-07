using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneScript : MonoBehaviour
{
    [SerializeField] private float duration;

    public float Duration
    {
        get { return duration; }
    }
}
