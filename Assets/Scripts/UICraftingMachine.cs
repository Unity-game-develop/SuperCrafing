using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game
{
    public class UICraftingMachine : MonoBehaviour, IDropHandler
    {
        [SerializeField] private CraftingMachine _craftingMachine;

        public void OnDrop(PointerEventData eventData)
        {
            // Debug.Log("OnDrop");
            ItemSO inputItem = MouseHolder.Instance.GetItem();

            _craftingMachine.SetItem(inputItem);
        }
    }
}