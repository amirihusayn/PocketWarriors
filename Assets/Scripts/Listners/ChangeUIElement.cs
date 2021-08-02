using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PocketWarriors
{
    public class ChangeUIElement : ListnerPrototype
    {
        // Fields________________________________________________________
        private static List<ChangeUIElement> availableInstances = new List<ChangeUIElement>();
        [SerializeField] private int filterID;
        [SerializeField] private GameObject layout;
        [SerializeField] private List<GameObject> currentElementList, nextElementList;

        // Methods_____________________________________________________
        protected override void Awake()
        {
            base.Awake();
            availableInstances.Add(this);
        }

        protected override void OnClickListner()
        {
            if(nextElementList.Count == 0 || currentElementList == nextElementList)
                return;
            if(currentElementList != null)
                foreach(GameObject item in currentElementList)
                    item.SetActive(false);
            if(nextElementList != null)
                foreach(GameObject item in nextElementList)
                    item.SetActive(true);  
            ChangeUIElement.UpdateCurrentItem(this);
        }

        public static void UpdateCurrentItem(ChangeUIElement executer)
        {
            foreach(ChangeUIElement listner in availableInstances)
                if(executer.filterID == listner.filterID)
                    listner.currentElementList = executer.nextElementList;
        }
    }
}                                                                                           