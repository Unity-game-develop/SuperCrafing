using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NOOD.Interface;

namespace NOOD.UI
{
    public class NoodUI : MonoBehaviour, INoodyUI
    {
        public static T Create<T>(Transform parent = null) where T : INoodyUI
        {
            MonoBehaviour prefab = null;
            MonoBehaviour[] prefabs = Resources.FindObjectsOfTypeAll<MonoBehaviour>();
            foreach(var pre in prefabs)
            {
                if(pre.GetComponentInChildren<T>() != null)
                {
                    prefab = pre;
                }
            }
            MonoBehaviour temp = Instantiate(prefab, parent);
            if(temp == null)
            {
                Debug.LogError("Can't find prefab with type " + typeof(T).Name);
            }
            return temp.GetComponentInChildren<T>();
        }
        

        public virtual void Open(){}
        public virtual void Close(){}
    }
}
