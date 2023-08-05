using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "ItemSO")]
    public class ItemSO : ScriptableObject
    {
        public Sprite _itemIcon;
        public string _itemName;
        public string _itemDescription;
    }

}
