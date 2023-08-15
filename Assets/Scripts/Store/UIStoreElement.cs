using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Game
{
    public class UIStoreElement : MonoBehaviour
    {
        [SerializeField] private ItemSO _item;
        [SerializeField] private Image _icon;
        [SerializeField] private TextMeshProUGUI _priceText;
        public bool _isHasItem => _item != null;

        public void SetItem(ItemSO item)
        {
            _item = item;
            _icon.sprite = item._itemIcon;
            _priceText.text = item._price.ToString();
        }
    }

}
