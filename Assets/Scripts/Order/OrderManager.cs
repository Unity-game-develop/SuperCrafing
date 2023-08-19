using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class OrderManager : MonoBehaviour
    {
        ItemSO currentOrderItem;
        private List<ItemSO> orderItems = new List<ItemSO>();

        // Start is called before the first frame update
        void Start()
        {
            UIManager.Instance._onOrderAcceptBtnPress += OnAcceptOrder;
            Invoke(nameof(CreateNewOrder), 3f);
        }

        public void CreateNewOrder()
        {
            currentOrderItem = ItemMaster.RandomItem();
            string customerSentence = $"Give me <color=#F80000>{currentOrderItem._itemName}</color>. I will pay you <color=#FDD000>{currentOrderItem._itemPrice + UnityEngine.Random.Range(0, 10)} gold</color> ";
            UIManager.Instance.CreateCustomerOrder(customerSentence, currentOrderItem);
        }

        public void OnAcceptOrder()
        {
            orderItems.Add(currentOrderItem);
            UIManager.Instance.UpdateUIOrder(orderItems);
        }
    }

}
