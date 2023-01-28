using UnityEngine;

namespace Barrel.Game
{
	public class HoopMovement : MonoBehaviour
	{
		public float speed;

		private const float DISTANCE = 4.5f;
		private bool IsMovingForward;

		private void Update()
		{
			Vector3 position = transform.position;

			position += (IsMovingForward ? Vector3.right : Vector3.left) * (speed * Time.deltaTime);
			transform.position = position;

			IsMovingForward = IsMovingForward switch
			{
				true when position.x > DISTANCE => false,
				false when position.x < -DISTANCE => true,
				_ => IsMovingForward
			};
		}
	}
}