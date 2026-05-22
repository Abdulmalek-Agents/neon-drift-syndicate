using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using InventixGames.Core;
using InventixGames.Core.Mission;
namespace NeonDrift.Race
{
    public class RaceManager : MonoBehaviour
    {
        [SerializeField] private int totalLaps = 5;
        [SerializeField] private List<Transform> racers = new();
        public int CurrentLap { get; private set; }
        public UnityEvent<int, int> OnLapChanged;
        public UnityEvent OnRaceFinished;

        public void NotifyLap(Transform racer)
        {
            if (racer != racers[0]) return; // simple — only count player for objective
            CurrentLap++;
            OnLapChanged?.Invoke(CurrentLap, totalLaps);
            if (ServiceLocator.TryGet<IMissionService>(out var ms)) ms.ReportObjectiveProgress("m1_complete_5_laps");
            if (CurrentLap >= totalLaps) OnRaceFinished?.Invoke();
        }
    }

    [RequireComponent(typeof(Collider))]
    public class LapTrigger : MonoBehaviour
    {
        [SerializeField] private RaceManager raceManager;
        private void OnTriggerEnter(Collider o) { if (raceManager) raceManager.NotifyLap(o.transform); }
    }
}
