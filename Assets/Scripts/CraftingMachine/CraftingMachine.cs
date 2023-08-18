using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Sirenix.OdinInspector;

namespace Game
{
    public class CraftingMachine : MonoBehaviour 
    {
        [SerializeField] private CraftingMachineAnimation _craftingAnimation;
        [SerializeField] private List<RecipeSO> _recipeList;
        [SerializeField] private CraftingNewItem _craftingNewItem;

        private ItemSO _item1, _item2;
        private ItemSO _resultItem;

        void Start()
        {
            // _recipeList = _recipeList.Distinct().ToList();
            UIManager.Instance._craftRequest = StartCraft;
            Debug.Log(_recipeList.Count);
            _craftingNewItem.gameObject.SetActive(false);
        }
        
        void Update()
        {
            // Debug.Log(_recipeList.Count);
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

        public void StartCraft()
        {
            _craftingAnimation.StartCraftAnimation();
            NOOD.NoodyCustomCode.StartDelayFunction(() => 
            {
                _resultItem = Craft(); 
                //TODO: Spawn new item on the screen
                _craftingNewItem.gameObject.SetActive(true);
                _craftingNewItem.CreateNewItem(_resultItem._itemIcon);

            }, _craftingAnimation.GetCurrentAnimationTime());

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
    }
}
