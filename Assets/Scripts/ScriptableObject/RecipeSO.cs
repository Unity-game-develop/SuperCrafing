using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Game
{
    [CreateAssetMenu(fileName = "RecipeSO")]
    public class RecipeSO : ScriptableObject
    {
        [InlineEditor]
        public ItemSO item1;
        [InlineEditor]
        public ItemSO item2;
        [InlineEditor]
        public ItemSO result;
    }
}
