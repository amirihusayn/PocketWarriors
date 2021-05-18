using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewComboProfile", menuName = "PocketWarriors/ComboProfile", order = 3)]
public class ComboProfile : ScriptableObject 
{
    // Fields
    [SerializeField] private string name;
    [SerializeField] private List<Combo> comboList;

    // Properties
    public List<Combo> ComboList
    {
        get
        {
            return comboList;
        }
    }
}