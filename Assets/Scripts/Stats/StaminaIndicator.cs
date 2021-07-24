using System;
using System.Collections;
using UnityEngine;

namespace PocketWarriors
{
    [Serializable]
    public class StaminaIndicator : IIndicator<short>
    {
        // Fields________________________________________________________
        [SerializeField] private float minHeight, maxHeight;
        [SerializeField] private Transform indicatorTransform;
        private short currentHeight;

        // Properties___________________________________________________
        public short CurrentValue { get => currentHeight; set => currentHeight = value; }

        // Methods_____________________________________________________
        public void InitializeIndicator()
        {
            currentHeight = (short) maxHeight;
            SetCurrentValue();
        }

        public void UpdateIndicator(short updatedState, short maxState)
        {
            if(maxState == 0)
                return;
            float updatedStateAsFloat = (float) updatedState;
            float maxStateAsFloat = (float) maxState;
            float currentHealthPercentage = (float) (updatedStateAsFloat / maxStateAsFloat) * 100;
            float totalHeight = maxHeight - minHeight;
            float result = (float) (currentHealthPercentage * totalHeight) / 100;
            result += minHeight;
            currentHeight = (short) result;
            SetCurrentValue();
        }

        public void SetCurrentValue()
        {
            indicatorTransform.GetComponent<SmoothTransform>().LocalTargetPosition = 
                new Vector3(indicatorTransform.localPosition.x, currentHeight, indicatorTransform.localPosition.z);
        }

        public void SetCurrentValue(short updatedHeight)
        {
            currentHeight = updatedHeight;
            SetCurrentValue();
        }
    }
}
