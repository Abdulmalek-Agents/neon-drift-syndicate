# 🛠️ Unity Setup Guide — Neon Drift Syndicate

## Prerequisites
- Unity 2022.3.30f1 LTS + Windows IL2CPP
- Assets per `03_ASSET_PLAN.md` in Inventix account
- Node.js 18+
- Anthropic API key

## Step 1 — New Unity project
3D (URP) Core → `NeonDriftSyndicate`.

## Step 2 — Drop repo in
```bash
git clone https://github.com/Abdulmalek-Agents/neon-drift-syndicate.git
```
Copy `Assets/_Project/` + `.gitignore`.

## Step 3 — Pipeline
Graphics URP. Linear colour space. High Quality preset for PC.

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

## Step 5 — Bootstrap scene
Empty scene `Scenes/Bootstrap.unity` → `[Game]` with `GameBootstrap`. Build idx 0.

## Step 6 — MainMenu
Use Heat UI main menu prefab. `MainMenuController` attached. Mission database wired. Build idx 1.

## Step 7 — Mission 1 — Tutorial track
1. New scene `Mission01_Tutorial.unity`.
2. Drop a Complete Racing Game 2 track or build a simple oval with Modular Cyber Racing track tiles + Neon Interior Props for ambient.
3. Place 4 spline-based track segments + 1 LapTrigger at start/finish.
4. Player_Striker.prefab at grid spawn + 1 AIDriver_Ghost.prefab.
5. RaceManager + Mission01Director GameObjects.
6. Create `MissionData_M01.asset` with 5 objectives (GDD §6).

Build idx 3 (Garage at 2).

## Step 8 — AI proxy
```bash
cd server/copilot-proxy && cp .env.example .env  # set ANTHROPIC_API_KEY
npm install && npm run dev
```

## Step 9 — Personas
Create `Persona_Commentator.asset`, `Persona_Kira_Vexel.asset`, `Persona_Doctor_Mosaic.asset`, `Persona_Bear_Stormbreak.asset`.

## Step 10 — Playtest
Bootstrap → New Game → M01 loads → 5 laps with commentator narration → Mission Complete.

## Troubleshooting

| Symptom | Fix |
|---|---|
| Car falls through track | MeshCollider missing on track segments |
| AI driver drives backwards | Spline direction flipped; check Unity Splines tool |
| Commentator silent | Proxy down or Persona_Commentator not assigned |
| Tyre screech missing | Edy's audio mixer not configured |

## After M1
Tag `v0.1-mission1-playable`. M2: new track scene + new MissionData + EMP weapon prefab.
