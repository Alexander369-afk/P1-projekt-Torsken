using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class VandmaendStop : MonoBehaviour
{
    public static bool nxtScnVnmd = false;
    public BoxCollider2D myBoxCollider;

    void OnTriggerEnter2D(Collider2D other)
    {
        nxtScnVnmd = true;

        myBoxCollider.enabled = false;
        Debug.Log("nxtScnVnmd is " + nxtScnVnmd);

    }
}
