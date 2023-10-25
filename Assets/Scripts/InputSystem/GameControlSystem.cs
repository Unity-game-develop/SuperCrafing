using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using NOOD.Data;
using NOOD.Extension;

namespace Game
{
    public static class GameControlSystem
    {
        public static GameControl _gameControl;
        public static Action _onCraft;
        public static Action _onStore;
        public static Action _onBook;

        private static void LoadData()
        {
            if(_gameControl == null)
            {
                _gameControl = new GameControl();
                return;
            }
        }

        public static void SaveKeyBinding()
        {
            // _gameControl.Game.Craft.SaveKeyBinding();
            // _gameControl.Game.OpenBook.SaveKeyBinding();
            // _gameControl.Game.OpenStore.SaveKeyBinding();
        }

        public static void Init()
        {
            LoadData();
            _gameControl.Game.Craft.performed += (InputAction.CallbackContext callback) => _onCraft?.Invoke();
            _onCraft += () =>
            {
                Debug.Log("Crafting");
            };
            _gameControl.Game.OpenStore.performed += (InputAction.CallbackContext callback) => _onStore?.Invoke();
            _gameControl.Game.OpenBook.performed += (InputAction.CallbackContext callback) => _onBook?.Invoke();
            SaveKeyBinding();
        }
    }
}
