using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class TierSystem 
    {
        private static ModifiableStats<float> normalRate = new(40f);
        private static ModifiableStats<float> bronzeRate = new(30f);
        private static ModifiableStats<float> silverRate = new(17f);
        private static ModifiableStats<float> goldRate = new(11f); 
        private static ModifiableStats<float> purpleRate = new(2f);

        public static ItemTier RandomTier(ItemTier item1Tier, ItemTier item2Tier)
        {
            ModifyRate(item1Tier);
            ModifyRate(item2Tier);

            float randomTierValue = UnityEngine.Random.Range(0f, 100f);
            Debug.Log(randomTierValue);
            ItemTier outTier = ComputeItemTier(randomTierValue);

            normalRate.ClearAllModifiers();
            bronzeRate.ClearAllModifiers();
            silverRate.ClearAllModifiers();
            goldRate.ClearAllModifiers();
            purpleRate.ClearAllModifiers();
            return outTier;
        }

        private static ItemTier ComputeItemTier(float randValue)
        {
            ItemTier outTier = ItemTier.Normal;
            float[] tierValue = new float[]
            {
                normalRate.Value,
                bronzeRate.Value,
                silverRate.Value,
                goldRate.Value,
                purpleRate.Value
            };
            float value = 0;
            int i = 0;
            while(randValue >= value)
            {
                value += tierValue[i];
                i++;
            }
            switch(i)
            {
                case 1: 
                    outTier = ItemTier.Normal; 
                    break;
                case 2:
                    outTier = ItemTier.Bronze;
                    break;
                case 3:
                    outTier = ItemTier.Silver;
                    break;
                case 4:
                    outTier = ItemTier.Gold;
                    break;
                case 5:
                    outTier = ItemTier.Purple;
                    break;
                default:
                    outTier = ItemTier.Normal;
                    break;
            }
            return outTier;
        }

        private static void ModifyRate(ItemTier itemTier)
        {
            switch(itemTier)
            {
                case ItemTier.Bronze:
                    normalRate.AddModifier(ModifyType.Subtract, 7);
                    silverRate.AddModifier(ModifyType.Plus, 2);
                    bronzeRate.AddModifier(ModifyType.Plus, 5);
                    break;
                case ItemTier.Silver:
                    normalRate.AddModifier(ModifyType.Subtract, 10);
                    silverRate.AddModifier(ModifyType.Plus, 8);
                    goldRate.AddModifier(ModifyType.Plus, 2);
                    break;
                case ItemTier.Gold:
                    normalRate.AddModifier(ModifyType.Subtract, 15);
                    bronzeRate.AddModifier(ModifyType.Plus, 3);
                    silverRate.AddModifier(ModifyType.Plus, 3);
                    goldRate.AddModifier(ModifyType.Plus, 8);
                    purpleRate.AddModifier(ModifyType.Plus, 1);
                    break;
                case ItemTier.Purple:
                    normalRate.AddModifier(ModifyType.Subtract, 20);
                    bronzeRate.AddModifier(ModifyType.Plus, 3);
                    silverRate.AddModifier(ModifyType.Plus, 4);
                    goldRate.AddModifier(ModifyType.Plus, 5);
                    purpleRate.AddModifier(ModifyType.Plus, 8);
                    break;
            }

            Debug.Log("Normal Rate: " + normalRate.Value);
            Debug.Log("Bronze Rate: " + bronzeRate.Value);
            Debug.Log("Silver Rate: " + silverRate.Value);
            Debug.Log("Gold Rate: " + goldRate.Value);
            Debug.Log("Purple Rate: " + purpleRate.Value);

        }
    }
}
