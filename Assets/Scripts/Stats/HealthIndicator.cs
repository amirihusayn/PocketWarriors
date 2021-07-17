using System;
using UnityEngine;

[Serializable]
public class HealthIndicator
{
    // Fields
    [SerializeField] private Transform indicatorTransform;
    [SerializeField] private float minScale, maxScale;
    private float currentScale;

    // Properties
    public float CurrentScale { get => currentScale; set => currentScale = value; }

    // Methods
    public void InitializeIndicator()
    {
        currentScale = maxScale;
        SetCurrentScale();
    }

    public void Update(float updatedCurrentHealth, float maxHealth)
    {
        if(maxHealth == 0)
            return;
        float currentHealthPercentage = (updatedCurrentHealth / maxHealth) * 100;
        float totalScale =  (float)(Math.Pow(maxScale, 2f) - Math.Pow(minScale, 2f));
        float minScaleInPower2 =  (float)(Math.Pow(minScale, 2f));
        currentScale = (currentHealthPercentage * totalScale) / 100;
        currentScale += minScaleInPower2;
        currentScale = (float)Math.Sqrt(currentScale);
        SetCurrentScale();
    }

    public void SetCurrentScale()
    {
        indicatorTransform.GetComponent<SmoothTransform>().LocalTargetScale = 
            new Vector3(currentScale, indicatorTransform.localScale.y, currentScale);
    }

    public void SetCurrentScale(float updatedScale)
    {
        currentScale = updatedScale;
        SetCurrentScale();
    }
}
