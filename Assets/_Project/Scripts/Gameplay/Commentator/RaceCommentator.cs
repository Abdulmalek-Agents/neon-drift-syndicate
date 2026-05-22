using System.Collections;
using UnityEngine;
using InventixGames.Core;
namespace NeonDrift.Commentator
{
    public class RaceCommentator : MonoBehaviour
    {
        [SerializeField] private AICopilotPersonaSO commentatorPersona;
        [SerializeField] private float minIntervalSec = 12f;
        [SerializeField] private float maxIntervalSec = 25f;
        private IAICopilotService _ai;

        private void Start() { _ai = ServiceLocator.Get<IAICopilotService>(); StartCoroutine(Loop()); }

        private IEnumerator Loop()
        {
            yield return new WaitForSeconds(1.5f);
            _ai.Ask(commentatorPersona.systemPrompt, "Race start: give a hype 1-sentence call.", OnLine);
            while (true)
            {
                yield return new WaitForSeconds(Random.Range(minIntervalSec, maxIntervalSec));
                _ai.Ask(commentatorPersona.systemPrompt, BuildContext(), OnLine);
            }
        }
        protected virtual string BuildContext() => "Player is racing. Give a one-line commentator call.";
        protected virtual void OnLine(string line) { Debug.Log($"[Commentator] {line}"); /* Pipe to HUD subtitle */ }
    }
}
