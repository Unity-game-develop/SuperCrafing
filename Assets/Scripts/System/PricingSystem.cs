using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Game
{
    public class PricingSystem : MonoBehaviour
    {
        [SerializeField] private List<ItemSO> items;

        [Button(ButtonSizes.Large)]
        void StartPricing ()
        {
            foreach(var item in items)
            {
                string[] words = item._itemName.Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                int price = words.Length * 10;
                item._price = price;
            }
        }
    }

}
