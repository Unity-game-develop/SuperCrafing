using System; 
using System.Collections.Generic; 
using System.Collections; 
using UnityEngine; 
using NOOD; 
using NOOD.UI; 

namespace Game.Manager
{
	public class TestManager2: MonoBehaviour 
	{
		public static TestManager2 Create(Transform parent = null)
		{
			return Instantiate(Resources.Load<TestManager2>("Prefab/Game/Manager/TestManager2"), parent);
		}
	}
}
