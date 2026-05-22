# 🧱 Technical Architecture — Neon Drift Syndicate

> v0.2: runtime LLM removed. Commentator + Rivals draw from `LineBankSO` pools.
> v0.2.1: Unity 6 LTS (6000.4.4f1) target.

## 1. Stack

| Layer | Choice |
|---|---|
| Engine | Unity **6 LTS (6000.4.4f1)** |
| Render | **URP 17.x** |
| Vehicle physics | Complete Racing Game 2 framework + Edy's Vehicle Physics |
| Input | New Input System |
| Async loading | Addressables |
| Save | JsonUtility → persistentDataPath |
| Dialogue | Hand-authored `LineBankSO` pools (Commentator + Rivals) |
| Camera | Cinemachine 3.x |
| Source control | Git + LFS |

## 2. Scripts

```
Core/         (shared)
Dialogue/     DialogueNodeSO, LineBankSO, ScriptedDialogueService
UI/           MainMenuController, HUDController
Gameplay/
  Vehicle/    VehicleControllerWrapper, VehicleDataSO
  Race/       RaceManager, LapTrigger, AIDriver, PositionSystem
  Weapons/    WeaponMount, WeaponDataSO, ProjectileBase, EMPProjectile, HomingMissile
  Commentator/ RaceCommentator (consumes 6 LineBankSO per event)
  Mission01/  Mission01Director
```

## 3. Scenes

| Scene | Build idx |
|---|---|
| Bootstrap | 0 |
| MainMenu | 1 |
| Garage | 2 |
| Mission01_Tutorial | 3 |
| Mission02_Skylane | 4 |
| ... up to Mission06_Championship | 5–8 |

## 4. Vehicle controller pattern

- VehicleControllerWrapper holds reference to Edy's VehicleController + a VehicleDataSO (stat overrides).
- VehicleDataSO defines top speed, accel, handling, weight, weapon slot count.
- Switching vehicles = swapping the DataSO; physics tuning is data-driven.

## 5. Race flow

```
MissionManager.StartMission('M01')
  → Scene loads + RaceManager initialised
  → Player spawn at grid + AI ghosts spawn (PositionSystem tracks)
  → Pre-race: RaceCommentator.Say(raceStartBank) — picks from hand-authored LineBank
  → Countdown 3-2-1 GO
  → RaceManager.OnLapCompleted → LapTrigger detection → RaceCommentator.OnLapComplete()
  → At lap count: RaceManager.RaceEnded → RaceCommentator.OnRaceFinish() → Mission objective complete
  → Results screen via Heat UI
```

## 6. AIDriver

- Path-following on a Spline (Unity Splines + TerraSplines).
- Rubber-banding via target-speed = playerSpeed * (1 + difficultyDelta).
- Switches lanes based on player position + boost availability.

## 7. Unity 6 (6000.4.4f1) compatibility notes

- **URP** upgraded from 14.x → 17.x — Render Pipeline Converter handles Unity 2022–era track packs.
- **Cinemachine 3.x** — chase-cam uses `CinemachineCamera` + `CinemachineThirdPersonFollow` (or `CinemachineHardLookAt` for the bumper-cam variant).
- **Complete Racing Game 2** / **Edy's Vehicle Physics** — both are Unity-6-compatible; if Edy's posts an update, take the latest.
- **Splines**, **Addressables**, **TextMeshPro**, **New Input System** unchanged.

## 8. Scalability

- New track = new scene + new MissionData + new RaceConfigSO.
- New weapon = new ProjectileBase subclass + WeaponDataSO.
- New vehicle = new prefab + VehicleDataSO.
- New Commentator event = add a `LineBankSO` field on `RaceCommentator` + author the bank.
- Internet outage breaks game? ❌ No — fully offline.

## 9. Performance budget (60 fps RTX 2060)

- Draw calls < 1,500 (track + cars + neon)
- Triangles < 2.5M
- Particles < 6,000 (drift sparks + explosions)
- Memory < 1.5 GB

## 10. CI later.
