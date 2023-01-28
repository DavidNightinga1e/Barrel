using UnityEngine;

namespace Barrel.Game
{
	public class BarrelSpawn : MonoBehaviour
	{
		public Barrel Prefab;

		public Barrel SpawnNewBarrel()
		{
			GameObject instance = Instantiate(Prefab.gameObject, transform.position, Quaternion.identity);
			return instance.GetComponent<Barrel>();
		}
	}
}