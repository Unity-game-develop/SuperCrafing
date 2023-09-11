using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Game
{
    public class UIElement : MonoBehaviour
    {
        protected ItemSO _item;
        [SerializeField] protected Image _icon;
        [SerializeField] protected TextMeshProUGUI _quantityText, _moneyText;

        public virtual void SetItem(ItemSO item)
        {
            _item = item;
        }
        public ItemSO GetItem()
        {
            return _item;
        }

        public void Hide()
        {
            if(_icon == null) return;
            _icon.gameObject.SetActive(false);
        }
        public void Show()
        {
            if(_icon == null) return;
            _icon.gameObject.SetActive(true);
        }
    }
}
