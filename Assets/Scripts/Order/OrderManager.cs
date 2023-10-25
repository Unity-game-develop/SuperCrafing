using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NOOD;

namespace Game
{
    public class OrderManager : MonoBehaviorInstance<OrderManager>
    {
        ItemSO _currentOrderItem;
        private List<ItemSO> _orderItems = new();
        private int _orderLimit = 20;
        public int OrderLimit => _orderLimit;
        public int CurrentOrderNumber => _orderItems.Count;

        // Start is called before the first frame update
        void Start()
        {
            UIController.Instance._onOrderAcceptBtnPress += OnAcceptOrder;
            Invoke(nameof(CreateNewOrder), 3f);
        }

        public void CreateNewOrder()
        {
            _currentOrderItem = ItemMaster.RandomItem();
            string customerSentence = $"Give me <color=#F80000>{_currentOrderItem._itemName}</color>. I will pay you <color=#FDD000>{MoneyManager.GetItemPrice(_currentOrderItem) + UnityEngine.Random.Range(0, 10)} gold</color> ";
            UIController.Instance.CreateCustomerOrder(customerSentence, _currentOrderItem);
        }

        public void OnAcceptOrder()
        {
            if(CurrentOrderNumber == OrderLimit)
            {
                //TODO: Announce for player: Full order
            }
            else
            {
                _orderItems.Add(_currentOrderItem);
                UIController.Instance.UpdateUIOrder(_orderItems);
            }
        }
    }

}
