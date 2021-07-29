using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace PocketWarriors
{
    [Serializable]
    public class ActionRequirement
    {
        // Fields________________________________________________________
        [SerializeField] private WarriorStats stats;
        [SerializeField] private Animator animator;
        [SerializeField] private Rigidbody rigidbody;
        private ActionContainer actionContainer;
        private InputPrototype warriorInput;
        private Vector3 movement;
        private bool isHorizontalAttack;

        // Properties___________________________________________________
        public WarriorStats Stats { get => stats;}
        public Animator Animator { get => animator; }
        public Rigidbody RigidBody { get => rigidbody; }
        public ActionContainer ActionContainer { get => actionContainer; set => actionContainer = value; }
        public InputPrototype WarriorInput { get => warriorInput; set => warriorInput = value; }
        public Vector3 Movement { get => movement; set => movement = value; }
        public bool IsHorizontalAttack { get => isHorizontalAttack; set => isHorizontalAttack = value; }
    }
}
