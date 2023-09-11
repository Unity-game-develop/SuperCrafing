using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using NOOD;

namespace Game
{
    public class DragSystem : MonoBehaviorInstance<DragSystem>
    {
        [SerializeField] private GameObject _inventoryScrollView;
        private float _holdTimer;
        private float _holdDelay = 0.5f;

        PointerEventData data;

        // Update is called once per frame
        void Update()
        {
            
        }

        public void DragScrollView(GameObject oldObject, PointerEventData eventData)
        {
            ExecuteEvents.Execute<IEndDragHandler>(oldObject, eventData, ExecuteEvents.endDragHandler);
            eventData.pointerDrag = _inventoryScrollView;
            ExecuteEvents.Execute<IBeginDragHandler>(_inventoryScrollView, eventData, ExecuteEvents.beginDragHandler);
        }

        public void SetDragObject(GameObject oldObject, PointerEventData eventData, GameObject newObject)
        {
            ExecuteEvents.Execute<IEndDragHandler>(oldObject, eventData, ExecuteEvents.endDragHandler);
            eventData.pointerDrag = newObject;
            ExecuteEvents.Execute<IBeginDragHandler>(_inventoryScrollView, eventData, ExecuteEvents.beginDragHandler);
        }

        public PointerEventData GetEventData()
        {
            return data;
        }
    }

}
