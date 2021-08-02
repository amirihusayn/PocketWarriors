using System.Collections.Generic;

namespace PocketWarriors
{
    public interface IItemAssign
    {
        Dictionary<ItemContainer.ItemTypes, ItemContainer> ContainersDic { get;}
        Dictionary<ItemContainer.ItemTypes, ItemAnchor> AnchorsDic { get;}
        void AssignItems();
    }
}