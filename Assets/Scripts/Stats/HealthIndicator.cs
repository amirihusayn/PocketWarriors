using System;
using UnityEngine;

[Serializable]
public class HealthIndicator : IIndicator<float>
{
    // Fields
    [SerializeField] private Transform indicatorTransform;
    [SerializeField] private float minScale, maxScale;
    private float currentScale;

    // Properties
    public float CurrentValue { get => currentScale; set => currentScale = value; }

    // Methods
    public void InitializeIndicator()
    {
        currentScale = maxScale;
        SetCurrentValue();
    }

    public void UpdateIndicator(float updatedState, float maxState)
    {
        if(maxState == 0)
            return;
        float currentHealthPercentage = (updatedState / maxState) * 100;
        float totalScale =  (float)(Math.Pow(maxScale, 2f) - Math.Pow(minScale, 2f));
        float minScaleInPower2 =  (float)(Math.Pow(minScale, 2f));
        currentScale = (currentHealthPercentage * totalScale) / 100;
        currentScale += minScaleInPower2;
        currentScale = (float)Math.Sqrt(currentScale);
        SetCurrentValue();
    }

    public void SetCurrentValue()
    {
        indicatorTransform.GetComponent<SmoothTransform>().LocalTargetScale = 
            new Vector3(currentScale, indicatorTransform.localScale.y, currentScale);
    }

    public void SetCurrentValue(float updatedValue)
    {
        currentScale = updatedValue;
        SetCurrentValue();
    }
}
