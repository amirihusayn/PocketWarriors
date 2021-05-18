using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonListner : MonoBehaviour
{
    // Fields
    [SerializeField] private ListnerContainer.ListnerType listnerType;
    private Button button;

    // Methods
    private void Awake() 
    {
        AddOnClickListner();
    }

    private void AddOnClickListner()
    {
        ListnerPrototype listnerObject = ListnerContainer.GetListner(listnerType);
        button = GetComponent<Button>();
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(delegate { listnerObject.OnClickListner(this);});
    }
}