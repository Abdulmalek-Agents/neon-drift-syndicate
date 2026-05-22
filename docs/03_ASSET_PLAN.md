# 🎨 Asset Plan — Neon Drift Syndicate

## 1. Inventory used

| Asset | Used for | Critical |
|---|---|---|
| **Complete Racing Game 2** ($99) | Race framework, AI driver baseline, position system, results screen | 🔴 Yes |
| **Modular Cyber Racing Cars** ($79) | 5 vehicle archetypes + parts | 🔴 Yes |
| **Edy's Vehicle Physics** ($60) | Drive feel, suspension, drift | 🔴 Yes |
| **Neon Interior Props** ($80) | Garage + neon track decor | 🔴 Yes |
| **Sci-Fi Space Stations Creator** ($75) | M4 Reactor Loop track | 🟡 Helpful |
| **City Pack** ($144.99) | M2 Skylane + city ambient | 🔴 Yes |
| **Urban Abandoned District** | M3 Underbelly tunnels | 🟡 Helpful |
| **Industrial Props Mega Bundle** | M3 tunnel detail | 🟡 Helpful |
| **UNI VFX Missiles & Explosions** ($16.99) | Weapon VFX | 🔴 Yes |
| **Lumen FX 2** ($35) | Neon glows, sun glare M5 | 🔴 Yes |
| **Casual RPG VFX** | Drift sparks, level-up | 🟡 Helpful |
| **Screenspace VFX** | Speed lines, damage flash | 🔴 Yes |
| **Heat UI** ($69.99) | Main menu, HUD | 🔴 Yes |
| **Cutscene Engine** ($35) | Race intro, faction reveals | 🔴 Yes |
| **Game UI & Puzzle SFX Pack** | Menu sounds | 🟡 Helpful |

**Inventory value applied: ~$700 across 15 assets.**

## 2. Must-buy

| Gap | Cost |
|---|---|
| Synthwave OST (6 tracks) | $300 |
| Track barriers/checkpoints unique props | $30 |
| Optional voice synth Commentator | API cost |

## 3. Folder org — standard `_Project/Art/{Vehicles,Tracks,Environment,VFX,UI}`

## 4. Performance

- Edy's vehicles use single Rigidbody; cull distant car visuals.
- All weapon VFX through ObjectPool.
- Mini-map render at 30Hz, not per-frame.
- LOD on all vehicles + buildings.

## 5. Licence ✅. No binaries.

## 6. Checklist

- [ ] Import all assets
- [ ] Configure Edy's car prefab with Cyber Cars body parts
- [ ] Build 5 vehicle prefabs with stat differences
- [ ] Author Tutorial Track
- [ ] Hook RaceManager to Complete Racing Game 2 base
- [ ] Configure Heat UI HUD
- [ ] Wire Commentator to Claude proxy
