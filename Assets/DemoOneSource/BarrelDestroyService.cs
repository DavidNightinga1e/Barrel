using System;
using Object = UnityEngine.Object;

namespace Barrel.Demo1
{
	public class BarrelDestroyService : Service
	{
		public Barrel CurrentBarrel { get; set; }

		public event Action<Barrel> BarrelDestroyedEvent; 

		public override void Start()
		{
		}

		public override void Update()
		{
			if (CurrentBarrel.State is BarrelState.InAir && CurrentBarrel.Rigidbody.position.y < -5)
			{
				BarrelDestroyedEvent?.Invoke(CurrentBarrel);
				Object.Destroy(CurrentBarrel.gameObject);
			}
		}

		public override void Stop()
		{
		}
	}
}