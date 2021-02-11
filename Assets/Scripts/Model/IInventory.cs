using UnityEngine.Events;

namespace rav3d.Model
{
    
    [System.Serializable]
    public class InventoryEvent : UnityEvent<Item, bool>
    {
    }
    public interface IInventory
    {
        
        InventoryEvent InventoryChanged { get; }
        void AddItem(Item itemData);

        void RemoveItem(Item itemData);

        Item? GetItemWithType(ItemType itemType);
    }
}