using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscoRotate : MonoBehaviour
{

    public Vector3 rotateAmount;        //To control how fast the light should rotate

    private void Update()
    {
        transform.Rotate(rotateAmount * Time.deltaTime);
        
    }

   


}
