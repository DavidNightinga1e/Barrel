using UnityEngine;

namespace Barrel.Demo1
{
	public class Barrel : MonoBehaviour
	{
		[SerializeField] private Rigidbody _rigidbody;

		public Rigidbody Rigidbody => _rigidbody;

		public BarrelState State { get; set; }
	}
}