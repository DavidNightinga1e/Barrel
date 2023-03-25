using UnityEngine;

namespace Barrel.Game
{
	public class Throwable : MonoBehaviour
	{
		public Rigidbody Rigidbody;


		private TargetType _type;

		public TargetType Type => _type;

		[SerializeField] private ThrowableColorPresetMaterialsAdapter _materialsAdapter;

		public void SetType(TargetType type, ColorPresetMaterials materials)
		{
			_type = type;
			_materialsAdapter.ApplyMaterials(materials);
		}
	}
}