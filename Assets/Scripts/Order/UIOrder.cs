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
                AddToWaitingList(order);
            }
        }

        public void UpdateUI(List<ItemSO> waitingItemList)
        {
            foreach(var order in _waitingOrder)
            {
                order.gameObject.SetActive(false);
            }

            for(int i = 0; i < waitingItemList.Count; i++)
            {
                if(i > _waitingOrder.Count - 1)
                {
                    AddToWaitingList(waitingItemList[i]);
                    continue;
                }
                _waitingOrder[i].SetOrderItem(waitingItemList[i]);
                _waitingOrder[i].gameObject.SetActive(true);
            }
        }

        public void AddToWaitingList(ItemSO item)
        {
            UIOrderElement newOrder = Instantiate(_orderElementPref, _orderElementParentTransform);
            newOrder.SetOrderItem(item);
            _waitingOrder.Add(newOrder);
            newOrder.gameObject.SetActive(true);
        }
    }

}
