using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class DeliverManager
    {
        public static void DeliverItem(ItemSO orderItem, ItemSO deliverItem)
        {
            if (deliverItem._itemName == orderItem._itemName)
            {
                // Correct Item
                float bonusMoney = 0;
                // Check tier of the item, better tier, better money and reputation
                switch (deliverItem._itemTier)
                {
                    case ItemTier.Normal:
                        break;
                    case ItemTier.Bronze:
                        bonusMoney = 5;
                        break;
                    case ItemTier.Silver:
                        bonusMoney = 10;
                        break;
                    case ItemTier.Gold:
                        bonusMoney = 15;
                        break;
                    case ItemTier.Purple:
                        bonusMoney = 20;
                        break;
                }
                // Deliver successfully
                // Remove item from inventory
                InventoryManager.Instance.RemoveFromInventory(MouseHolder.Instance.GetItemSlotIndex());
                // Add money to money system
                Debug.Log("Deliver success: " + orderItem._itemName + bonusMoney);
            }
        }
    }
}
