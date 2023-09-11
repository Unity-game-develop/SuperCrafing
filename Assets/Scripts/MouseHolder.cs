using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class MouseHolder : MonoBehaviour
    {
        public static MouseHolder Instance;
        private TempItem _tempItem;

        void Awake()
        {
            if(Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        public void SetTempItem(TempItem tempItem)
        {
            _tempItem = tempItem;
        }
        public ItemSO GetItem()
        {
            return _tempItem.itemSO;
        }
        public int GetItemSlotIndex()
        {
            return _tempItem.slotIndex;
        }
    }
}
