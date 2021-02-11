using System.Collections.Generic;
using rav3d.Model;
using Zenject;

namespace rav3d
{
    public class ItemTransaction: BaseTransaction
    {
        [Inject] private readonly IInventory inventory = null;

        private Item itemData;
        private bool actionType;

        public void SetData(Item data, bool added)
        {
            itemData = data;
            actionType = added;
        }
        protected override void ClassSpecificExecute()
        {
            if (actionType)
            {
                inventory.AddItem(itemData);
            }
            else
            {
                inventory.RemoveItem(itemData);
            }
            
            var data = new Dictionary<string, string>();
            data["id"] = itemData.Id.ToString();
            data["action"] = actionType ? "add" : "remove";
            
            NetworkController.SendEvent(data);
        }
    }
}