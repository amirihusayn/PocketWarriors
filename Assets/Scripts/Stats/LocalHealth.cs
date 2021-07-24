using System;
using UnityEngine;

namespace PocketWarriors
{
    public class LocalHealth : MonoBehaviour, IState<short>, IHealth<short>
    {
        // Fields________________________________________________________
        [SerializeField] private WarriorStats stats;
        [SerializeField] private HealthIndicator healthIndicator;
        private short currentState, maxState;
        public Action<short> OnCurrentHealthChanged;
        public Action OnDie;

        // Properties___________________________________________________
        public short CurrentState
        {
            get => currentState;
            private set
            {
                UpdateState(value);
            }
        }
        public short MaxState { get => maxState; private set => maxState = value; }
        public IIndicator<short> Indicator { get => healthIndicator; }

        // Methods_____________________________________________________
        public void UpdateState(short updatedState)
        {
            if (updatedState > MaxState)
                currentState = MaxState;
            else if (updatedState <= 0)
            {
                currentState = 0;
                if (OnDie != null)
                    OnDie();
            }
            else
                currentState = updatedState;
            if (OnCurrentHealthChanged != null)
                OnCurrentHealthChanged(currentState);
        }

        private void Start()
        {
            if (!GameController.Instance.IsGameLocal)
                return;
            InitializeActions();
            InitializeState();
            Indicator.InitializeIndicator();
        }

        public void InitializeActions()
        {
            OnCurrentHealthChanged += UpdateIndicator;
            OnDie += Die;
        }

        public void UpdateIndicator(short updatedState)
        {
            Indicator.UpdateIndicator(updatedState, MaxState);
        }

        public void Die()
        {
            int xValue = UnityEngine.Random.Range(-5, 5);
            int yValue = 5;
            int zValue = UnityEngine.Random.Range(-5, 5);
            gameObject.SetActive(false);
            transform.position = new Vector3(xValue, yValue, zValue);
            gameObject.SetActive(true);
            CurrentState = MaxState;
        }

        public void InitializeState()
        {
            MaxState = (short)stats.MaxHealth;
            CurrentState = (short)stats.MaxHealth;
        }

        private void OnTriggerEnter(Collider other) 
        {
            if(!GameController.Instance.IsGameLocal)
                return;
            TakeDamage(other);
        }

        public void TakeDamage(Collider other)
        {
            WeaponHold weaponHold = other.GetComponent<WeaponHold>();
            if(weaponHold == null || weaponHold.WarriorID == gameObject.GetInstanceID())
                return;
            CurrentState -= (short)weaponHold.Damage;
        }
    }
}
