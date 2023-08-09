using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEditor;

namespace Game
{
    public class RecipeSOCreator : MonoBehaviour
    {
        [InlineEditor]
        [BoxGroup("Input")]
        public ItemSO input1;
        [InlineEditor]
        [BoxGroup("Input")]
        public ItemSO input2;

        [PropertySpace]
        [InlineEditor]
        [BoxGroup("Output"), GUIColor(0, 0.5f, 0)]
        public ItemSO result;

        [Button(ButtonSizes.Large), GUIColor(0, 1, 0)]
        public void GenerateRecipe()
        {
            RecipeSO recipe = new RecipeSO();
            recipe.item1 = input1;
            recipe.item2 = input2;
            recipe.result = result;
            string path = $"Assets/Scripts/RecipeSO/Recipe{result.name.Replace(" ", "")}.asset";
            AssetDatabase.CreateAsset(recipe, path);
        }   
    }
}
