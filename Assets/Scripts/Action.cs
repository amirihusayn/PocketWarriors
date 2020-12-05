using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : MonoBehaviour
{
    [SerializeField] private Animator warriorAnimator;

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
            warriorAnimator.SetTrigger("OnRightVerticalHit");  
        if(Input.GetKeyDown(KeyCode.Mouse1))
            warriorAnimator.SetTrigger("OnRightHorizontalHit");  
    }
}
