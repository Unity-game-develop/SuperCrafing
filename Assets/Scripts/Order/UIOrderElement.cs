using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

namespace Game
{
    public class UIOrderElement : UIElement, IDropHandler
    {
        [SerializeField] private TextMeshProUGUI  _nameText;

        public void OnDrop(PointerEventData eventData)
        {
            ItemSO dropItem = MouseHolder.Instance.GetItem();
            if(dropItem == _item)
            {
                // Correct Item
                // Deliver successfully
                InventoryManager.Instance.RemoveFromInventory(MouseHolder.Instance.GetItemSlotIndex());
                PlayerDataManager.Instance.AddMoney(_item._itemPrice);
            }
        }

        public override void SetItem (ItemSO item)
        {
            _item = item;
            _icon.sprite = item._itemIcon;
            _nameText.text = item._itemName;
            _moneyText.text = item._itemPrice.ToString();
        }
    }

}
