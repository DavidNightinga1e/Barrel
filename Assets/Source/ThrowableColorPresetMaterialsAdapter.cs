using UnityEngine;

namespace Barrel.Game
{
	public class ThrowableColorPresetMaterialsAdapter : MonoBehaviour
	{
		[SerializeField] private MeshRenderer _meshRenderer;

		public void ApplyMaterials(ColorPresetMaterials materials)
		{
			var newMaterials = new Material[4];
			newMaterials[0] = materials.GetMaterial(ColorType.AccentMinor);
			newMaterials[1] = materials.GetMaterial(ColorType.BaseMinor);
			newMaterials[2] = materials.GetMaterial(ColorType.AccentMajor);
			newMaterials[3] = materials.GetMaterial(ColorType.BaseMajor);
			_meshRenderer.materials = newMaterials;
		}
	}
}