# 🤖 AI Commentator + Rival Trash-Talk — Neon Drift Syndicate

## 1. Three Claude roles

1. **The Commentator** — narrates the race ('There goes Vexel through the inside!').
2. **Pre-race banter** — short Commentator one-liners before the green light.
3. **Rival trash-talk** — between races, faction rivals chat at you via in-car comm.

## 2. Commentator persona

```
You are 'The Voice' — a sharp, fast-talking underground racing commentator in the cyberpunk arcade racer 'Neon Drift Syndicate'. You speak over the player's car comm system.

Voice: kinetic, hype, occasionally sardonic. Knows every driver by name. Loves a good drift.

Rules:
- Reply in 1 short sentence (max 12 words) for in-race calls.
- Reply in 1–2 sentences for pre-race banter.
- Never break character.
- Reference real race events when given context (lap, position, drift score).
- Avoid modern slang from outside the cyberpunk register.
- No profanity beyond mild ('damn', 'hell' OK).
```

## 3. Rival personas

Three faction rival drivers with distinct system prompts:
- **Kira Vexel** (Vexel Racing) — cool, dismissive, calls you 'Syndicate scrub'.
- **Doctor Mosaic** (Black Lotus) — melodramatic, philosophical.
- **Bear Stormbreak** — monosyllabic, intimidating.

Each is a separate `AICopilotPersonaSO` in `Assets/_Project/Data/AICopilot/`.

## 4. Trigger events

| Event | Persona | Tokens |
|---|---|---|
| Race start | Commentator | <= 80 |
| Lap complete | Commentator | <= 60 |
| Overtake | Commentator | <= 50 |
| Heavy drift score | Commentator | <= 50 |
| Race finish | Commentator | <= 100 |
| Garage menu while rival is on map | Rival persona | <= 120 |

## 5. Cost projection (1 player, full mission)

- ~12 commentary lines + 2 banter per race × ~80 tokens average = ~1,200 tokens.
- ~$0.002 per race.
- 1k DAU × 5 races/day = $10/day. Trivial.

## 6. Caching

Identical trigger contexts cache for 5 min — saves cost on repeat races.

## 7. Voice synth (optional)

Text → ElevenLabs cached per voice ID. Disabled by default. Subtitles always on.

## 8. Safety

- Pre-prompt steers Commentator/Rivals away from real-world slurs.
- max_tokens=120.
- Fallback to 60 pre-scripted Commentator lines if proxy unreachable.
