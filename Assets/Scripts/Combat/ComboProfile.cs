using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewComboProfile", menuName = "PocketWarriors/ComboProfile", order = 3)]
public class ComboProfile : ScriptableObject 
{
    // Fields________________________________________________________
    [SerializeField] private string name;
    [SerializeField] private List<Combo> comboList;

    // Properties___________________________________________________
    public List<Combo> ComboList { get => comboList;}
}