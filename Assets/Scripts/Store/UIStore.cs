using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NOOD;

namespace Game
{
    public class UIStore : MonoBehaviorInstance<UIStore>
    {
        [SerializeField] private List<UIStoreElement> _uiStoreElements;
        [SerializeField] private UIStoreElement _elementPref;
        [SerializeField] private Transform _elementParentTransform;

        void Start() 
        {
            _uiStoreElements.Add(_elementPref);
        }

        public void Show()
        {
            
        }
        public void Hide()
        {

        }

        public void UpdateUI(List<StoreStack> storeStacks)
        {
            foreach(var element in _uiStoreElements)
            {
                element.gameObject.SetActive(false);
            }

            for(int i = 0; i < storeStacks.Count; i++)
            {
                UIStoreElement element;
                if(i > _uiStoreElements.Count - 1)
                {
                    element = CreateNewSlot();
                }
                else
                {
                    element = _uiStoreElements[i];
                }
                if(storeStacks[i]._quantity == 0)
                {
                    element.Hide();
                    continue;
                } 
                element.SetItem(storeStacks[i]._item);
                element.SetItemNumber(storeStacks[i]._quantity);
                element.SetIndex(i);
                element.gameObject.SetActive(true);
            }
        }

        public UIStoreElement CreateNewSlot()
        {
            UIStoreElement element = Instantiate(_elementPref, _elementParentTransform);
            element.gameObject.SetActive(true);
            element.Show();
            _uiStoreElements.Add(element);
            return element;
        }

        public void RemoveFromInventory(int slotIndex)
        {
        }
    }
}
