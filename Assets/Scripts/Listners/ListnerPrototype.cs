using UnityEngine;
using UnityEngine.UI;

namespace PocketWarriors
{
    [RequireComponent(typeof(Button))]
    public abstract class ListnerPrototype : MonoBehaviour
    {
        // Fields________________________________________________________
        protected Button button;

        // Methods_____________________________________________________
        protected abstract void OnClickListner();

        protected virtual void Awake() 
        {
            button = GetComponent<Button>();
            AddOnClickListner();
        }

        protected virtual void AddOnClickListner()
        {
            button.onClick.AddListener(delegate { OnClickListner(); });
        }

        protected virtual void OnDestroy() 
        {
            button.onClick.RemoveAllListeners();
        }

        protected void RemoveListners()
        {
            button.onClick.RemoveAllListeners();
        }
    }
}