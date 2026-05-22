# 🛠️ Unity Setup Guide — Neon Drift Syndicate

> **v0.2.1: Unity 6 LTS (6000.4.4f1) target. No proxy server, no API key, no internet config required.**

## Prerequisites
- Unity Hub + Unity **6 LTS (6000.4.4f1)** with Windows IL2CPP module
- Assets per `03_ASSET_PLAN.md` in Inventix account

## Step 1 — New Unity project
Unity Hub → select Editor **6000.4.4f1** → template **Universal 3D** → `NeonDriftSyndicate`.

## Step 2 — Drop repo in
```bash
git clone https://github.com/Abdulmalek-Agents/neon-drift-syndicate.git
```
Copy `Assets/_Project/` + `.gitignore`.

## Step 3 — Pipeline
Graphics URP 17.x. Linear colour space. High Quality preset for PC.

## Step 4 — Import order
1. Heat UI
2. Edy's Vehicle Physics
3. Complete Racing Game 2 (large template)
4. Modular Cyber Racing Cars
5. Neon Interior Props
6. City Pack
7. Sci-Fi Space Stations Creator
8. Urban Abandoned District
9. Industrial Props Mega Bundle
10. UNI VFX Missiles & Explosions
11. Lumen FX 2
12. Casual RPG VFX
13. Screenspace VFX
14. Cutscene Engine
15. Game UI & Puzzle SFX Pack

Move asset folders into `Assets/_Project/Art/`.

> **Unity 6 note:** if any package imports with pink materials, run **Edit → Rendering → Render Pipeline Converter → Built-in to URP**. If Edy's Vehicle Physics requests an update prompt, take the latest — Edy publishes a Unity-6-tested build.

## Step 5 — Bootstrap scene
Empty scene `Scenes/Bootstrap.unity` → `[Game]` with `GameBootstrap`. Build idx 0.

## Step 6 — MainMenu
Use Heat UI main menu prefab. `MainMenuController` attached. Mission database wired. Build idx 1.

## Step 7 — Mission 1 — Tutorial track
1. New scene `Mission01_Tutorial.unity`.
2. Drop a Complete Racing Game 2 track or build a simple oval with Modular Cyber Racing track tiles + Neon Interior Props for ambient.
3. Place 4 spline-based track segments + 1 LapTrigger at start/finish.
4. Player_Striker.prefab at grid spawn + 1 AIDriver_Ghost.prefab.
5. **Unity 6 camera:** add a `CinemachineCamera` with `CinemachineThirdPersonFollow` (Cinemachine 3.x replacement for the old chase-cam).
6. RaceManager + Mission01Director + `RaceCommentator` GameObjects.
7. Create `MissionData_M01.asset` with 5 objectives (GDD §6).

Build idx 3 (Garage at 2).

## Step 8 — Author the Commentator + Rival line banks

1. **Create → Inventix → Dialogue → Line Bank** six times for the Commentator:
   - `LineBank_Commentator_RaceStart.asset` (20 hype calls)
   - `LineBank_Commentator_Overtake.asset` (50 calls, ≤12 words each)
   - `LineBank_Commentator_BigDrift.asset` (30 calls)
   - `LineBank_Commentator_LapComplete.asset` (25 calls)
   - `LineBank_Commentator_RaceFinish.asset` (20 calls)
   - `LineBank_Commentator_IdleChatter.asset` (40 filler lines)
2. Drag each into the corresponding field on `RaceCommentator`.
3. (Optional) create 3 rival banks (`LineBank_Rival_Vexel_PreRace.asset`, etc.) for the Garage cut-scene.
4. (Optional) drop wav clips into the `voiceOver` array.

Voice guide: kinetic, hype, occasionally sardonic. Cyberpunk register.

## Step 9 — Playtest
Bootstrap → New Game → M01 loads → 5 laps with Commentator narration on race start / overtakes / lap complete / finish → Mission Complete.

## Troubleshooting

| Symptom | Fix |
|---|---|
| Car falls through track | MeshCollider missing on track segments |
| AI driver drives backwards | Spline direction flipped; check Unity Splines tool |
| Commentator silent | LineBanks not assigned on `RaceCommentator` |
| `CinemachineFreeLook` missing | Unity 6 — use CinemachineCamera + CinemachineThirdPersonFollow |
| Pink materials | Render Pipeline Converter (Built-in → URP) |
| Tyre screech missing | Edy's audio mixer not configured |

## After M1
Tag `v0.2.1-mission1-playable`. M2: new track scene + new MissionData + EMP weapon prefab.
