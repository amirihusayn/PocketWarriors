using System;
using UnityEngine;

[Serializable]
public class HealthIndicator : IIndicator<short>
{
    // Fields
    [SerializeField] private Transform indicatorTransform;
    [SerializeField] private float minScale, maxScale;
    private short currentScale;

    // Properties
    public short CurrentValue { get => currentScale; set => currentScale = value; }

    // Methods
    public void InitializeIndicator()
    {
        currentScale = (short) maxScale;
        SetCurrentValue();
    }

    public void UpdateIndicator(short updatedState, short maxState)
    {
        if(maxState == 0)
            return;
        float updatedStateAsFloat = (float) updatedState;
        float maxStateAsFloat = (float) maxState;
        float currentHealthPercentage = (float) (updatedStateAsFloat / maxStateAsFloat) * 100;
        float totalScale = (float) (Mathf.Pow(maxScale, 2f) - Math.Pow(minScale, 2f));
        float minScaleInPower2 = Mathf.Pow(minScale, 2f);
        float result = (float) (currentHealthPercentage * totalScale) / 100;
        result += minScaleInPower2;
        currentScale = (short) Math.Sqrt(result);
        SetCurrentValue();
    }

    public void SetCurrentValue()
    {
        indicatorTransform.GetComponent<SmoothTransform>().LocalTargetScale = 
            new Vector3((float)currentScale, indicatorTransform.localScale.y, (float)currentScale);
    }

    public void SetCurrentValue(short updatedValue)
    {
        currentScale = updatedValue;
        SetCurrentValue();
    }
}
