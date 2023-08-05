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
        Color color = Color.white;

        void Start()
        {
        }

        public void SetInventoryUI(InventorySlot inventorySlot)
        {
            this._icon.sprite = inventorySlot.GetIcon();
            this._quantityText.text = inventorySlot.Quantity.ToString();
            if(inventorySlot.Quantity == 0)
            {
                color.a = 0;
            }
            this._icon.color = color;
            Debug.Log(this._icon.color.a);
        }
    }

}
