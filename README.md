# 🏎️ Neon Drift Syndicate

> Underground cyberpunk racing with weapons. You drive for a faction that doesn't officially exist, in a city that doesn't legally permit racing.

| | |
|---|---|
| **Genre** | Cyberpunk Arcade Racer + Light Vehicle Combat |
| **Platforms** | PC (Steam) primary; potential Switch |
| **Engine** | Unity **6 LTS (6000.4.4f1)** + URP |
| **Target frame-rate** | 60 fps min, 120 fps target on RTX 3070 |
| **Mission 1 scope** | Tutorial race + intro to faction + first weapon pickup |
| **Designed for** | 6 missions (tutorial → 5 faction races escalating to championship) |
| **Runtime AI features** | **None** — the shipping game is fully offline and self-contained. Commentator draws from hand-authored line banks. |
| **AI in development** | Claude Code & Claude Agents are used by the studio. See [docs/05_AI_ASSISTED_DEVELOPMENT.md](docs/05_AI_ASSISTED_DEVELOPMENT.md). |

## Why this game

| Signal | Source |
|---|---|
| Synthwave/cyberpunk aesthetic is mainstream | Hotshot Racing, Distance, Cyberpunk 2077 halo |
| Asset Store ships 'Complete Racing Game 2' — dropping dev time massively | ~90% framework coverage |
| Modular Cyber Racing Cars asset is on hand | Vehicle variety with zero modelling |
| Edy's Vehicle Physics is well-established | 10+ years of polish |

Details in `docs/01_IDEATION_AND_TRENDS.md`.

## Quick start

1. Read `docs/07_UNITY_SETUP_GUIDE.md`.
2. Unity **6 LTS (6000.4.4f1)** URP; copy `Assets/_Project/`.
3. Import: **Complete Racing Game 2** (template foundation), Modular Cyber Racing Cars, Edy's Vehicle Physics, Neon Interior Props, Sci-Fi Space Stations Creator, City Pack, UNI VFX Missiles & Explosions, Heat UI, Lumen FX 2 — from inventory.
4. Open `Scenes/Bootstrap.unity`.

> No proxy server, no API key, no internet config required.

## Status

| Stage | Status |
|---|---|
| Concept locked (3 critic cycles) | ✅ |
| GDD v1.0 approved | ✅ |
| Architecture & scripts | ✅ |
| v0.2 — runtime LLM removed, Commentator uses LineBanks | ✅ |
| v0.2.1 — Unity 6 LTS (6000.4.4f1) target | ✅ |
| Mission 1 (Tutorial Race) | ⏳ needs asset import |
