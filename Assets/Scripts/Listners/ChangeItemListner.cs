using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PocketWarriors
{
    public class ChangeItemListner : ListnerPrototype
    {
        // Fields________________________________________________________
        private static List<ChangeItemListner> availableInstances = new List<ChangeItemListner>();
        [SerializeField] private int filterID;
        [SerializeField] private GameObject layout;
        [SerializeField] private List<GameObject> currentItem, nextItem;

        // Methods_____________________________________________________
        protected override void Awake()
        {
            base.Awake();
            availableInstances.Add(this);
        }

        protected override void OnClickListner()
        {
            if(nextItem.Count == 0 || currentItem == nextItem)
                return;
            if(currentItem != null)
                foreach(GameObject item in currentItem)
                    item.SetActive(false);
            if(nextItem != null)
                foreach(GameObject item in nextItem)
                    item.SetActive(true);  
            ChangeItemListner.UpdateCurrentItem(this);
        }

        public static void UpdateCurrentItem(ChangeItemListner executer)
        {
            foreach(ChangeItemListner listner in availableInstances)
                if(executer.filterID == listner.filterID)
                    listner.currentItem = executer.nextItem;
        }
    }
}                                                                                           