using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using UnityEngine;

public static class ListnerContainer
{
    // Fields
    public enum ListnerType {MenuButton};
    private static Dictionary<ListnerType,ListnerPrototype> listnerDic;

    // Methods
    private static void InitilaizeListners()
    {
        listnerDic = new Dictionary<ListnerType, ListnerPrototype>();
        var allListnerAssemblies = Assembly.GetAssembly(typeof(ListnerPrototype));
        var listners = allListnerAssemblies.GetTypes().Where(
            thisListnerType => typeof(ListnerPrototype).IsAssignableFrom(thisListnerType)
            && thisListnerType.IsAbstract == false);
        foreach(var thisListner in listners)
        {
            ListnerPrototype newListner = System.Activator.CreateInstance(thisListner) as ListnerPrototype;
            listnerDic.Add(newListner.Type , newListner);
        }
    }
    
    public static ListnerPrototype GetListner(ListnerType type)
    {
        if(Enum.GetNames(typeof(ListnerType)).Length != listnerDic.Count)
            InitilaizeListners();
        return listnerDic[type];
    }
}