using System;
using UnityEngine;

namespace Barrel.Game
{
	[Serializable]
	public class LevelPreset
	{
		[SerializeField] private ColorPreset left;
		[SerializeField] private ColorPreset center;
		[SerializeField] private ColorPreset right;

		public ColorPreset GetColorPresetByTargetType(TargetType type)
		{
			return type switch
			{
				TargetType.Left => left,
				TargetType.Center => center,
				TargetType.Right => right,
				_ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
			};
		}
	}
}