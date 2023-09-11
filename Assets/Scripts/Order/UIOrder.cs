using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Game
{
    public class UIOrder : MonoBehaviour
    {
        [SerializeField] private List<ItemSO> _defaultOrder;
        [SerializeField] private UIOrderElement _orderElementPref;
        [SerializeField] private Transform _orderElementParentTransform;
        [SerializeField] private List<UIOrderElement> _waitingOrder;
        [SerializeField] private TextMeshProUGUI _orderLimitText;

        void Start()
        {
            _orderElementPref.gameObject.SetActive(false);

            foreach(var order in _defaultOrder)
            {
                AddToWaitingList(order);
            }

            _orderLimitText.text = 0 + "/" + OrderManager.Instance.OrderLimit;
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
                _waitingOrder[i].SetItem(waitingItemList[i]);
                _waitingOrder[i].gameObject.SetActive(true);
                _waitingOrder[i].Show();
            }

            _orderLimitText.text = OrderManager.Instance.CurrentOrderNumber + "/" + OrderManager.Instance.OrderLimit;
        }

        public void AddToWaitingList(ItemSO item)
        {
            UIOrderElement newOrder = Instantiate(_orderElementPref, _orderElementParentTransform);
            newOrder.gameObject.SetActive(true);
            newOrder.SetItem(item);
            newOrder.Show();
            _waitingOrder.Add(newOrder);
        }
    }

}
