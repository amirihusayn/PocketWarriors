using UnityEngine;

namespace PocketWarriors
{
    public class AddUIElement : ListnerPrototype
    {
        // Fields________________________________________________________
        [SerializeField] private GameObject element, layout;

        // Methods_____________________________________________________
        protected override void OnClickListner()
        {
            if(element == null)
                return;
            GameObject.Instantiate(element, layout.GetComponent<RectTransform>());
        }
    }
}