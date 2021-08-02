using System.Collections.Generic;
using UnityEngine;

namespace PocketWarriors
{
    public class ItemAnchor : MonoBehaviour 
    {
        // Fields________________________________________________________
        [SerializeField] private ItemContainer.ItemTypes itemType;
        private GameObject item;

        // Properties___________________________________________________
        public ItemContainer.ItemTypes ItemType { get => itemType; }
        public GameObject Item { get => item; }

        // Methods_____________________________________________________
        public void CreateItem(GameObject targetItemPrefab)
        {
            Vector3 position;
            if(item != null)
                Destroy(item);
            if(targetItemPrefab != null)
            {
                item = Instantiate(targetItemPrefab, Vector3.zero, Quaternion.identity, transform);
                position = targetItemPrefab.GetComponent<ItemBehaviour>().Position;
                item.transform.localPosition = position;
            }
        }
    }
}