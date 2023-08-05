using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Game
{
    public class UIInventorySlot : MonoBehaviour
    {
        [SerializeField] private Image _icon;
        [SerializeField] private TextMeshProUGUI _quantityText;

        public void SetInventoryUI(InventorySlot inventorySlot)
        {
            this._icon.sprite = inventorySlot.GetIcon();
            this._quantityText.text = inventorySlot.GetQuantity().ToString();
        }
    }

}
