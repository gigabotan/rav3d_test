using System;
using System.Collections.Generic;
using rav3d.Model;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace rav3d
{
    public class BackpackController : MonoBehaviour
    {
        [Inject] private readonly ITransactionController transactionController = null;
        [Inject] private readonly IInventory inventory = null;
        
        public GameObject[] ItemSlots;
        private Dictionary<ItemType, ItemComponent> items = new Dictionary<ItemType, ItemComponent>();


        private void Awake()
        {
            inventory.InventoryChanged.AddListener(DropElement);
        }


        public void OnTriggerEnter(Collider other)
        {
            var itemComponent = other.GetComponent<ItemComponent>();
            if (itemComponent)
            {
                PickElement(itemComponent);
            }
        }

        public void DropElement(Item item, bool actionType)
        {
            if (!actionType && items.ContainsKey(item.ItemType))
            {
                items[item.ItemType].Drop();
                items.Remove(item.ItemType);
            }
        }

        public void PickElement(ItemComponent item)
        {
            if (item.ItemData.Id > ItemSlots.Length - 1)
            {
                Debug.Log("No slot for item");
                return;
            }
            
            item.gameObject.transform.parent = ItemSlots[item.ItemData.Id].transform;
            item.Pick();

            items[item.ItemData.ItemType] = item;

            var action = new ItemTransaction();
            action.SetData(item.ItemData, true);
            
            transactionController.StartTransaction(action);
        }
    }
}