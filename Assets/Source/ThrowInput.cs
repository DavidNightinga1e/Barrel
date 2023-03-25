using System;
using UnityEngine;

namespace Barrel.Game
{
	public class ThrowInput
	{
		private bool IsLeftClickDown => Input.GetMouseButtonDown(0);
		private bool IsLeftClickUp => Input.GetMouseButtonUp(0);
		private Vector3 CurrentMousePosition => Input.mousePosition;
		private float NormalizationFactor => Screen.width < Screen.height ? Screen.width : Screen.height;

		private Vector3 _startMousePosition;
		private float _startTime;

		public event Action<ThrowInputResult> InputEvent;

		public void Update()
		{
			if (IsLeftClickDown)
			{
				_startMousePosition = CurrentMousePosition;
				_startTime = Time.time;
				return;
			}

			if (IsLeftClickUp)
			{
				Vector3 delta = CurrentMousePosition - _startMousePosition;
				float deltaTime = Time.time - _startTime;
				Vector3 velocity = delta / deltaTime;
				Vector3 velocityNormalized = velocity / NormalizationFactor;
				
				InputEvent?.Invoke(new ThrowInputResult
				{
					HorizontalVelocityNormalized = velocityNormalized.x,
					VerticalVelocityNormalized = velocityNormalized.y
				});
			}
		}
	}
}