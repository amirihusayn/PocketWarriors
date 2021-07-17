using System;
using System.Collections;
using UnityEngine;

[Serializable]
public class StaminaIndicator : IIndicator<float>
{
    // Fields
    [SerializeField] private float minHeight, maxHeight;
    [SerializeField] private Transform indicatorTransform;
    private float currentHeight;

    // Properties
    public float CurrentValue { get => currentHeight; set => currentHeight = value; }

    // Methods
    public void InitializeIndicator()
    {
        currentHeight = maxHeight;
        SetCurrentValue();
    }

    public void UpdateIndicator(float updatedState, float maxState)
    {
        if(maxState == 0)
            return;
        float currentHealthPercentage = (updatedState / maxState) * 100;
        float totalHeight = maxHeight - minHeight;
        currentHeight = (currentHealthPercentage * totalHeight) / 100;
        currentHeight += minHeight;
        SetCurrentValue();
    }

    public void SetCurrentValue()
    {
        indicatorTransform.GetComponent<SmoothTransform>().LocalTargetPosition = 
            new Vector3(indicatorTransform.localPosition.x, currentHeight, indicatorTransform.localPosition.z);
    }

    public void SetCurrentValue(float updatedHeight)
    {
        currentHeight = updatedHeight;
        SetCurrentValue();
    }
}
