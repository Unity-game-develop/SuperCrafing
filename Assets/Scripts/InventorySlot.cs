using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Game
{
    [System.Serializable]
    public class InventorySlot 
    {
        private ItemSO _item;
        private int _quantity;
        private int _maxQuantity = 20;
        public bool isStackAble => _quantity < _maxQuantity;

        public void AddTosSlot(int quantity, out int returnQuantity)
        {
            int stackableQuantity = _maxQuantity - _quantity;
            returnQuantity = Mathf.Clamp(quantity - stackableQuantity, 0, 20);
            _quantity += quantity - returnQuantity;
        }

        public void SetItemAndQuantity(ItemSO item, int quantity)
        {
            this._item = item;
            this._quantity = quantity;
        }
        public void SetQuantity(int quantity)
        {
            this._quantity = quantity;
        }

        public Sprite GetIcon()
        {
            return _item._itemIcon;
        }
        public int GetQuantity()
        {
            return _quantity;
        }
    }

}
