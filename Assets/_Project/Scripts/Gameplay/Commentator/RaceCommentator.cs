using System.Collections;
using UnityEngine;
using InventixGames.Core.Dialogue;

namespace NeonDrift.Commentator
{
    /// <summary>
    /// Picks commentator lines from event-appropriate LineBankSO pools.
    /// v0.2: 100% hand-authored — see /Assets/_Project/Data/LineBanks/.
    /// Matches the shipping pattern of Burnout / Forza Horizon / The Crew.
    /// </summary>
    public class RaceCommentator : MonoBehaviour
    {
        [Header("Event line banks (author 30–60 lines each)")]
        [SerializeField] private LineBankSO raceStartBank;
        [SerializeField] private LineBankSO overtakeBank;
        [SerializeField] private LineBankSO bigDriftBank;
        [SerializeField] private LineBankSO lapCompleteBank;
        [SerializeField] private LineBankSO raceFinishBank;
        [SerializeField] private LineBankSO idleChatterBank;

        [Header("Cadence (idle filler between events)")]
        [SerializeField] private float idleMin = 12f, idleMax = 25f;

        [Header("Audio")]
        [SerializeField] private AudioSource commsSource;

        private void Start() { StartCoroutine(StartSequence()); }

        private IEnumerator StartSequence()
        {
            yield return new WaitForSeconds(1.5f);
            Say(raceStartBank);
            while (true)
            {
                yield return new WaitForSeconds(Random.Range(idleMin, idleMax));
                Say(idleChatterBank);
            }
        }

        public void OnOvertake() => Say(overtakeBank);
        public void OnBigDrift() => Say(bigDriftBank);
        public void OnLapComplete() => Say(lapCompleteBank);
        public void OnRaceFinish() => Say(raceFinishBank);

        protected virtual void Say(LineBankSO bank)
        {
            if (bank == null) return;
            string line = bank.PickRandom(out var clip);
            if (commsSource && clip) { commsSource.clip = clip; commsSource.Play(); }
            // Pipe `line` to HUD subtitle.
            Debug.Log($"[Commentator] {line}");
        }
    }
}
