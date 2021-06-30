using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonBehaviour : MonoBehaviour
{
    // Fields
    [SerializeField] private MasterBehaviour masterBehaviour;
    [SerializeField] private GameObject targetItem;
    [SerializeField] private ListnerContainer.ListnerType listnerType;
    [SerializeField] private ListnerPrototype listner = new AddItemListner();
    private Button button;

    // Properties
    public MasterBehaviour MasterBehaviour { get => masterBehaviour; set => masterBehaviour = value; }
    public GameObject TargetItem { get => targetItem; }

    // Methods
    private void Awake() 
    {
        button = GetComponent<Button>();
        AddOnClickListner();
    }

    private void AddOnClickListner()
    {
        ListnerPrototype listnerObject = ListnerContainer.GetListner(listnerType);
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(delegate { listnerObject.OnClickListner(this); });
    }

    private void OnDestroy() {
        button.onClick.RemoveAllListeners();
    }
}