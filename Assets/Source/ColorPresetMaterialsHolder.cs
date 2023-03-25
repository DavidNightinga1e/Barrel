using System;
using UnityEngine;

namespace Barrel.Game
{
	public class ColorPresetMaterialsHolder : IDisposable
	{
		private readonly ColorPresetMaterials[] _colorPresetMaterials = new ColorPresetMaterials[3];

		public ColorPresetMaterialsHolder(LevelPreset levelPreset)
		{
			_colorPresetMaterials[(int)TargetType.Left] =
				CreateMaterialsForColorPreset(levelPreset.GetColorPresetByTargetType(TargetType.Left));
			_colorPresetMaterials[(int)TargetType.Center] =
				CreateMaterialsForColorPreset(levelPreset.GetColorPresetByTargetType(TargetType.Center));
			_colorPresetMaterials[(int)TargetType.Right] =
				CreateMaterialsForColorPreset(levelPreset.GetColorPresetByTargetType(TargetType.Right));
		}

		public ColorPresetMaterials GetMaterialsByTargetType(TargetType targetType)
		{
			return _colorPresetMaterials[(int)targetType];
		}

		private ColorPresetMaterials CreateMaterialsForColorPreset(ColorPreset colorPreset)
		{
			var result = new ColorPresetMaterials();
			result.AddMaterial(ColorType.AccentMajor,
				InstantiateMaterial(colorPreset.GetColorByType(ColorType.AccentMajor)));
			result.AddMaterial(ColorType.AccentMinor,
				InstantiateMaterial(colorPreset.GetColorByType(ColorType.AccentMinor)));
			result.AddMaterial(ColorType.BaseMajor,
				InstantiateMaterial(colorPreset.GetColorByType(ColorType.BaseMajor)));
			result.AddMaterial(ColorType.BaseMinor,
				InstantiateMaterial(colorPreset.GetColorByType(ColorType.BaseMinor)));
			return result;
		}

		private Material InstantiateMaterial(Color color)
		{
			return new Material(Shader.Find("Universal Render Pipeline/Lit"))
			{
				color = color
			};
		}

		public void Dispose()
		{
			foreach (ColorPresetMaterials colorPresetMaterial in _colorPresetMaterials)
				colorPresetMaterial?.Dispose();
		}
	}
}