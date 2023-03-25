using System;
using Barrel.Game;
using TMPro;
using UnityEngine;

namespace Barrel.Demo1
{
	public class GameController : MonoBehaviour
	{
		public HoopTrigger hoopTrigger;

		public TextMeshProUGUI scoreText;

		private readonly ServiceRunner _serviceRunner = new();
		private readonly BarrelSpawner _barrelSpawner = new ();
		
		private BarrelThrowService _barrelThrowService;
		
		private int _score;

		private void Awake()
		{
			_barrelThrowService = new BarrelThrowService();
			 var barrelDestroyService =  new BarrelDestroyService();
			 barrelDestroyService.BarrelDestroyedEvent += OnBarrelDestroyed;
			_serviceRunner.Start(_barrelThrowService);
			_serviceRunner.Start(barrelDestroyService);
			
			hoopTrigger.OnBarrelEnter += OnHoopTriggerBarrelEnter;
		}

		private void OnBarrelDestroyed(Barrel obj)
		{
			SpawnNewBarrel();
		}

		private void Start()
		{
			SpawnNewBarrel();
			scoreText.text = 0.ToString();
		}

		private void Update()
		{
			_serviceRunner.Update();
		}

		private void SpawnNewBarrel()
		{
			Barrel newBarrel = _barrelSpawner.SpawnNewBarrel();
			_barrelThrowService.CurrentBarrel = newBarrel;
		}

		private void OnHoopTriggerBarrelEnter()
		{
			_score++;
			scoreText.text = _score.ToString();
		}
	}
}