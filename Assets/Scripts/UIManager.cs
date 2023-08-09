using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance;
        [SerializeField] private Button _craftBtn;
        public Action _craftRequest;


        void Awake()
        {
            if(Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
            else
                Destroy(this.gameObject);
        }

        void Start()
        {
            _craftBtn.onClick.AddListener(() => _craftRequest?.Invoke());
        }

    }

}
