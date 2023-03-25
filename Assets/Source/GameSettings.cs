using System;
using UnityEngine;

namespace Barrel.Game
{
	[CreateAssetMenu(menuName = "Game Settings", fileName = "Game Settings")]
	public class GameSettings : ScriptableObject
	{
		public ThrowSettings ThrowSettings;
		public LevelPreset LevelPreset;
	}

	[Serializable]
	public class ThrowSettings
	{
		public float torqueMultiplier = 3;
		public Vector3 torqueDirection = new(0.3f, -1, -1);
		public float forceMultiplier = 80;
		public Vector3 forceDirection = new(1, 0.8f, 1);
	}
}