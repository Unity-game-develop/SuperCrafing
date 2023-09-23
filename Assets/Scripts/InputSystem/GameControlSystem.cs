using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using NOOD.Data;

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
            // If don't exist any GameControl on disk, create one
            _gameControl = DataManager<GameControl>.Data;
        }

        public static void Init()
        {
            LoadData();
            _gameControl.Game.Craft.performed += (InputAction.CallbackContext callback) => _onCraft?.Invoke();
            _gameControl.Game.OpenStore.performed += (InputAction.CallbackContext callback) => _onStore?.Invoke();
            _gameControl.Game.OpenBook.performed += (InputAction.CallbackContext callback) => _onBook?.Invoke();
        }
    }
}
