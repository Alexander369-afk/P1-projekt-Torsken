using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraTriggerSwitcher : MonoBehaviour
{
    public string triggerEnterTag;
    public string triggerExitTag;

    public CinemachineVirtualCamera primaryCamera;

    public CinemachineVirtualCamera[] virtualCameras;

    private void Start()
    {
        SwitchToCamera(primaryCamera);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(triggerEnterTag))
        {
            CinemachineVirtualCamera targetCamera = other.GetComponentInChildren<CinemachineVirtualCamera>();
            Debug.Log("Entered trigger. Switching to camera: " + targetCamera.name);
            SwitchToCamera(targetCamera);
            
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(triggerExitTag))
        {
            Debug.Log("Exited trigger. Switching to primary camera.");
            SwitchToCamera(primaryCamera);
        }
    }

    private void SwitchToCamera(CinemachineVirtualCamera targetCamera)
    {
        foreach (CinemachineVirtualCamera camera in virtualCameras)
        {
            camera.enabled = camera == targetCamera;
        }
    }
}