using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class UIItem : MonoBehaviour
    {
        private ItemSO _itemSO;
        [SerializeField] private GameObject _particle1, _particle2;
        [SerializeField] private Image _itemIcon;
        [SerializeField] private Image _itemQuality;
        [SerializeField] private Sprite _bronzeStar, _silverStar, _goldStar, _purpleStar;

        private bool _isPlayParticle;

        void Start()
        {
        }

        void OnDisable()
        {
            _isPlayParticle = false;
        }

        public void SetItem(ItemSO itemSO)
        {
            _itemSO = itemSO;
            _itemIcon.sprite = itemSO._itemIcon;
            _itemQuality.enabled = true;
            switch (itemSO._itemTier)
            {
                case ItemTier.Normal:
                    _itemQuality.enabled = false;
                    break;
                case ItemTier.Bronze:
                    _itemQuality.sprite = _bronzeStar;
                    break;
                case ItemTier.Silver:
                    _itemQuality.sprite = _silverStar;
                    break;
                case ItemTier.Gold:
                    _itemQuality.sprite = _goldStar;
                    break;
                case ItemTier.Purple:
                    _itemQuality.sprite = _purpleStar;
                    break;
            }
        }

        public void PlayParticle(bool value)
        {
            _particle1.gameObject.SetActive(value);
            _particle2.gameObject.SetActive(value);
        }
    }
}
