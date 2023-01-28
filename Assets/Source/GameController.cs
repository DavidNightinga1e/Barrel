using System;
using TMPro;
using UnityEngine;

namespace Barrel.Game
{
	public class GameController : MonoBehaviour
	{
		public HoopTrigger hoopTrigger;
		public DeathZone deathZone;
		public BarrelSpawn barrelSpawn;
		public BarrelThrow barrelThrow;
		public TextMeshPro scoreText;

		private int score;

		private void Awake()
		{
			hoopTrigger.OnBarrelEnter += OnHoopTriggerBarrelEnter;
			deathZone.OnBarrelEnter += OnDeathZoneBarrelEnter;
		}

		private void Start()
		{
			SpawnNewBarrel();
			scoreText.text = 0.ToString();
		}

		private void OnDeathZoneBarrelEnter(Barrel barrel)
		{
			Destroy(barrel.gameObject);
			SpawnNewBarrel();
		}

		private void SpawnNewBarrel()
		{
			Barrel newBarrel = barrelSpawn.SpawnNewBarrel();
			barrelThrow.CurrentBarrel = newBarrel;
		}

		private void OnHoopTriggerBarrelEnter()
		{
			score++;
			scoreText.text = score.ToString();
		}
	}
}