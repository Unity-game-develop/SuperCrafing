using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Game
{
    public class UIOrderElement : MonoBehaviour
    {
        [SerializeField] private Image _icon;
        [SerializeField] private TextMeshProUGUI  _nameText;
        [SerializeField] private TextMeshProUGUI _moneyText;

        public void SetOrderItem(ItemSO item)
        {
            _icon.sprite = item._itemIcon;
            _nameText.text = item._itemName;
            _moneyText.text = item._price.ToString();
        }
    }

}
