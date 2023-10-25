using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using UnityEditor;

namespace Game
{
    public class UIOrderElement : UIItemElement, IDropHandler
    {
        [SerializeField] private TextMeshProUGUI  _nameText;
        [SerializeField] private UIItem _uiItem;

        public void OnDrop(PointerEventData eventData)
        {
            ItemSO dropItem = MouseHolder.Instance.GetItem();
            DeliverManager.DeliverItem(_item, dropItem);
        }

        public override void SetItem (ItemSO item)
        {
            _item = item;
            _uiItem.SetItem(item);
            _uiItem.PlayParticle(false);
            _nameText.text = item._itemName;
            _moneyText.text = MoneyManager.GetItemPrice(item).ToString();
        }
    }

}
