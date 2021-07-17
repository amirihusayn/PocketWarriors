using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothTransform : MonoBehaviour
{
    // Fields
    [SerializeField] private float smoothing;
    private Vector3 localTargetPosition, globalTargetPosition;
    private Vector3 localTargetRotation, globalTargetRotation;
    private Vector3 localTargetScale;

    // Properties
    public Vector3 LocalTargetPosition 
    {
        get => localTargetPosition;
        set
        {
            localTargetPosition = value;
            StopCoroutine("LerpLocalPosition");
            if(!gameObject.activeSelf)
                return;
            StartCoroutine("LerpLocalPosition");
        }
    }

    public Vector3 GlobalTargetPosition 
    {
        get => globalTargetPosition;
        set
        {
            globalTargetPosition = value;
            StopCoroutine("LerpGlobalPosition");
            if(!gameObject.activeSelf)
                return;
            StartCoroutine("LerpGlobalPosition");
        }
    }

    public Vector3 LocalTargetRotation
    {
        get => localTargetRotation;
        set
        {
            localTargetRotation = value;
            StopCoroutine("LerpLocalRotation");
            if(!gameObject.activeSelf)
                return;
            StartCoroutine("LerpLocalRotation");
        }
    }

    public Vector3 GlobalTargetRotation
    {
        get => globalTargetRotation;
        set
        {
            globalTargetRotation = value;
            StopCoroutine("LerpGlobalRotation");
            if(!gameObject.activeSelf)
                return;
            StartCoroutine("LerpGlobalRotation");
        }
    }

    public Vector3 LocalTargetScale
    {
        get => localTargetScale;
        set
        {
            localTargetScale = value;
            StopCoroutine("LerpLocalScale");
            if(!gameObject.activeSelf)
                return;
            StartCoroutine("LerpLocalScale");
        }
    }

    // Methods
    private IEnumerator LerpLocalPosition()
    {
        while(Vector3.Distance(transform.localPosition, localTargetPosition) > 0.05f)
        {
            transform.localPosition = 
                Vector3.Lerp(transform.localPosition, localTargetPosition, smoothing * Time.deltaTime);
            yield return null;
        }
    }

    private IEnumerator LerpGlobalPosition()
    {
        while(Vector3.Distance(transform.position, globalTargetPosition) > 0.05f)
        {
            transform.position = 
                Vector3.Lerp(transform.position, globalTargetPosition, smoothing * Time.deltaTime);
            yield return null;
        }
    }

    private IEnumerator LerpLocalRotation()
    {
        Vector3 lerpedEular;
        while(Vector3.Distance(transform.localRotation.eulerAngles, localTargetRotation) > 0.05f)
        {
            lerpedEular = 
                Vector3.Lerp(transform.localRotation.eulerAngles, localTargetRotation, smoothing * Time.deltaTime);
            transform.localRotation = Quaternion.Euler(lerpedEular);
            yield return null;
        }
    }

    private IEnumerator LerpGlobalRotation()
    {
        Vector3 lerpedEular;
        while(Vector3.Distance(transform.rotation.eulerAngles, localTargetRotation) > 0.05f)
        {
            lerpedEular = 
                Vector3.Lerp(transform.rotation.eulerAngles, localTargetRotation, smoothing * Time.deltaTime);
            transform.rotation = Quaternion.Euler(lerpedEular);
            yield return null;
        }
    }
    
    private IEnumerator LerpLocalScale()
    {
        while(Vector3.Distance(transform.localScale, localTargetScale) > 0.05f)
        {
            transform.localScale = 
                Vector3.Lerp(transform.localScale, localTargetScale, smoothing * Time.deltaTime);
            yield return null;
        }
    }
}
