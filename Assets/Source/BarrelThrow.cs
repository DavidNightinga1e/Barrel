using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Barrel.Game
{
	public class BarrelThrow : MonoBehaviour
	{
		public Barrel CurrentBarrel;

		public Vector3 force;
		public Vector2 offset;

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.Space))
				ThrowCurrentBarrel();
		}

		private void ThrowCurrentBarrel()
		{
			Vector2 randomOffset = Random.insideUnitCircle * offset;
			var offsetForce = new Vector3(randomOffset.x, randomOffset.y, 0);
			CurrentBarrel.Rigidbody.AddForceAtPosition(force, CurrentBarrel.transform.position + offsetForce);
		}
	}
}