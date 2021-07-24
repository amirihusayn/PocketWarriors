using UnityEngine;

namespace PocketWarriors
{
    public class AddItemListner : ListnerPrototype
    {
        // Fields________________________________________________________
        [SerializeField] private GameObject item, layout;

        // Methods_____________________________________________________
        protected override void OnClickListner()
        {
            if(item == null)
                return;
            GameObject.Instantiate(item, layout.GetComponent<RectTransform>());
        }
    }
}