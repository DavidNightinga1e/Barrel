using UnityEngine;
using Random = UnityEngine.Random;

namespace Barrel.Demo1
{
	public class BarrelThrowService : Service
	{
		public Barrel CurrentBarrel { get; set; }

		private readonly Vector3 _force = new(0, 240, 300);
		private readonly Vector2 _offset = new(0.1f, 0.1f);

		public override void Start()
		{
		}

		public override void Update()
		{
			if (CurrentBarrel.State is BarrelState.Ready && Input.GetKeyDown(KeyCode.Space))
				ThrowCurrentBarrel();
		}

		public override void Stop()
		{
		}

		private void ThrowCurrentBarrel()
		{
			Vector2 randomOffset = Random.insideUnitCircle * _offset;
			var offsetForce = new Vector3(randomOffset.x, randomOffset.y, 0);
			CurrentBarrel.Rigidbody.AddForceAtPosition(_force, CurrentBarrel.transform.position + offsetForce);
		}
	}
}