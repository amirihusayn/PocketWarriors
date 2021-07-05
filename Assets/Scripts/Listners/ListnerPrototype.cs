using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public abstract class ListnerPrototype : MonoBehaviour
{
    // Fields
    protected Button button;

    // Methods
    protected abstract void OnClickListner();

    protected virtual void Awake() 
    {
        button = GetComponent<Button>();
        AddOnClickListner();
    }

    protected virtual void AddOnClickListner()
    {
        button.onClick.AddListener(delegate { OnClickListner(); });
    }

    protected virtual void OnDestroy() 
    {
        button.onClick.RemoveAllListeners();
    }
}