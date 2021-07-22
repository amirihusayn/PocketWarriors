using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraForward : MonoBehaviour
{
    private Transform cameraTransform;
    private bool isCameraTransformInitialized;

    private void Start() 
    {
        StopAllCoroutines();
        StartCoroutine("GetCameraTransform");
    }

    private void LateUpdate() 
    {
        if(isCameraTransformInitialized)
            gameObject.transform.forward = cameraTransform.forward;
    }

    private IEnumerator GetCameraTransform()
    {
        yield return new WaitForSeconds(3f);
        cameraTransform = Camera.main.gameObject.transform;
        isCameraTransformInitialized = true;
    }
}
