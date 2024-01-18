# Hall of Gods Randomizer

A Randomizer add-on for Hall of Gods statues.

## Description

This will randomize four locations for each HoG Boss and their effects:
- Unlock --> An item is granted when defeating a boss in the overworld.
- Attuned --> An item is granted when defeating the Attuned version.
- Ascended --> An item is granted when defeating the Ascended version.
- Radiant --> An item is granted when defeating the Radiant version.

Likewise, there will be two new item classes affecting these locations:
- Statue Unlock --> Instead of unlocking when a boss is defeated, the "Statue_Unlock-{BOSS_NAME}" item will be required.
- Statue Mark --> Each item will improve the Statue_Mark for each boss by 1, meaning you'll get the Attuned, Ascended and Radiant marks in progressive order. Three copies of this item will be present for each boss, each of them representing one of the boss tiers.

Requirements for the Void Idol will be defined by these locations instead of requiring the actual defeat of each boss.

All this should add a whopping total of 176 new items and locations to the Randomization pool!

Settings:
- Enabled --> Boolean to define if the connection should be active or not.
- Limit --> Options: Attuned, Ascended, Radiant. Defines which locations should be randomized and contain items and which should remain vanilla.
- Randomize access --> Defines if the "Unlock" feature is randomized or vanilla.

Dependencies:
- ItemChanger
- MenuChanger
- Randomizer 4
- RandomizerCore

## Current status

This mod is currently under development, and the following are the known steps meant to be dealt with before release.

- ~~Set up the settings and the connection menu.~~ (DONE)
- ~~Define terms, macros, waypoints, item and location logic.~~ (DONE)
- Define item and location properties. (IN_PROGRESS)
- Define FSM changes for all locations. (TO_DO)
- Build connections with other randomizer mods. (TO_DO)
- Assert all the previous steps function correctly. (TO_DO)