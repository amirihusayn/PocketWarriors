using System;
using UnityEngine;

[Serializable]
public class HealthIndicator
{
    // Fields
    [SerializeField] private float offsetFromCenter, defaultScale;
    [SerializeField] private Transform indicatorTransform;
    private float currentScale, maxScale;

    // Properties
    public float CurrentScale { get => currentScale; set => currentScale = value; }

    // Methods
    public void InitializeIndicator()
    {
        maxScale = defaultScale + offsetFromCenter; 
        currentScale = maxScale;
        SetCurrentScale();
    }

    public void Update(float updatedCurrentHealth, float maxHealth)
    {
        if(maxHealth == 0)
            return;
        float currentHealthPercentage = (updatedCurrentHealth / maxHealth) * 100;
        currentScale = (currentHealthPercentage * maxScale) / 100;
        SetCurrentScale();
    }

    public void SetCurrentScale()
    {
        indicatorTransform.localScale = 
            new Vector3(currentScale, indicatorTransform.localScale.y, currentScale);
    }

    public void SetCurrentScale(float updatedScale)
    {
        currentScale = updatedScale;
        SetCurrentScale();
    }
}
