using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private List<ItemSO> defaultItem = new List<ItemSO>();
        [SerializeField] private List<InventorySlot> _inventorySlots = new List<InventorySlot>();
        [SerializeField] private UIInventory _uiInventory;

        void Start()
        {
            foreach(var item in defaultItem)
            {
                AddToInventory(item);
            }
        }

        void Update()
        {
            if(Input.GetKeyDown(KeyCode.A))
            {
                RemoveFromInventory(0);
            }

            if(Input.GetKeyDown(KeyCode.B))
            {
                foreach(var item in defaultItem)
                {
                    AddToInventory(item);
                }
            }
        }

        public void AddToInventory(ItemSO item, int quantity = 1)
        {
            int returnQuantity = quantity;
            foreach(var slot in GetStackableSlot(item))
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

            UpdateUI();
        }

        public void RemoveFromInventory(int slotIndex, int quantity = 1)
        {
            if(_inventorySlots[slotIndex].Quantity == 0) return;
            _inventorySlots[slotIndex].Quantity -= quantity;

            UpdateUI();
        }

        private List<InventorySlot> GetStackableSlot(ItemSO item)
        {
            return _inventorySlots.Where(x => x.GetItem() == item && x.isStackable == true || 
            x.GetItem() == item && x.isResetItemable == true).ToList();
        }

        public void UpdateUI()
        {
            _uiInventory.UpdateUI(_inventorySlots);
        }
    }

}
