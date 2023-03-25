using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Barrel.Game
{
	public class GameRunner : MonoBehaviour
	{
		[Header("Behaviour Links")]
		public ScoreView scoreView;
		public ScoreTrigger[] scoreTriggers;
		public TargetColorPresetMaterialsAdapter[] targetMaterialAdapters;
		public Throwable Throwable;

		private readonly ThrowInput _throwInput = new();
		private readonly Score _score = new();
		private ThrowableController _throwableController;
		private ColorPresetMaterialsHolder _colorPresetMaterialsHolder;

		private void Awake()
		{
			var gameSettings = Resources.Load<GameSettings>("Game Settings");
			LevelPreset levelPreset = gameSettings.LevelPreset;
			ThrowSettings throwSettings = gameSettings.ThrowSettings;

			_colorPresetMaterialsHolder = new ColorPresetMaterialsHolder(levelPreset);
			_throwableController = new ThrowableController(Throwable, throwSettings, _colorPresetMaterialsHolder);

			foreach (TargetColorPresetMaterialsAdapter targetAdapter in targetMaterialAdapters)
				targetAdapter.ApplyMaterials(
					_colorPresetMaterialsHolder.GetMaterialsByTargetType(targetAdapter.targetType));

			_throwInput.InputEvent += OnThrowInput;
			_throwableController.OnThrowableOutOfBounds += ThrowableOutOfBoundsHandler;
			_score.OnActiveScoreDepleted += ActiveScoreDepletedHandler;
			foreach (ScoreTrigger scoreTrigger in scoreTriggers)
				scoreTrigger.OnThrowableEnter += OnThrowableEnterScoreTrigger;
		}

		private void Start()
		{
			ResetThrow();
		}

		private void Update()
		{
			_throwInput.Update();
			_score.Update();
			_throwableController.Update();
			scoreView.UpdateScore(_score);

			if (Input.GetKeyDown(KeyCode.R)) ResetThrow();
		}

		private void OnDestroy()
		{
			_throwInput.InputEvent -= OnThrowInput;
			foreach (ScoreTrigger scoreTrigger in scoreTriggers)
				scoreTrigger.OnThrowableEnter -= OnThrowableEnterScoreTrigger;
		}

		private void ActiveScoreDepletedHandler()
		{
			ResetThrow();
		}

		private void ThrowableOutOfBoundsHandler()
		{
			ResetThrow();
		}

		private void OnThrowInput(ThrowInputResult throwInput)
		{
			_throwableController.Throw(throwInput);
		}

		private void OnThrowableEnterScoreTrigger(TargetType targetType)
		{
			bool isScored = targetType == Throwable.Type;
			_score.ResetActiveScore(isScored);
			_throwableController.ResetThrowable((TargetType)Random.Range(0, 3));
		}

		private void ResetThrow()
		{
			_throwableController.ResetThrowable((TargetType)Random.Range(0, 3));
			_score.ResetActiveScore(false);
		}
	}
}