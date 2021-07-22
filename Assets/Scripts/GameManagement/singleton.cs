﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class singleton<T> : MonoBehaviour where T : MonoBehaviour {
    // Properties___________________________________________________
	public static T Instance { get; private set; }

    // Methods_____________________________________________________
    protected virtual void Awake()
    {
        if(Instance == null)
            Instance = (T)FindObjectOfType(typeof(T));
        else
            Destroy(gameObject);
    }
}
