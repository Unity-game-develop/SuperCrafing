using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace Game
{
    public class CraftingNewItem : MonoBehaviour
    {
        [SerializeField] private Image _newItemIcon;
        [SerializeField] private Transform _spawnPos, _endPos;

        void Awake()
        {
        }

        public void CreateNewItem (Sprite icon)
        {
            _newItemIcon.sprite = icon;
            this.transform.localScale = Vector3.zero;
            this.transform.DOScale(3, 1.5f).SetEase(Ease.OutBounce);
            NOOD.NoodyCustomCode.StartDelayFunction(() =>
            {
                this.transform.DOMove(_endPos.position, 2f).SetEase(Ease.InOutCirc);
                this.transform.DOScale(2, 2f).SetEase(Ease.Flash);
            }, 2f);
        }
    }

}
