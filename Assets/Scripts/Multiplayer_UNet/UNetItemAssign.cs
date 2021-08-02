using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace PocketWarriors
{
    public class UNetItemAssign : NetworkBehaviour, IItemAssign
    {
        // Fields________________________________________________________
        [SerializeField] private List<ItemContainer> ContainersList;
        private List<ItemAnchor> anchorsList;
        private Dictionary<ItemContainer.ItemTypes, ItemContainer> containersDic;
        private Dictionary<ItemContainer.ItemTypes, ItemAnchor> anchorsDic;

        private ItemAnchor anchor;
        private GameObject targetItemPrefab;

        // Properties___________________________________________________
        public Dictionary<ItemContainer.ItemTypes, ItemContainer> ContainersDic { get => containersDic; }
        public Dictionary<ItemContainer.ItemTypes, ItemAnchor> AnchorsDic { get => anchorsDic; }

        // Methods_____________________________________________________
        private void Awake()
        {
            Initialize();
            if(!isLocalPlayer)
                return;
            AssignItems();
        }

        private void Initialize()
        {
            anchorsList = new List<ItemAnchor>(GetComponentsInChildren<ItemAnchor>());
            containersDic = new Dictionary<ItemContainer.ItemTypes, ItemContainer>();
            anchorsDic = new Dictionary<ItemContainer.ItemTypes, ItemAnchor>();
            foreach (ItemContainer container in ContainersList)
                containersDic.Add(container.ItemType, container);
            foreach (ItemAnchor anchor in anchorsList)
                anchorsDic.Add(anchor.ItemType, anchor);
        }

        public void AssignItems()
        {
            int itemIndex;
            ItemContainer container;
            GameObject targetItemPrefab;
            foreach (ItemContainer.ItemTypes itemType in anchorsDic.Keys)
            {
                if (PlayerPrefs.HasKey(itemType.ToString()))
                    itemIndex = PlayerPrefs.GetInt(itemType.ToString());
                else
                {
                    itemIndex = 0;
                    PlayerPrefs.SetInt(itemType.ToString(), itemIndex);
                } 
                anchorsDic.TryGetValue(itemType, out anchor);
                containersDic.TryGetValue(itemType, out container);
                if (anchor != null && container != null)
                {
                    targetItemPrefab = container.GetItem(ref itemIndex);
                    CmdAssign();
                }
            }
        }

        [Command]
        private void CmdAssign()
        {
            anchor.CreateItem(targetItemPrefab); // when running this targetItemPrefab in server is null
            NetworkServer.Spawn(anchor.Item);
        }
    }
}