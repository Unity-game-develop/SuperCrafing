using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class UIStore : MonoBehaviour
    {
        // [SerializeField] private UIStoreElement _elementPref;
        // [SerializeField] private Transform _elementParentTransform;
        [SerializeField] private List<UIStoreElement> _uiStoreElements;

        public void AddToInventory(ItemSO item)
        {
            foreach(UIStoreElement element in _uiStoreElements)
            {
                
            }
        }

        public void RemoveFromInventory(int slotIndex)
        {
        }
    }
}
