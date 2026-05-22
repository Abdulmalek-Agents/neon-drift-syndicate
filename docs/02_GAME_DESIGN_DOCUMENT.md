# 📜 Game Design Document — Neon Drift Syndicate

## 1. High-concept

Underground racing in **Neo-Halcyon City**. You're a new driver in The Syndicate — a loose faction that races for credits, reputation, and territory against rivals (Vexel Racing, Black Lotus, Stormbreak). Each race is a mission. The championship is six races; the winner takes the city.

**Fantasy:** 'I am the underground racing star with the AI co-pilot in my ear.'

**Emotional journey:** Curiosity → thrill → mastery → rivalry → triumph.

**Pillars:**
1. **Pick up + play.** 90 seconds from launch to first race.
2. **AI commentary is the heart.** Personality keeps replays fresh.
3. **Spectacle.** Neon + explosion VFX + drift sparks.

## 2. Core game loop

`Garage → Pick race → Pre-race banter (Claude AI) → Race → Post-race ranking → Spend credits on upgrades → Next race`

## 3. Player verbs

| Verb | Input | Notes |
|---|---|---|
| Throttle | W / RT | |
| Brake / reverse | S / LT | |
| Steer | A/D / LS | |
| Handbrake (drift) | Space / RB | Generates Boost |
| Boost | LeftShift / A button | Spends meter |
| Fire weapon | LMB | If equipped |
| Cycle weapon | Q | |
| Look back | C | |

## 4. Vehicle stats

5 vehicle archetypes from Modular Cyber Racing Cars:
- **Striker** (balanced)
- **Velocity** (top speed, weak corners)
- **Driftking** (peak handling)
- **Bulwark** (HP + ram damage)
- **Phantom** (cloaking gimmick)

## 5. Mission structure (6 races + grand finale)

| # | Race | Track | Faction rival | Weapon intro |
|---|---|---|---|---|
| **1** | *Tutorial: First Lap* | Garage + warm-up track | None (AI ghost) | None |
| 2 | *Skylane Sprint* | Elevated highway | Vexel | EMP pulse |
| 3 | *Underbelly Run* | Industrial tunnels | Black Lotus | Oil slick |
| 4 | *Reactor Loop* | Station ring | Stormbreak | Homing missile |
| 5 | *Sunset Strip* | Coastal high-speed | Vexel rematch | Boost mine |
| 6 | *Championship: Crown Circuit* | All-faction final | All three | All unlocked |

## 6. Mission 1 — *Tutorial: First Lap*

**Duration:** 8–12 min. **Goal:** Tutorialise driving, drift, boost; introduce Commentator.

**Flow:**
1. Garage scene — Commentator (Claude) greets player by car.
2. Race start — 5-lap warm-up oval with one AI ghost.
3. Commentator narrates milestones: 'First corner!', 'Drift achieved!', 'You overtook!'.
4. End-of-race results screen.

**Objectives:**
- `m1_throttle` (Custom, 1)
- `m1_first_drift` (Custom, 1)
- `m1_first_boost` (Custom, 1)
- `m1_complete_5_laps` (Custom, 5)
- `m1_overtake_ghost` (Custom, 1, optional)

## 7. Economy

- **Credits** earned per race, scaled by position + drift score + weapons-used.
- **Reputation** unlocks new races and faction story beats.
- Upgrade tree: Engine / Handling / Armor / Weapon slot.

## 8. AI Commentator (Claude)

Three roles:
1. **Pre-race banter** (Claude one-liner).
2. **Milestone announcements** during race (lap, overtake, drift score breakthrough).
3. **Rival trash-talk** — between races, rival drivers chat at you with persona-driven lines.

Full spec in `docs/05_AI_COPILOT_INTEGRATION.md`.

## 9. UI

- Heat UI base.
- HUD: speedometer, RPM, lap counter, position, boost meter, weapon slot, mini-map.
- Commentator subtitles toggleable.

## 10. Audio

- Synthwave OST (commission).
- Engine + drift screech: from Edy's Vehicle Physics audio pack.
- Commentator text-to-speech (optional cached).

## 11. Accessibility

- Auto-drift assist toggle.
- Auto-boost on full meter.
- Colourblind mini-map.
- Controller + keyboard parity.

## 12. Cut-list

1. Phantom cloaking vehicle.
2. Mission 5 (Sunset Strip) deferred.
3. Voice synth Commentator — text first.

**Never cut:** Tutorial Race, Commentator persona, faction rivalry.

✅ **Approved.**
