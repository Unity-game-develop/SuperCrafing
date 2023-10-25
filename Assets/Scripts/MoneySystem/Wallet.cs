using System.Collections;
using System.Collections.Generic;
using NOOD.Data;
using TMPro;
using UnityEngine;

namespace Game
{
    public class Wallet : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _moneyText;
        private int _money;

        void Start()
        {
            _money = DataManager<PlayerData>.Data.money;
        }

        public void AddMoney(int amount)
        {
            _money += amount;
        }
        public bool SpendMoney(int amount)
        {
            if(_money > -500)
            {
                _money -= amount;
                return true;
            }
            else return false;
        }
        public void SaveMoney()
        {
            DataManager<PlayerData>.Data.money = _money;
            DataManager<PlayerData>.QuickSave();
        }
    }
}
