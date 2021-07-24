using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PocketWarriors
{
    public class GameController : singleton<GameController> {
        // Fields________________________________________________________
        [SerializeField] private bool isGameLocal;

        // Properties___________________________________________________
        public bool IsGameLocal { get => isGameLocal; }
    }
}
