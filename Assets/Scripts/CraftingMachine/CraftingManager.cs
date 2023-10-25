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
        [SerializeField] private Transform _spawnPos, _endPos;

        bool _isItemAnimating = false;

        void Start() 
        {
            UIController.Instance._craftRequest = StartCraft;
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
                    ItemSO resultItem = recipe.result;
                    resultItem._itemTier = TierSystem.RandomTier(_item1._itemTier, _item2._itemTier);
                    Debug.Log("Create new Item: " + resultItem._itemName + resultItem._itemTier);
                    return resultItem;
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
                // Spawn new item on the screen
                this.CreateNewItem(resultItem);
                InventoryManager.Instance.AddToInventory(resultItem);
            }, _craftingAnimation.GetCurrentAnimationTime());
        }

        public void CreateNewItem (ItemSO item)
        {
            // Create new item GameObject
            GameObject newItemObject = Instantiate(_newItemObject, _newItemObject.transform.parent);
            newItemObject.gameObject.SetActive(true);
            UIItem uiItem = newItemObject.GetComponentInChildren<UIItem>();
            uiItem.SetItem(item);

            // Play animation
            uiItem.PlayParticle(true);
            newItemObject.transform.localScale = Vector3.zero;
            newItemObject.transform.position = _spawnPos.position;
            newItemObject.transform.DOScale(3, 1.5f).SetEase(Ease.OutBounce);
            NOOD.NoodyCustomCode.StartDelayFunction(() =>
            {
                newItemObject.transform.DOMove(_endPos.position, 2f).SetEase(Ease.InOutCirc);
                newItemObject.transform.DOScale(2, 2f).SetEase(Ease.Flash).OnComplete(() => Destroy(newItemObject));
            }, 2f);
        }
    }
}
