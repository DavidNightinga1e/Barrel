using UnityEngine;

namespace Barrel.Game
{
	public class TargetColorPresetMaterialsAdapter : MonoBehaviour
	{
		public TargetType targetType;
		
		[SerializeField] private MeshRenderer _meshRenderer;

		public void ApplyMaterials(ColorPresetMaterials materials)
		{
			var newMaterials = new Material[4];
			newMaterials[0] = materials.GetMaterial(ColorType.BaseMajor);
			newMaterials[1] = materials.GetMaterial(ColorType.BaseMinor);
			newMaterials[2] = materials.GetMaterial(ColorType.AccentMinor);
			newMaterials[3] = materials.GetMaterial(ColorType.AccentMajor);
			_meshRenderer.materials = newMaterials;
		}
	}
}