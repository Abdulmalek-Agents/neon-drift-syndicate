# 🤖 AI-Assisted Development — Neon Drift Syndicate

> **Important:** AI is a **development tool**, not a runtime feature.
> No part of the shipping game calls an LLM at runtime. Every commentator call,
> every pre-race banter line, every rival trash-talk between races is hand-authored
> into `LineBankSO` pools. Voice-over actors record them in advance.
> Claude (via Claude Code and Claude Agents) is used by the studio to speed up
> design, code, asset wiring, dialogue writing, and QA — never by the player.

## 1. What the studio uses Claude for

| Phase | What Claude does | What humans do |
|---|---|---|
| Concept & trend research | Pulls cyberpunk racer signals, drift-game data | Final greenlight |
| GDD authoring | Drafts Mission 1–6 tracks, faction lore, vehicle balance | Pillar checks |
| Code generation | Produces ScriptableObjects, race loop, drift scoring, weapon pickups, AI driver state machine | Senior dev review + Unity wiring |
| Commentator-line writing | Drafts 60–100 lines per event-bank in the kinetic-cyberpunk-DJ voice | Writers polish, VO direction |
| QA & playtesting | Authors lap-time benchmark sheets, drift-score regressions | Manual play |

## 2. Why we removed runtime LLM features (v0.1 → v0.2)

| Concern | v0.1 (runtime commentator LLM) | v0.2 (hand-authored banks) |
|---|---|---|
| Tone consistency | LLM may break cyberpunk register | 100% authored lines, VO-ready |
| Internet dependency | Phones home each race | Fully offline |
| Per-DAU cost | ~$0.002 per race | $0 |
| Latency | 600–2,000 ms during peak race action | Instant playback |
| QA repro for racing line tuning | Hard | Deterministic |
| Voice-over recording | Impossible | Trivial — fixed line set |

## 3. How Claude shows up in the dev workflow

1. **Plan** — GDD drafts.
2. **Code** — Claude Code generates Unity C# into branch PRs.
3. **Review** — Critic & Review Board persona panel audits.
4. **Wire** — Click-by-click Unity Editor instructions.
5. **Author content** — Commentator lines, rival trash-talk, track flavour.
6. **Test** — Lap-time + drift-score sheets.
7. **Ship** — Only the compiled game ships. No LLM at runtime.

## 4. The shipping game's dialogue stack

| Type | When | Author tool |
|---|---|---|
| `LineBankSO` | Commentator calls (race start, overtake, drift, lap, finish, idle chatter) | Inspector edit + Claude drafts |
| `LineBankSO` | Rival trash-talk between races | Same |
| `DialogueNodeSO` | Optional garage NPC briefings | Inspector edit |

## 5. Example: authoring `LineBank_Commentator_Overtake.asset` with Claude in the loop

1. Writer asks Claude: *"Draft 50 short commentator calls for overtakes. Kinetic, hype, occasionally sardonic. Max 12 words each. No real-world slurs. Cyberpunk register — think Mike Goldberg meets Hideo Kojima."*
2. Claude returns 50 lines as a YAML list.
3. Writer creates `LineBank_Commentator_Overtake.asset`, pastes lines, drags into `RaceCommentator.overtakeBank`.
4. Optional: record each line with ElevenLabs / live VO, drop into the `voiceOver` array.

## 6. What replaced what

| v0.1 (deleted) | v0.2 (replacement) |
|---|---|
| `Persona_Commentator.asset` (systemPrompt) | `LineBank_Commentator_*.asset` (6 banks, 50+ lines each) |
| `Persona_Vexel/Mosaic/Stormbreak.asset` | `LineBank_Rival_<Name>.asset` per rival |
| `AICopilotPersonaSO.cs` | (deleted) |
| `ClaudeCopilotService.cs` | `ScriptedDialogueService.cs` |
| `server/copilot-proxy/` | (deleted) |

## 7. What the user must do after cloning

1. Open Unity project per `docs/07`.
2. Buy & import asset packs per `docs/03`.
3. Drag prefabs / wire scenes per `docs/07`.
4. **No proxy server, no API key, no internet config required.**
