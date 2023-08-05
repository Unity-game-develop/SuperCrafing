using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private List<InventorySlot> _inventorySlots = new List<InventorySlot>();

        public void AddToInventory(ItemSO item, int quantity = 1)
        {
            int returnQuantity = quantity;
            foreach(var slot in GetStackableSlot(item))
            {
                slot.AddTosSlot(returnQuantity, out returnQuantity);
            }

            // Go through all stackable slots
            if(returnQuantity > 0)
            {
                InventorySlot newSlot = new InventorySlot();
                newSlot.SetItemAndQuantity(item, returnQuantity);
            }
        }

        private List<InventorySlot> GetStackableSlot(ItemSO item)
        {
            return _inventorySlots.Where(x => x.GetIcon() == item && x.isStackAble == true).ToList();
        }
    }

}
