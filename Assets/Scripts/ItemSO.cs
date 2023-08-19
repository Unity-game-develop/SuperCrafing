using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Sirenix.OdinInspector;

namespace Game
{
    [CreateAssetMenu(fileName = "ItemSO")]
    public class ItemSO : ScriptableObject
    {
        [InlineEditor(InlineEditorModes.LargePreview)]
        public Sprite _itemIcon;
        public string _itemName;
        [TextArea(10, 15)]
        public string _itemDescription;
        public int _itemPrice;
    }


    public static class ItemMaster
    {
        public static ItemSO RandomItem()
        {
            ItemSO[] itemSOs = Resources.LoadAll<ItemSO>("ItemSO");
            return itemSOs[UnityEngine.Random.Range(0, itemSOs.Length)];
        }
    }
}
