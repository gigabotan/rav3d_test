using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace rav3d.Model
{
    public class Inventory: IInventory
    {
        public Dictionary<int, Item> items = new Dictionary<int, Item>();


        public InventoryEvent InventoryChanged { get; } = new InventoryEvent();

        public void AddItem(Item itemData)
        {
            items[itemData.Id] = itemData;
            InventoryChanged.Invoke(itemData, true);
        }

        public void RemoveItem(Item itemData)
        {
            items.Remove(itemData.Id);
            InventoryChanged.Invoke(itemData, false);
        }

        public Item? GetItemWithType(ItemType itemType)
        {
            foreach (var item in items.Values)
            {
                if (item.ItemType == itemType)
                {
                    return item;
                }
            }

            return null;
        }
    }
}