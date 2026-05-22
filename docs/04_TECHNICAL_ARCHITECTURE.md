# 🧱 Technical Architecture — Neon Drift Syndicate

## 1. Stack

Unity 2022.3 LTS + URP. Complete Racing Game 2 as foundation. Edy's Vehicle Physics. New Input System. Addressables. Claude proxy.

## 2. Scripts

```
Core/         (shared)
AI/           ClaudeCopilotService, AICopilotPersonaSO
UI/           MainMenuController, HUDController
Gameplay/
  Vehicle/    VehicleControllerWrapper, VehicleDataSO
  Race/       RaceManager, LapTrigger, AIDriver, PositionSystem
  Weapon/     WeaponMount, WeaponDataSO, ProjectileBase, EMPProjectile, HomingMissile
  Commentator/ RaceCommentator (Claude AI)
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
  → Pre-race Commentator line (Claude AI)
  → Countdown 3-2-1 GO
  → RaceManager.OnLapCompleted → LapTrigger detection
  → At lap count: RaceManager.RaceEnded → Mission objective complete
  → Results screen via Heat UI
```

## 6. AIDriver

- Path-following on a Spline (Unity Splines + TerraSplines).
- Rubber-banding via target-speed = playerSpeed * (1 + difficultyDelta).
- Switches lanes based on player position + boost availability.

## 7. Scalability

- New track = new scene + new MissionData + new RaceConfigSO.
- New weapon = new ProjectileBase subclass + WeaponDataSO.
- New vehicle = new prefab + VehicleDataSO.

## 8. Performance budget (60 fps RTX 2060)

- Draw calls < 1,500 (track + cars + neon)
- Triangles < 2.5M
- Particles < 6,000 (drift sparks + explosions)
- Memory < 1.5 GB

## 9. CI later.
