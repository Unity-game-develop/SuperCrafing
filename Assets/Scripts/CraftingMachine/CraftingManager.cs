using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using NOOD;

namespace Game
{
    public class CraftingManager : MonoBehaviorInstance<CraftingManager>
    {
        [SerializeField] private CraftingMachineAnimation _craftingAnimation;
        [SerializeField] private List<RecipeSO> _recipeList;

        private ItemSO _item1, _item2;
        private ItemSO resultItem;

        [SerializeField] private GameObject _newItemObject;
        [SerializeField] private Image _newItemImage;
        [SerializeField] private Transform _spawnPos, _endPos;

        void Start() 
        {
            UIManager.Instance._craftRequest = StartCraft;
            _newItemObject.gameObject.SetActive(false);
            LoadRecipe();
        }

        private void LoadRecipe()
        {
            _recipeList = Resources.LoadAll<RecipeSO>("RecipeSO").ToList();
        }

        public void SetItem(ItemSO item)
        {
            if(_item1 == null)
            {
                SetItem1(item);
            }
            else
            {
                if(_item2 == null)
                {
                    SetItem2(item);
                }
            }
        }
        public void SetItem1(ItemSO item)
        {
            _item1 = item;
        }

        public void SetItem2(ItemSO item)
        {
            _item2 = item;
        }

        public ItemSO Craft()
        {
            // Debug.Log(_recipeList.Count());
            foreach(var recipe in _recipeList)
            {
                if(CompareRecipe(recipe, _item1, _item2))
                {
                    return recipe.result;
                }
            }
            return null;
        }

        public bool CompareRecipe(RecipeSO recipe, ItemSO item1, ItemSO item2)
        {
            if(recipe.item1 == _item1 || recipe.item2 == _item1)
            {
                if(recipe.item2 == _item2 || recipe.item1 == _item2)
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        public void StartCraft()
        {
            _craftingAnimation.StartCraftAnimation();
            NOOD.NoodyCustomCode.StartDelayFunction(() => 
            {
                resultItem = Craft();
                if(resultItem == null)
                {
                    // Craft failed
                    Debug.Log("Craft failed");
                    return;
                }
                //TODO: Spawn new item on the screen
                _newItemObject.gameObject.SetActive(true);
                this.CreateNewItem(resultItem._itemIcon);
                InventoryManager.Instance.AddToInventory(resultItem);
            }, _craftingAnimation.GetCurrentAnimationTime());
        }

        public void CreateNewItem (Sprite icon)
        {
            _newItemImage.sprite = icon;
            _newItemObject.transform.localScale = Vector3.zero;
            _newItemObject.transform.DOScale(3, 1.5f).SetEase(Ease.OutBounce);
            NOOD.NoodyCustomCode.StartDelayFunction(() =>
            {
                _newItemObject.transform.DOMove(_endPos.position, 2f).SetEase(Ease.InOutCirc);
                _newItemObject.transform.DOScale(2, 2f).SetEase(Ease.Flash).OnComplete(() => _newItemObject.gameObject.SetActive(false));
            }, 2f);
        }
    }
}
