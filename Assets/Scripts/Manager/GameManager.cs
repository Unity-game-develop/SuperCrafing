using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NOOD;
using NOOD.Sound;

namespace Game
{
    public class GameManager : MonoBehaviorInstance<GameManager>
    {
        void Awake() 
        {
            GameControlSystem.Init();
        }

        // Update is called once per frame
        void Update()
        {
            if(Input.GetKeyDown(KeyCode.M))
            {
                PlayerDataManager.Instance.AddMoney(100);
            }
            if(Input.GetKeyDown(KeyCode.Space))
            {
            }
        }
    }

}
