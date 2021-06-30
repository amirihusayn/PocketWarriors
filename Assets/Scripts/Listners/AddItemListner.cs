using UnityEngine;

[System.Serializable]
public class AddItemListner : ListnerPrototype
{
    [SerializeField] private float aaa;
    // Properties
    public override ListnerContainer.ListnerType Type { get => ListnerContainer.ListnerType.AddItem; }

    // Methods
    public override void OnClickListner(ButtonBehaviour buttonBehaviour)
    {
        if(buttonBehaviour.TargetItem == null || buttonBehaviour.MasterBehaviour == null)
            return;
        GameObject targetItem = buttonBehaviour.TargetItem;
        GameObject targetLayout = buttonBehaviour.MasterBehaviour.TargetLayout;
        GameObject.Instantiate(targetItem);
        targetItem.GetComponent<RectTransform>().SetParent(targetLayout.GetComponent<RectTransform>());
    }
}