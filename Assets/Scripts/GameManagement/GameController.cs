using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : singleton<GameController> {
	// Fields
	[SerializeField] protected bool isGameLocal;

    // Properties
    public bool IsGameLocal { get => isGameLocal; }
}
