using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaCost : StateMachineBehaviour
{
   // Fields________________________________________________________
   [SerializeField] private short staminaCost;
   [SerializeField] private bool isCostInOnStateEnter, isCostInOnStateUpdate, isCostInOnStateExit;
   private IStamina<short> staminaComponent;

   // Methods_____________________________________________________
   public void InitializeStaminaCostBehaviour(IStamina<short> staminaComponent) 
   {
      this.staminaComponent = staminaComponent;
   } 

   override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
   {
      if(!isCostInOnStateEnter)
         return;
      if(!animator.GetBool("isSpectral"))
         staminaComponent.ConsumeStamina(staminaCost);
      base.OnStateEnter(animator, stateInfo, layerIndex);
   }

   override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
   {
      if(!isCostInOnStateUpdate)
         return;
      if(!animator.GetBool("isSpectral"))
         staminaComponent.ConsumeStamina(staminaCost);
      base.OnStateUpdate(animator, stateInfo, layerIndex);
   }

   override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
   {
      if(!isCostInOnStateExit)
         return;
      if(!animator.GetBool("isSpectral"))
         staminaComponent.ConsumeStamina(staminaCost);
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
