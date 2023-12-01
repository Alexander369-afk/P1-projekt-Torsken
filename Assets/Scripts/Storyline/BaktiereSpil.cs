using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaktiereSpil : MonoBehaviour
{
    private int nextScene;
    public BoxCollider2D myBoxCollider;
   
 
    // Update is called once per frame
    void Update()
    {
        nextScene = Torsken.sceneCount;

        if (nextScene == 5)
        {
            myBoxCollider.enabled = false;
        }

    }
}
