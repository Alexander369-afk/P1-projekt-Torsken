using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VandmændStop : MonoBehaviour
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

        if (nextScene == 9)
        {
            myBoxCollider.enabled = false;
        }

    }
}
