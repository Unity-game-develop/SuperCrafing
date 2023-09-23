using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NOOD;
using NOOD.Data;

namespace Game
{
    public class PlayerDataManager : MonoBehaviorInstance<PlayerDataManager>
    {
        public void AddMoney(int amount)
        {
            DataManager<PlayerData>.Data.money += amount;
        }
    }
}
