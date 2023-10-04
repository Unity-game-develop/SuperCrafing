using System;
using UnityEngine;
using NOOD.Extension;

namespace SerializableDictionary.Demo.Scripts
{
    public class SerializableDictionaryDemo_1 : MonoBehaviour
    {
        [SerializeField] private SerializableDictionary<int, Vector3> _vectorsDictionary;
        [SerializeField] private SerializableDictionary<string, GameObject> _gameObjectsDictionary;
        [SerializeField] private SerializableDictionary<string, Material> _materialsDictionary;

        private void Update()
        {
            _gameObjectsDictionary.ContainsKey("test");
        }
    }
}