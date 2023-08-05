using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class UIInventory : MonoBehaviour
    {
        [SerializeField] private UIInventorySlot _slotPref;
        [SerializeField] private Transform _slotParentTransform;
        private List<UIInventorySlot> _uiInventorySlots = new List<UIInventorySlot>();
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
            UIInventorySlot slot = Instantiate(_slotPref, _slotParentTransform);
            _uiInventorySlots.Add(slot);
            slot.gameObject.SetActive(true);
        }

        public void UpdateUI(List<InventorySlot> inventorySlots)
        {
            for(int i = 0; i < inventorySlots.Count; i++)
            {
                if(i > _uiInventorySlots.Count - 1)
                {
                    CreateNewSlot();
                }
                _uiInventorySlots[i].SetInventoryUI(inventorySlots[i]);
            }
        }
    }
}

