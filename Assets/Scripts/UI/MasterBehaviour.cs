using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MasterBehaviour : MonoBehaviour
{
    // Fields
    [SerializeField] private GameObject targetLayout, currentItem;
    [SerializeField] private List<ButtonBehaviour> buttonBehaviours;

    // Properties
    public GameObject TargetLayout { get => targetLayout; }
    public GameObject CurrentItem { get => currentItem; set => currentItem = value; }
}