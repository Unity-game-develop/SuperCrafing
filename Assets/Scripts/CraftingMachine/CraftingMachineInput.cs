using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game
{
    public class CraftingMachineInput : MonoBehaviour, IDropHandler
    {

        public void OnDrop(PointerEventData eventData)
        {
            // Debug.Log("OnDrop");
            ItemSO inputItem = MouseHolder.Instance.GetItem();

            CraftingManager.Instance.SetItem(inputItem);
            InventoryManager.Instance.RemoveFromInventory(MouseHolder.Instance.GetItemSlotIndex());
        }
    }
}