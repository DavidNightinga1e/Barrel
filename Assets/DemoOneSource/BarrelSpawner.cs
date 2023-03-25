using UnityEngine;

namespace Barrel.Demo1
{
	public class BarrelSpawner
	{
		private readonly GameObject _prefab;
		private readonly Vector3 _spawnPosition = new Vector3(0, 0, 0);

		public BarrelSpawner()
		{
			_prefab = Resources.Load<GameObject>("Barrel");
		}

		public Barrel SpawnNewBarrel()
		{
			GameObject instance = Object.Instantiate(_prefab.gameObject, _spawnPosition, Quaternion.identity);
			return instance.GetComponent<Barrel>();
		}
	}
}