using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PocketWarriors
{
    public class CameraForward : MonoBehaviour
    {
        [SerializeField] private bool isForward, isBackward, isRight, isLeft;
        private Transform cameraTransform;
        private bool isCameraTransformInitialized;

        private void Start() 
        {
            StopAllCoroutines();
            StartCoroutine("GetCameraTransform");
        }

        private void LateUpdate() 
        {
            if(isCameraTransformInitialized && isForward)
                gameObject.transform.forward = cameraTransform.forward;
            else if(isCameraTransformInitialized && isBackward)
                gameObject.transform.forward = - cameraTransform.forward;
            else if(isCameraTransformInitialized && isRight)
                gameObject.transform.right = cameraTransform.right;
            else if(isCameraTransformInitialized && isLeft)
                gameObject.transform.right = - cameraTransform.right;
        }

        private IEnumerator GetCameraTransform()
        {
            yield return new WaitForSeconds(3f);
            cameraTransform = Camera.main.gameObject.transform;
            isCameraTransformInitialized = true;
        }
    }
}
