using System;
using UnityEngine;

namespace Barrel.Game
{
	public class ScoreTrigger : MonoBehaviour
	{
		[SerializeField] private TargetType targetType;

		public event Action<TargetType> OnThrowableEnter;

		private void OnTriggerEnter(Collider other)
		{
			OnThrowableEnter?.Invoke(targetType);
		}
	}
}