using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaktiereSpil : MonoBehaviour
{
    public static bool nxtScnSpl1 = false;
    public BoxCollider2D myBoxCollider;
    void OnTriggerEnter2D(Collider2D other)
    {
        nxtScnSpl1 = true;

        myBoxCollider.enabled = false;
        Debug.Log("nxtScnBak is " + nxtScnSpl1);
    }
}
