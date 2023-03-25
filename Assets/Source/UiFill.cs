using System;
using UnityEngine;
using UnityEngine.UI;

namespace Barrel.Game
{
	[ExecuteAlways]
	public class UiFill : MonoBehaviour
	{
		[Header("Setup")]
		[SerializeField] private Image fill;

		[SerializeField] private Image background;

		[Header("Params")]
		[Range(0, 1)] public float fillAmount;

		private void Update()
		{
			fill.color = Color.HSVToRGB(fillAmount * 0.6f, 1f, 1f);
			RectTransform fillRectTransform = fill.rectTransform;
			fillRectTransform.sizeDelta = new Vector2(Mathf.Lerp(-background.rectTransform.rect.width, 0, fillAmount),
				fillRectTransform.sizeDelta.y);
		}
	}
}