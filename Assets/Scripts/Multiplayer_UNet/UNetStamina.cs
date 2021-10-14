using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

namespace PocketWarriors
{
    public class UNetStamina : NetworkBehaviour, IState<short>, IStamina<short>
    {
        // Fields________________________________________________________
        [SerializeField] private WarriorStats stats;
        [SerializeField] private StaminaIndicator staminaIndicator;
        [SerializeField] private float reloadTimeInSeconds;
        [SerializeField] private short increaseAmount;
        [SyncVar(hook = "UpdateState")] private short currentState;
        [SyncVar] private short maxState;
        [SyncVar(hook = "UpdateIndicator")] private short indicatorValue;
        public Action OnNoStamina;

        // Properties___________________________________________________
        public short CurrentState
        {
            get => currentState;
            private set
            {
                SetCurrentState(value);
            }
        }
        public short MaxState { get => maxState; private set => maxState = value; }
        public IIndicator<short> Indicator { get => staminaIndicator; }

        // Methods_____________________________________________________
        public void SetCurrentState(short updatedState)
        {
            if (updatedState > MaxState)
                currentState = MaxState;
            else if (updatedState <= 0)
                currentState = 0;
            else
                currentState = updatedState;
        }

        private void OnEnable() 
        {
            InitializeAllStaminaCosts();
            StopAllCoroutines();
            StartCoroutine("IncreaseStamina");
        }
        
        private void Start()
        {
            Indicator.InitializeIndicator();
            if (!isServer || GameController.Instance.IsGameLocal)
                return;
            InitializeActions();
            InitializeState();
            InitializeAllStaminaCosts();
            indicatorValue = Indicator.CurrentValue;
        }

        public void InitializeActions()
        {
        }

        private void InitializeAllStaminaCosts()
        {
            Animator animator = GetComponent<Animator>();
            StaminaCost []staminaCostArray = animator.GetBehaviours<StaminaCost>();
            foreach(StaminaCost thisStaminaCost in staminaCostArray)
                thisStaminaCost.InitializeStaminaCostBehaviour(this);
        } 
        
        public void InitializeState()
        {
            MaxState = (short) stats.MaxStamina;
            CurrentState = (short) stats.MaxStamina;
            StopAllCoroutines();
            StartCoroutine("IncreaseStamina");
        }

        private IEnumerator IncreaseStamina()
        {
            while(true)
            {
                yield return new WaitForSeconds(reloadTimeInSeconds);
                CurrentState += increaseAmount;
            }
        }

        public void UpdateState(short updatedState)
        {
            if(Indicator == null)
                return;
            Indicator.UpdateIndicator(updatedState, MaxState);
            indicatorValue = Indicator.CurrentValue;
        }

        public void UpdateIndicator(short updatedIndicatorValue)
        {
            if(Indicator == null)
                return;
            Indicator.SetCurrentValue(updatedIndicatorValue);
        }

        public void ConsumeStamina(short staminaAmount)
        {
            CurrentState -= staminaAmount;
        }
    }
}
