using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace PocketWarriors
{
    public class ItemBehaviour : MonoBehaviour 
    {
        // Fields________________________________________________________
        [SerializeField] private float animationStaminaCostRate;
        [SerializeField] private short maxStaminaChange;
        [SerializeField] private short maxHealthChange;
        [SerializeField] private float footSpeedChange;
        [SerializeField] private float rotationSpeedChange;
        [SerializeField] private Vector3 position;
        
        // Properties___________________________________________________
        public float AnimationStaminaCostRate { get => animationStaminaCostRate; }
        public Vector3 Position { get => position; set => position = value; }

        // Methods_____________________________________________________
        private void OnEnable() 
        {
            IState<short> s = GetComponent<IHealth<short>>() as IState<short>;
            // s.
        }

        private void OnDisable() 
        {
            
        }

        private void PerformBehaviour()
        {
        }
    }

    #if UNITY_EDITOR
    [CustomEditor(typeof(ItemBehaviour))]
    public class ItemBehaviourEditor : Editor 
    {
        public override void OnInspectorGUI() 
        {
            ItemBehaviour script = target as ItemBehaviour;
            base.OnInspectorGUI();
            if(GUILayout.Button("Set Position"))
                script.Position = script.transform.localPosition;
        }
    }
    #endif
}