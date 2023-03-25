using System;
using UnityEngine;

namespace Barrel.Demo1
{
	public class HoopTrigger : MonoBehaviour
	{
		public event Action OnBarrelEnter;

		private void OnTriggerEnter(Collider other)
		{
			Debug.Log("Barrel entered");
			OnBarrelEnter?.Invoke();
		}
	}
}