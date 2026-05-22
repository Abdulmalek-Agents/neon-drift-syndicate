using UnityEngine;
using InventixGames.Core;
using InventixGames.Core.Mission;
namespace NeonDrift.MissionOne
{
    public class Mission01Director : MonoBehaviour
    {
        [SerializeField] private string missionId = "M01";
        [SerializeField] private GameObject countdownUi;
        [SerializeField] private GameObject resultsPanel;
        private IMissionService _m;
        private void Start() { _m = ServiceLocator.Get<IMissionService>(); _m.OnMissionCompleted += C; if (countdownUi) countdownUi.SetActive(true); }
        private void OnDestroy() { if (_m != null) _m.OnMissionCompleted -= C; }
        private void C(MissionDataSO m) { if (m.missionId == missionId && resultsPanel) resultsPanel.SetActive(true); }
    }
}
