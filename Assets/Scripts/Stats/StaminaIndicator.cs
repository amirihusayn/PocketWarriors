using System;
using System.Collections;
using UnityEngine;

[Serializable]
public class StaminaIndicator
{
    // Fields
    [SerializeField] private float minHeight, maxHeight;
    [SerializeField] private Transform indicatorTransform;
    private float currentHeight;

    // Properties
    public float CurrentHeight { get => currentHeight; set => currentHeight = value; }

    // Methods
    public void InitializeIndicator()
    {
        currentHeight = maxHeight;
        SetCurrentHeight();
    }

    public void Update(float updatedCurrentStamina, float maxStamina)
    {
        if(maxStamina == 0)
            return;
        float currentHealthPercentage = (updatedCurrentStamina / maxStamina) * 100;
        float totalHeight = maxHeight - minHeight;
        currentHeight = (currentHealthPercentage * totalHeight) / 100;
        currentHeight += minHeight;
        SetCurrentHeight();
    }

    public void SetCurrentHeight()
    {
        indicatorTransform.GetComponent<SmoothTransform>().LocalTargetPosition = 
            new Vector3(indicatorTransform.localPosition.x, currentHeight, indicatorTransform.localPosition.z);
    }

    public void SetCurrentHeight(float updatedHeight)
    {
        currentHeight = updatedHeight;
        SetCurrentHeight();
    }

    private IEnumerator LerpHeight()
    {
        Vector3 targetPosition = 
            new Vector3(indicatorTransform.localPosition.x, currentHeight, indicatorTransform.localPosition.z);
        while(Vector3.Distance(indicatorTransform.localPosition, targetPosition) > 0.05f)
        {
            indicatorTransform.localPosition = 
                Vector3.Lerp(indicatorTransform.localPosition, targetPosition, 0.1f);
            yield return null;
        }
    }
}
