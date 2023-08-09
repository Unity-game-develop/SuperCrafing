using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Game
{
    [CreateAssetMenu(fileName = "ItemSO")]
    public class ItemSO : ScriptableObject
    {
        // [HideLabel] // Hide the default label
        [InlineEditor(InlineEditorModes.LargePreview)]
        public Sprite _itemIcon;
        public string _itemName;
        [TextArea(10, 15)]
        public string _itemDescription;
    }

}
