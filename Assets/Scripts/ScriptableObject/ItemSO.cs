using System.Collections;
using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Sirenix.OdinInspector;

namespace Game
{
    public enum ItemType
    {
        Material,
        item
    }
    public enum ItemTier
    {
        Normal,
        Bronze,
        Silver,
        Gold,
        Purple
    }

    [CreateAssetMenu(fileName = "ItemSO")]
    public class ItemSO : ScriptableObject
    {
        [InlineEditor(InlineEditorModes.LargePreview)]
        public Sprite _itemIcon;
        public string _itemName;
        public ItemType _itemType;
        public ItemTier _tier;
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
        public static ItemSO RandomMaterial()
        {
            ItemSO[] itemSOs = Resources.LoadAll<ItemSO>("ItemSO");
            List<ItemSO> materials = itemSOs.Where(x => x._itemType == ItemType.Material).ToList();
            return materials[UnityEngine.Random.Range(0, materials.Count)];
        }
    }
}
