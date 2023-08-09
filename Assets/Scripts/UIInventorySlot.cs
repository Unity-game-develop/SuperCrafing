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

    public class UIInventorySlot : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IDropHandler
    {
        private ItemSO _itemSO;
        private int _index;
        private int _quantity;
        private Image _tempImage;
        [SerializeField] private Image _icon;
        [SerializeField] private TextMeshProUGUI _quantityText;
        private Color color = Color.white;
        private TempItem _tempItem;

        void Start()
        {
        }

        public void SetInventoryUI(InventorySlot inventorySlot, int index)
        {
            if(inventorySlot.Quantity == 0)
            {
                color.a = 0;
            }
            else
            {
                color.a = 1;
            }
            this._index = index;
            this._itemSO = inventorySlot.GetItem();
            this._icon.sprite = inventorySlot.GetIcon();
            this._icon.color = color;
            this._quantityText.text = inventorySlot.Quantity.ToString();
            this._quantity = inventorySlot.Quantity;
        }

        public void OnDrag(PointerEventData eventData)
        {
            _tempImage.rectTransform.anchoredPosition += eventData.delta / _tempImage.canvas.scaleFactor;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            _tempItem = new TempItem
            {
                slotIndex = this._index,
                itemSO = this._itemSO,
                quantity = this._quantity
            };

            _tempImage = Instantiate(_icon, _icon.canvas.transform);
            _tempImage.transform.position = eventData.position;
            _tempImage.raycastTarget = false;
            // _tempImage.GetComponent<CanvasGroup>().interactable = false;
            MouseHolder.Instance.SetTempItem(_tempItem);
        }

        private void DisplayDebug()
        {
            Debug.Log("OnEndDrag" + _tempItem.itemSO._itemName);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            Destroy(_tempImage);
        }

        public void OnDrop(PointerEventData eventData)
        {
        }
    }

}
