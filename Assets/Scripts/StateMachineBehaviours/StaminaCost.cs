using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PocketWarriors
{
   public class StaminaCost : StateMachineBehaviour
   {
      // Fields________________________________________________________
      [SerializeField] private short animationStaminaCost;
      private short staminaCost;
      [SerializeField] private ItemContainer.ItemTypes itemType;
      [SerializeField] private bool costWhenHasItem, isCostInOnStateEnter, isCostInOnStateUpdate, isCostInOnStateExit;
      private IStamina<short> staminaComponent;

      // Methods_____________________________________________________
      public void InitializeStaminaCostBehaviour(IStamina<short> staminaComponent, IItemAssign itemAssign) 
      {
         float cost = (float) animationStaminaCost;
         this.staminaComponent = staminaComponent;
         ItemAnchor anchor = itemAssign.AnchorsDic[itemType];
         ItemBehaviour itemBehaviour = anchor.GetComponentInChildren<ItemBehaviour>();
         if(itemBehaviour != null)
            cost *= itemBehaviour.AnimationStaminaCostRate;
         else if(costWhenHasItem)
            cost = 0;
         staminaCost = (short) cost;
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
}
