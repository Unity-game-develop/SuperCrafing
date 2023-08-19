using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;
using DG.Tweening;

namespace Game
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance;
        [SerializeField] private Button _craftBtn;
        public Action _craftRequest, _onOrderAcceptBtnPress, _onOrderDenyBtnPress;

        [BoxGroup("Order")]
        [SerializeField] UIOrder _uiOrder;

        [BoxGroup("Customer")]
        [SerializeField] GameObject _customerPanel;
        [BoxGroup("Customer")]
        [SerializeField] Image _customerIcon;
        [BoxGroup("Customer")]
        [SerializeField] TMPro.TextMeshProUGUI _customerText;
        [BoxGroup("Customer")]
        [SerializeField] Button _acceptBtn, _denyBtn;
        [BoxGroup("Customer")]
        [SerializeField] RectTransform _customerOrderIn, _customerOrderOut;

        private ItemSO _currentOrderItem;

        void Awake()
        {
            if(Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
            else
                Destroy(this.gameObject);
        }

        void Start()
        {
            HideCustomerPanel();

            _craftBtn.onClick.AddListener(() => _craftRequest?.Invoke());
            _acceptBtn.onClick.AddListener(() => _onOrderAcceptBtnPress?.Invoke());
            _denyBtn.onClick.AddListener(() => _onOrderDenyBtnPress?.Invoke());

            _onOrderAcceptBtnPress += HideCustomerPanel;
            _onOrderDenyBtnPress += HideCustomerPanel;
        }

        private void HideCustomerPanel()
        {
            Debug.Log("hide");
            _customerPanel.transform.DOMove(_customerOrderOut.position, 1f).SetEase(Ease.InBounce);
        }

        private void ShowCustomerPanel()
        {
            _customerPanel.transform.DOMove(_customerOrderIn.position, 2f).SetEase(Ease.OutBounce);
        }

        public void CreateCustomerOrder(string customerOrder, ItemSO item)
        {
            _customerText.text = customerOrder;
            _currentOrderItem = item;
            ShowCustomerPanel();
        }

        public void UpdateUIOrder(List<ItemSO> orderItems)
        {
            _uiOrder.UpdateUI(orderItems);
        }
    }

}
