using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;

public class BakterieStop : MonoBehaviour
{
    int nextScene;
    public BoxCollider2D myBoxCollider;
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        nextScene = Torsken.sceneCount;

        if (nextScene == 3)
        {
            myBoxCollider.enabled = false;
            myBoxCollider.enabled = false;
        }

    }
}

