using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

namespace Game
{
    public class UIStoreElement : UIElement, IPointerClickHandler
    {
        public bool _isHasItem => _item != null;
        private int _quantity;
        private int _index;

        public override void SetItem(ItemSO item)
        {
            _item = item;
            _icon.sprite = item._itemIcon;
            _quantityText.text = _quantity.ToString();
        }
        public void SetItemNumber(int number)
        {
            _quantity = number;
            _quantityText.text = _quantity.ToString();
        }
        public void SetIndex(int number)
        {
            _index = number;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            Debug.Log("click");
            StoreManager.Instance.Buy(_index);
        }
    }

}
