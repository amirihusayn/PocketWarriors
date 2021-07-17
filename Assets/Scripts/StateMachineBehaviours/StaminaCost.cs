using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaCost : StateMachineBehaviour
{
   // Fields
   [SerializeField] private float staminaCost;
   [SerializeField] private bool isCostInOnStateEnter, isCostInOnStateUpdate, isCostInOnStateExit;
   private bool isInitialized;
   private LocalStamina localStamina;

   // Methods
   private void InitializeStaminaCostBehaviour(Animator animator) 
   {
      if(!isInitialized)
         return;
      localStamina = animator.GetComponent<LocalStamina>();
      isInitialized = true;
   } 

   override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
   {
      if(!isCostInOnStateEnter)
         return;
      InitializeStaminaCostBehaviour(animator);
      if(!animator.GetBool("isSpectral"))
         animator.GetComponent<LocalStamina>().ConsumeStamina(staminaCost);
      base.OnStateEnter(animator, stateInfo, layerIndex);
   }

   override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
   {
      if(!isCostInOnStateUpdate)
         return;
      InitializeStaminaCostBehaviour(animator);
      if(!animator.GetBool("isSpectral"))
         animator.GetComponent<LocalStamina>().ConsumeStamina(staminaCost);
      base.OnStateUpdate(animator, stateInfo, layerIndex);
   }

   override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
   {
      if(!isCostInOnStateExit)
         return;
      InitializeStaminaCostBehaviour(animator);
      if(!animator.GetBool("isSpectral"))
         animator.GetComponent<LocalStamina>().ConsumeStamina(staminaCost);
      base.OnStateExit(animator, stateInfo, layerIndex);
   }

   override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
   {
      base.OnStateMove(animator, stateInfo, layerIndex);
   }

   override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
   {
      base.OnStateIK(animator, stateInfo, layerIndex);
   }
}
