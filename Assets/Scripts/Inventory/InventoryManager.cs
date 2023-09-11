using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NOOD;

namespace Game
{
    public class InventoryManager : MonoBehaviorInstance<InventoryManager>
    {
        [SerializeField] List<ItemSO> defaultItems = new List<ItemSO>();

        private Inventory _inventory;

        void Start() 
        {
            foreach(var item in defaultItems)
            {
                AddToInventory(item);
            }
        }

        private void LoadInventory()
        {
            if (_inventory == null)
            {
                _inventory = new Inventory();
            }
        }

        public void CallUpdateUI()
        {
            UIInventory.Instance.UpdateUI(_inventory.InventorySlots);
        }

        public void AddToInventory(ItemSO item, int quantity = 1)
        {
            LoadInventory();
            _inventory.AddToInventory(item, quantity);
            CallUpdateUI();
        }

        public void RemoveFromInventory(int slotIndex, int quantity = 1)
        {
            LoadInventory();
            _inventory.RemoveFromInventory(slotIndex, quantity);
            CallUpdateUI();
        }
    }
}
