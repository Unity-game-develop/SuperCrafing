using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using NOOD.Data;

namespace Game
{
    public class MoneyManager 
    {
        public static int GetItemPrice(ItemSO item)
        {
            int price = 0;
            if(item._itemType == ItemType.Material)
            {
                string[] words = item._itemName.Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                price = words.Length * 2;
                switch (item._itemTier)
                {
                    case ItemTier.Normal:
                        break;
                    case ItemTier.Bronze:
                        price += 1;
                        break;
                    case ItemTier.Silver:
                        price += 2;
                        break;
                    case ItemTier.Gold:
                        price += 3;
                        break;
                    case ItemTier.Purple:
                        price += 4;
                        break;
                }
            }
            else
            {
                string[] words = item._itemName.Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                price = words.Length * 10;
                switch (item._itemTier)
                {
                    case ItemTier.Normal:
                        break;
                    case ItemTier.Bronze:
                        price += 7;
                        break;
                    case ItemTier.Silver:
                        price += 12;
                        break;
                    case ItemTier.Gold:
                        price += 18;
                        break;
                    case ItemTier.Purple:
                        price += 25;
                        break;
                }
            }

            return price;
        }
    }
}
