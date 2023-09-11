using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using NOOD;

namespace Game
{
    [Serializable]
    public class Inventory 
    {
        [SerializeField] private List<InventorySlot> _inventorySlots = new List<InventorySlot>();

        public List<InventorySlot> InventorySlots => _inventorySlots;

        public void AddToInventory(ItemSO item, int quantity = 1)
        {
            int returnQuantity = quantity;
            foreach(var slot in GetAddableSlot(item))
            {
                slot.AddTosSlot(item, returnQuantity, out returnQuantity);
            }

            // Go through all stackable slots
            if(returnQuantity > 0)
            {
                InventorySlot newSlot = new InventorySlot();
                newSlot.SetItemAndQuantity(item, returnQuantity);
                _inventorySlots.Add(newSlot);
            }
        }

        public void RemoveFromInventory(int slotIndex, int quantity = 1)
        {
            if(_inventorySlots[slotIndex].Quantity <= 0) return;

            _inventorySlots[slotIndex].Quantity -= quantity;
            if(_inventorySlots[slotIndex].Quantity <= 0) 
            {
                _inventorySlots[slotIndex].SetItem(null);
            }
        }

        private List<InventorySlot> GetAddableSlot(ItemSO item)
        {
            return _inventorySlots.Where(x => x.GetItem() == item && x.isStackable == true || 
            x.isEmpty == true).ToList();
        }
    }

}
