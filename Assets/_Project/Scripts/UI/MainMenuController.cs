using UnityEngine;
using UnityEngine.UI;
using InventixGames.Core;
using InventixGames.Core.Mission;
namespace InventixGames.UI
{
    public class MainMenuController : MonoBehaviour
    {
        [SerializeField] private MissionDatabaseSO database;
        [SerializeField] private Button raceButton, garageButton, quitButton;
        private void Start() { raceButton.onClick.AddListener(OnRace); quitButton.onClick.AddListener(OnQuit); }
        private void OnRace() { var s = ServiceLocator.Get<ISaveService>(); foreach (var m in database.missions) if (!s.IsMissionComplete(m.missionId)) { ServiceLocator.Get<IMissionService>().StartMission(m.missionId); return; } ServiceLocator.Get<IMissionService>().StartMission(database.missions[0].missionId); }
        private void OnQuit() {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}
