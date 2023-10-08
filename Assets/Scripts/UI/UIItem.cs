using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class UIItem : MonoBehaviour
    {
        private ItemSO _itemSO;
        [SerializeField] private GameObject particle1, particle2;
        [SerializeField] private Image _itemIcon;
        [SerializeField] private Image _itemQuality;
        [SerializeField] private List<Sprite> _qualityStar = new();

        public void SetItem(ItemSO itemSO)
        {
            _itemSO = itemSO;
            _itemIcon.sprite = itemSO._itemIcon;
            _itemQuality.enabled = true;
            switch (itemSO._tier)
            {
                case ItemTier.Normal:
                    _itemQuality.enabled = false;
                    break;
                case ItemTier.Bronze:
                    _itemQuality.sprite = _qualityStar[0];
                    break;
                case ItemTier.Silver:
                    _itemQuality.sprite = _qualityStar[1];
                    break;
                case ItemTier.Gold:
                    _itemQuality.sprite = _qualityStar[2];
                    break;
                case ItemTier.Purple:
                    _itemQuality.sprite = _qualityStar[3];
                    break;
            }
        }
    }
}
