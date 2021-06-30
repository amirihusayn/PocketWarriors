using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

public static class ListnerContainer
{
    // Fields
    public enum ListnerType {ChangeItem, AddItem};
    private static Dictionary<ListnerType,ListnerPrototype> listnerDic;

    // Methods
    private static void InitilaizeListners()
    {
        listnerDic = new Dictionary<ListnerType, ListnerPrototype>();
        var allListnerAssemblies = Assembly.GetAssembly(typeof(ListnerPrototype));
        var listners = allListnerAssemblies.GetTypes().Where(
            thisListnerType => typeof(ListnerPrototype).IsAssignableFrom(thisListnerType)
            && thisListnerType != typeof(ListnerPrototype));
        foreach(var thisListner in listners)
        {
            ListnerPrototype newListner = Activator.CreateInstance(thisListner) as ListnerPrototype;
            listnerDic.Add(newListner.Type , newListner);
        }
    }

    public static ListnerPrototype GetListner(ListnerType type)
    {
        if(listnerDic != null)
            if(Enum.GetNames(typeof(ListnerType)).Length != listnerDic.Count)
                InitilaizeListners();
        else
            InitilaizeListners();
        InitilaizeListners();
        return listnerDic[type];
    }
}