using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NOOD;
using NOOD.Data;

namespace Game
{
    public class StoreStack
    {
        public ItemSO _item;
        public int _quantity;

        public StoreStack(ItemSO item, int quantity)
        {
            _item = item;
            _quantity = quantity;
        }
    }

    public class StoreManager : MonoBehaviorInstance<StoreManager>
    {
        private List<StoreStack> _storeItems = new();

        void Start()
        {
            Refresh();
        }

        public bool Buy(int index)
        {
            if(DataManager<PlayerData>.Data.money < _storeItems[index]._item._itemPrice || _storeItems[index]._quantity <= 0)
            {
                Debug.Log("Money: " + DataManager<PlayerData>.Data.money);
                Debug.Log("Price: " + _storeItems[index]._item._itemPrice);
                Debug.Log("Quantity: " + _storeItems[index]._quantity);
                return false;
            }
            else
            {
                Debug.Log("Buy" + index);
                _storeItems[index]._quantity -= 1;

                ItemSO resultItem = _storeItems[index]._item;
                InventoryManager.Instance.AddToInventory(resultItem);

                DataManager<PlayerData>.Data.money -= resultItem._itemPrice;
                DataManager<PlayerData>.QuickSave();
                UIStore.Instance.UpdateUI(_storeItems);
                return true;
            }
        }

        public void Refresh()
        {
            for(int i = 0; i < 10; i++)
            {
                _storeItems.Add(new StoreStack(ItemMaster.RandomMaterial(), UnityEngine.Random.Range(4, 10)));

            }
            UIStore.Instance.UpdateUI(_storeItems);
        }
    }
}
