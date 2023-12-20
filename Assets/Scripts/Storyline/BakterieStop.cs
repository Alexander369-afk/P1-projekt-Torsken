using UnityEngine;

public class BakterieStop : MonoBehaviour
{
    public static bool nxtScnBak = false;
    public BoxCollider2D myBoxCollider;

    void OnTriggerEnter2D(Collider2D other)
    {
        nxtScnBak = true;

        myBoxCollider.enabled = false;
        Debug.Log("nxtScnBak is " + nxtScnBak);
        
    }
}

