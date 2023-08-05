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

        void Start()
        {
            Color color = Color.white;
            color.a = 0;
            _icon.color = color;
            _quantityText.text = "0";
        }

        public void SetInventoryUI(InventorySlot inventorySlot)
        {
            _icon.color = Color.white;
            this._icon.sprite = inventorySlot.GetIcon();
            this._quantityText.text = inventorySlot.GetQuantity().ToString();
        }
    }

}
