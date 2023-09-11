using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using NOOD;

namespace Game
{
    public class PlayerUI : MonoBehaviorInstance<PlayerUI>
    {
        [SerializeField] private TextMeshProUGUI moneyText;

        public void UpdateMoney(int money)
        {
            moneyText.text = money.ToString();
        }
    }
}
