using UnityEngine;

namespace Barrel.Demo1
{
	public class HoopMovement : MonoBehaviour
	{
		[SerializeField] private Rigidbody _rigidbody;
		
		public float speed;

		private const float DISTANCE = 4.5f;
		private bool IsMovingForward;

		private void FixedUpdate()
		{
			Vector3 position = _rigidbody.position;

			Vector3 movementDelta = (IsMovingForward ? Vector3.right : Vector3.left) * (speed * Time.fixedDeltaTime);
			_rigidbody.MovePosition(position + movementDelta);

			IsMovingForward = IsMovingForward switch
			{
				true when position.x > DISTANCE => false,
				false when position.x < -DISTANCE => true,
				_ => IsMovingForward
			};
		}
	}
}