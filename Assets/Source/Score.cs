using System;
using UnityEngine;

namespace Barrel.Game
{
	public class Score
	{
		private const int MaxActiveScore = 999;
		private const int ScoreReductionRate = 150;

		public event Action OnActiveScoreDepleted;
		
		public int TotalScore { get; private set; }
		public int ActiveScore => Mathf.FloorToInt(_activeScore);
		public float ActiveScoreNormalized => _activeScore / MaxActiveScore;

		private float _activeScore;

		public Score()
		{
			_activeScore = MaxActiveScore;
			TotalScore = 0;
		}

		public void Update()
		{
			_activeScore -= ScoreReductionRate * Time.deltaTime;
			if (_activeScore <= 0)
			{
				_activeScore = 0;
				OnActiveScoreDepleted?.Invoke();
			}
		}

		public void ResetActiveScore(bool addToTotal)
		{
			if (addToTotal)
				TotalScore += ActiveScore;
			_activeScore = MaxActiveScore;
		}
	}
}