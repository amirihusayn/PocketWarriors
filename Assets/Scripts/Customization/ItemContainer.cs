using System.Collections.Generic;
using UnityEngine;

namespace PocketWarriors
{
    [CreateAssetMenu(fileName = "NewItemContainer", 
    menuName = "PocketWarriors/ItemContainer", order = 4)]
    public class ItemContainer : ScriptableObject 
    {
        // Fields________________________________________________________
        public enum ItemTypes { Body, Head, Eye, Bottom, RightHand, LeftHand};
        [SerializeField] private ItemTypes itemType;
        [SerializeField] private List<GameObject> itemsList;

        // Properties___________________________________________________
        public ItemTypes ItemType { get => itemType; }

        // Methods_____________________________________________________
        public GameObject GetItem(ref int index)
        {
            if(itemsList == null)
                return null;
            if(index < 0)
                index = itemsList.Count - 1;
            else if (index >= itemsList.Count)
                index = 0;
            return itemsList[index];
        }
    }
}