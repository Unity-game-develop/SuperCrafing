using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Game
{
    public class UIItemElement : MonoBehaviour
    {
        protected ItemSO _item;
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
        }

        public void Show()
        {
        }
    }
}
