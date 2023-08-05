using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEditor;

namespace Game
{
    public class ItemSOCreator : MonoBehaviour
    {
        public Sprite icon;
        public string itemName;
        public string itemDescription;

        [Button]
        public void GenerateItemSOFile()
        {
            ItemSO newItem = ScriptableObject.CreateInstance<ItemSO>();
            newItem._itemIcon = icon;
            newItem._itemName = itemName;
            newItem._itemDescription = itemDescription;
            string path = $"Assets/Scripts/ItemSO/{itemName}.asset";
            AssetDatabase.CreateAsset(newItem, path);
        }
    }

}
