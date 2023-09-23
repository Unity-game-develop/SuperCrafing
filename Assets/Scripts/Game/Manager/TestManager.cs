using System; 
using System.Collections.Generic; 
using System.Collections; 
using UnityEngine; 
using NOOD; 
using NOOD.UI;

namespace Game.Manager
{
    public class TestManager : MonoBehaviour
    {
		public static TestManager Create(Transform parent = null)
        {
            return Instantiate(Resources.Load<TestManager>("Prefab/Game/Manager/TestManager"), parent);
        }
	}
}