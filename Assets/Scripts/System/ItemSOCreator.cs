using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEditor;

namespace Game
{
    public class ItemSOCreator : MonoBehaviour
    {
        [InlineEditor(InlineEditorModes.LargePreview)]
        [HideLabel] // Hide the default label
        public Sprite icon;
        public string itemName;
        [TextArea(10, 15)]
        public string itemDescription;

        [Button(ButtonSizes.Large), GUIColor(0, 1, 0)]
        public void GenerateItemSOFile()
        {
            ItemSO newItem = ScriptableObject.CreateInstance<ItemSO>();
            newItem._itemIcon = icon;
            newItem._itemName = itemName;
            newItem._itemDescription = itemDescription;
            string path = $"Assets/Resources/ItemSO/{itemName.ToString().Replace(" ", "")}.asset";
            AssetDatabase.CreateAsset(newItem, path);
        }
    }

}
