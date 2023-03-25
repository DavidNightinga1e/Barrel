using TMPro;
using UnityEngine;

namespace Barrel.Game
{
	public class ScoreView : MonoBehaviour
	{
		[SerializeField] private UiFill _uiFill;
		[SerializeField] private TextMeshProUGUI _totalScore;
		[SerializeField] private TextMeshProUGUI _activeScore;

		public void UpdateScore(Score score)
		{
			_totalScore.text = score.TotalScore.ToString();
			_activeScore.text = score.ActiveScore.ToString();
			_uiFill.fillAmount = score.ActiveScoreNormalized;
		}
	}
}