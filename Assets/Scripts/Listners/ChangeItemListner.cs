using UnityEngine;

namespace PocketWarriors
{
    public class ChangeItemListner : ListnerPrototype 
    {
        // Fields________________________________________________________
        [SerializeField] private LocalItemAssign itemAssign;
        [SerializeField] private ItemContainer.ItemTypes itemType;
        [SerializeField] private int indexChangeStep;
        private int itemIndex;

        // Methods_____________________________________________________
        protected override void Awake()
        {
            base.Awake();
            itemIndex = 0;
            // assign itemAssign
        }

        protected override void OnClickListner()
        {
            itemIndex += indexChangeStep;
            ItemContainer container = itemAssign.ContainersDic[itemType];
            GameObject item = container.GetItem(ref itemIndex);
            itemAssign.AnchorsDic[itemType].CreateItem(item);
            PlayerPrefs.SetInt(itemType.ToString(), itemIndex);
        }
    }
}