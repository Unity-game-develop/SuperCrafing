using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Game
{
    [System.Serializable]
    public class InventorySlot 
    {
        [SerializeField] private ItemSO _item;
        [SerializeField] private int _quantity;
        [SerializeField] private int _maxQuantity = 20;
        public bool isStackable => _quantity < _maxQuantity;
        public bool isResetItemable => _quantity == 0;

        public int Quantity
        {
            get => _quantity;
            set 
            {
                _quantity = value;
            }
        }

        public void AddTosSlot(ItemSO item, int quantity, out int returnQuantity)
        {
            this._item = item;
            int stackableQuantity = _maxQuantity - _quantity;
            returnQuantity = Mathf.Clamp(quantity - stackableQuantity, 0, 20);
            _quantity += quantity - returnQuantity;
        }

        public void SetItemAndQuantity(ItemSO item, int quantity)
        {
            this._item = item;
            this._quantity = quantity;
        }

        public ItemSO GetItem()
        {
            return _item;
        }
        public Sprite GetIcon()
        {
            return _item._itemIcon;
        }
    }

}
