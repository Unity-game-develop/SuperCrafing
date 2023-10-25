using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

namespace Game
{
    public struct TempItem
    {
        public int slotIndex;
        public ItemSO itemSO;
        public int quantity;
    }

    public class UIInventorySlot : UIItemElement, IDragHandler, IBeginDragHandler, IEndDragHandler, IDropHandler, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] private UIItem _uiItem;
        private int _index;
        private int _quantity;
        private Image _tempImage;
        private Color color = Color.white;
        private TempItem _tempItem;
        private Image _raycastImage;
        private float _holdTimer = 0f;
        private float _holdDelay = 0.2f;
        private bool _isHold, _isDown;

        void Awake()
        {
            _raycastImage = GetComponent<Image>();

            ResetSlot();
        }

        void Update()
        {
            if(_item == null) return;

            if(_isDown == true)
            {
                _holdTimer += Time.deltaTime;
                if(_holdTimer >= _holdDelay)
                {
                    _isHold = true;
                }
            }
        }

        public void SetInventoryUI(InventorySlot inventorySlot, int index)
        {
            if(inventorySlot.IsEmpty) 
            {
                ResetSlot();
                return;
            }
            else
            {
                // Update data in logic
                this._index = index;
                this._item = inventorySlot.GetItem();
                this._quantity = inventorySlot.Quantity;

                // Display data on UI
                _uiItem.gameObject.SetActive(true);
                _uiItem.SetItem(inventorySlot.GetItem());
                _uiItem.PlayParticle(false);
                this._quantityText.text = inventorySlot.Quantity.ToString();
            }
        }

        public void SetInteractable(bool value)
        {
            _raycastImage.raycastTarget = value;
        }

        public void MinusItem(int quantity = 1)
        {
            _quantity -= quantity;
            if(_quantity <= 0)
            {
                ResetSlot();
            }
        }
        public void ResetSlot()
        {
            _uiItem.gameObject.SetActive(false);
            _item = null;
            _quantityText.text = "0";
        }

        #region Events
        public void OnDrag(PointerEventData eventData)
        {
            if(!_isHold) return;
            _tempImage.rectTransform.anchoredPosition += eventData.delta / _tempImage.canvas.scaleFactor;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            if(!_isHold)
            {
                DragSystem.Instance.DragScrollView(this.gameObject, eventData);
                return;
            }

            _tempItem = new TempItem {
                slotIndex = this._index,
                itemSO = this._item,
                quantity = this._quantity
            };

            GameObject newImageObject = new("tempIcon");
            newImageObject.transform.SetParent(UIController.Instance.transform);
            newImageObject.AddComponent<RectTransform>();
            _tempImage = newImageObject.AddComponent<Image>();
            _tempImage.sprite = _item._itemIcon;
            _tempImage.maskable = false;
            _tempImage.transform.position = eventData.position;
            _tempImage.raycastTarget = false;
            MouseHolder.Instance.SetTempItem(_tempItem);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if(!_isHold) return;
            Destroy(_tempImage.gameObject);
            _isDown = false;
            _isHold = false;
            _holdTimer = 0;
        }

        public void OnDrop(PointerEventData eventData)
        {
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _isDown = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _isDown = false;
            _holdTimer = 0;
        }
        #endregion
    }

}
