using UnityEngine;

namespace Barrel.Game
{
	public class Barrel : MonoBehaviour
	{
		[SerializeField] private Rigidbody _rigidbody;

		public Rigidbody Rigidbody => _rigidbody;
	}
}