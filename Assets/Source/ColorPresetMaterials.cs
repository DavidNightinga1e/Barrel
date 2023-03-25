using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Barrel.Game
{
	public class ColorPresetMaterials : IDisposable
	{
		private readonly Material[] _materials = new Material[4];

		public void AddMaterial(ColorType type, Material material)
		{
			_materials[(int)type] = material;
		}

		public Material GetMaterial(ColorType type)
		{
			return _materials[(int)type];
		}

		public void Dispose()
		{
			foreach (Material material in _materials)
			{
				if (material != null)
					Object.Destroy(material);
			}
		}
	}
}