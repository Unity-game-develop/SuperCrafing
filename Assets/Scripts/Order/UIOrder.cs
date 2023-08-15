using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class UIOrder : MonoBehaviour
    {
        [SerializeField] private List<ItemSO> _defaultOrder;
        [SerializeField] private UIOrderElement _orderElementPref;
        [SerializeField] private Transform _orderElementParentTransform;
        [SerializeField] private List<UIOrderElement> _waitingOrder;

        void Start()
        {
            _orderElementPref.gameObject.SetActive(false);

            foreach(var order in _defaultOrder)
            {
                CreateOrder(order);
            }
        }

        public void CreateOrder(ItemSO item)
        {
            UIOrderElement newOrder = Instantiate(_orderElementPref, _orderElementParentTransform);
            newOrder.SetOrderItem(item);
            _waitingOrder.Add(newOrder);
            newOrder.gameObject.SetActive(true);
        }
    }

}
