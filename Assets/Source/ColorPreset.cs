using System;
using UnityEngine;

namespace Barrel.Game
{
	[Serializable]
	public class ColorPreset
	{
		[SerializeField] private Color baseMajor;
		[SerializeField] private Color baseMinor;
		[SerializeField] private Color accentMajor;
		[SerializeField] private Color accentMinor;

		public Color GetColorByType(ColorType type)
		{
			return type switch
			{
				ColorType.BaseMajor => baseMajor,
				ColorType.BaseMinor => baseMinor,
				ColorType.AccentMajor => accentMajor,
				ColorType.AccentMinor => accentMinor,
				_ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
			};
		}
	}
}