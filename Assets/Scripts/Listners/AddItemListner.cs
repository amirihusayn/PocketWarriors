using UnityEngine;

public class AddItemListner : ListnerPrototype
{
    // Fields
    [SerializeField] private GameObject item, layout;

    // Methods
    protected override void OnClickListner()
    {
        if(item == null)
            return;
        GameObject.Instantiate(item, layout.GetComponent<RectTransform>());
    }
}