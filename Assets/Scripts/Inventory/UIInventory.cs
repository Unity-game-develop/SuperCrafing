using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NOOD;

namespace Game
{
    public class UIInventory : MonoBehaviorInstance<UIInventory>
    {
        [SerializeField] private UIInventorySlot _slotPref;
        [SerializeField] private Transform _slotHolder;
        private List<UIInventorySlot> _uiInventorySlots = new();
        private int defaultSlotNumber = 12;

        void Awake()
        {
            _slotPref.gameObject.SetActive(false);
            for(int i = 0; i < defaultSlotNumber; i++)
            {
                CreateNewSlot();
            }
        }

        void Start()
        {
        }

        private void CreateNewSlot()
        {
            UIInventorySlot slot = Instantiate(_slotPref, _slotHolder.transform);
            _uiInventorySlots.Add(slot);
            slot.gameObject.SetActive(true);
        }

        public void UpdateUI(List<InventorySlot> inventorySlots)
        {
            int index;
            for(int i = 0; i < inventorySlots.Count; i++)
            {
                if(i > _uiInventorySlots.Count - 1)
                {
                    CreateNewSlot();
                }
                index = i;
                _uiInventorySlots[i].SetInventoryUI(inventorySlots[index], index);
            }
        }
    }
}

