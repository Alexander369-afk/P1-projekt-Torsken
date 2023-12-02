using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscoRotate : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 5f;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            DiscoRotateAroundZAxis();
        }
    }

    private void DiscoRotateAroundZAxis()
    {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }


}
