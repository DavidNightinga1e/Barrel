using System;
using UnityEngine;

namespace Barrel.Game
{
	public class ThrowableController
	{
		public event Action OnThrowableOutOfBounds; 

		private readonly ThrowSettings _throwSettings;
		private readonly Throwable _throwable;
		private readonly ColorPresetMaterialsHolder _materialsHolder;
		private readonly Vector3 _throwableStartPosition;

		private bool _isThrowableInAir;
		
		public ThrowableController(
			Throwable throwable, 
			ThrowSettings throwSettings, 
			ColorPresetMaterialsHolder materialsHolder)
		{

			_throwable = throwable;
			_throwSettings = throwSettings;
			_materialsHolder = materialsHolder;
			
			_throwableStartPosition = throwable.transform.position;
		}

		public void Throw(ThrowInputResult input)
		{
			if (_isThrowableInAir)
				return;
			
			var direction = new Vector3
			(
				_throwSettings.forceDirection.x * input.HorizontalVelocityNormalized,
				_throwSettings.forceDirection.y * input.VerticalVelocityNormalized,
				_throwSettings.forceDirection.z * input.VerticalVelocityNormalized
			);
			var torque = new Vector3
			(
				_throwSettings.torqueDirection.x * input.VerticalVelocityNormalized,
				_throwSettings.torqueDirection.y * input.HorizontalVelocityNormalized,
				_throwSettings.torqueDirection.z * input.HorizontalVelocityNormalized
			);
			_throwable.Rigidbody.AddForce(_throwSettings.forceMultiplier * direction);
			_throwable.Rigidbody.AddTorque(torque * _throwSettings.torqueMultiplier);

			_isThrowableInAir = true;
		}

		public void ResetThrowable(TargetType targetType)
		{
			_throwable.Rigidbody.velocity = Vector3.zero;
			_throwable.Rigidbody.angularVelocity = Vector3.zero;
			_throwable.Rigidbody.position = _throwableStartPosition;
			_throwable.Rigidbody.rotation = Quaternion.identity;

			_throwable.SetType(targetType, _materialsHolder.GetMaterialsByTargetType(targetType));

			_isThrowableInAir = false;
		}

		public void Update()
		{
			if (_throwable.Rigidbody.position.y < -5)
				OnThrowableOutOfBounds?.Invoke();
		}
	}
}