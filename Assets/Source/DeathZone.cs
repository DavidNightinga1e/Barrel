using System;
using UnityEngine;

namespace Barrel.Game
{
	public class DeathZone : MonoBehaviour
	{
		public event Action<Barrel> OnBarrelEnter;

		private void OnTriggerEnter(Collider other)
		{
			Debug.Log("Death Zone");
			var barrel = other.GetComponentInParent<Barrel>();
			if (barrel)
				OnBarrelEnter?.Invoke(barrel);
		}
	}
}