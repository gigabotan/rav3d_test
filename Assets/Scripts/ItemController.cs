using System;
using System.Security.Cryptography.X509Certificates;
using rav3d.Model;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace rav3d
{
    public class ItemController : MonoBehaviour
    {
        [Inject] private readonly ITransactionController transactionController = null;
        [Inject] private readonly IInventory inventory = null;

        public Image Image = null;
        public ItemType ItemType;
        private Item itemData;

        private void OnEnable()
        {
            SetData(inventory.GetItemWithType(ItemType));
        }

        private void Update()
        {
            if (Input.GetMouseButtonUp(0))
            {
                if (RectTransformUtility.RectangleContainsScreenPoint(Image.GetComponent<RectTransform>(),
                    Input.mousePosition))
                {
                    DropItem();
                }
            }
        }

        private void DropItem()
        {
            Image.gameObject.SetActive(false);
            var trans = new ItemTransaction();
            trans.SetData(itemData, false);
            transactionController.StartTransaction(trans);
        }

        private void SetData(Item? data)
        {
            if (data != null)
            {
                Image.gameObject.SetActive(true);
                itemData = data.Value;
            }

        }
    }
}