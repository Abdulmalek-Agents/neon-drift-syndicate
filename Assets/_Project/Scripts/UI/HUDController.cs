using UnityEngine;
using UnityEngine.UI;
using TMPro;
using InventixGames.Core;
using InventixGames.Core.Mission;
namespace InventixGames.UI
{
    public class HUDController : MonoBehaviour
    {
        [SerializeField] private TMP_Text speedText, lapText, positionText, commentatorText;
        [SerializeField] private Slider boostMeter;
        public void SetSpeed(float kmh) { if (speedText) speedText.text = $"{kmh:0} km/h"; }
        public void SetLap(int cur, int total) { if (lapText) lapText.text = $"LAP {cur}/{total}"; }
        public void SetBoost(float v) { if (boostMeter) boostMeter.value = v; }
        public void SetCommentary(string line) { if (commentatorText) commentatorText.text = line; }
    }
}
