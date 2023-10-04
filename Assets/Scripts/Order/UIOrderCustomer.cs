using NOOD;
using NOOD.Interface;
using DG.Tweening;
using UnityEngine;

namespace Game
{
    public class UIOrderCustomer : MonoBehaviorInstance<UIOrderCustomer>, INoodyUI
    {
        [SerializeField] private Transform _uiIn, _uiOut;

        public void Close()
        {
            this.transform.DOMove(_uiOut.position, 1f).SetEase(Ease.InOutCubic);
        }

        public void Open()
        {
            this.transform.DOMove(_uiIn.position, 1f).SetEase(Ease.InOutCubic);
        }
    }
}
