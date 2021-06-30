using UnityEngine;
                                                                                                    
[System.Serializable]
public class ChangeItemListner : ListnerPrototype
{
    // Properties
    public override ListnerContainer.ListnerType Type { get => ListnerContainer.ListnerType.ChangeItem; }

    // Methods
    public override void OnClickListner(ButtonBehaviour buttonBehaviour)
    {
        if(buttonBehaviour.MasterBehaviour == null || buttonBehaviour.TargetItem == null)
            return;
        GameObject targetItem = buttonBehaviour.TargetItem;
        GameObject targetLayout = buttonBehaviour.MasterBehaviour.TargetLayout;
        GameObject currentItem = buttonBehaviour.MasterBehaviour.CurrentItem;
        if(currentItem != null)
            GameObject.Destroy(currentItem);
        GameObject.Instantiate(targetItem);
        targetItem.GetComponent<RectTransform>().SetParent(targetLayout.GetComponent<RectTransform>());
        buttonBehaviour.MasterBehaviour.CurrentItem = targetItem;
    }
}