# Hall of Gods Randomizer

A Randomizer add-on for Hall of Gods statues.

## Description

This will randomize four locations for each HoG Boss and their effects:
- Unlock --> An item is granted when defeating a boss in the overworld.
- Attuned --> An item is granted when defeating the Attuned version.
- Ascended --> An item is granted when defeating the Ascended version.
- Radiant --> An item is granted when defeating the Radiant version.

The Statue_Mark items will improve the statue's state for each boss by 1, meaning you'll unlock the statue and then get the Attuned, Ascended and Radiant marks in progressive order. The amount of copies of this item will depend on the mod settings. Randomizing the statue access will add one copy, while randomizing the tier limits will add up to three extra copies, matching the four location types.

Requirements for the Void Idol will be defined by these locations instead of requiring the actual defeat of each boss.

All this should add up to a whopping total of 176 new items and locations to the Randomization pool!

## Settings:
- Enabled --> Boolean to define if the connection should be active or not.
- Randomize access --> Defines if the "Unlock" feature is randomized or vanilla.
- Limit --> Options: IncludeAll, ExcludeRadiant, ExcludeAscended, Vanilla. Defines which locations should be randomized and contain items and which should remain vanilla. Excluding Ascended also Excludes Radiant entries.

## Dependencies:
- ItemChanger
- MenuChanger
- Randomizer 4
- RandomizerCore

# Mod's current status

This mod is currently under development, and the following are the known steps meant to be dealt with before release.

- ~~Set up the settings and the connection menu.~~ (DONE)
- ~~Define terms, macros, waypoints, item and location logic.~~ (DONE)
- ~~Define item properties.~~ (DONE)
- Define location properties. (IN_PROGRESS)
- Build connections with other randomizer mods. (TO_DO)
- Assert all the previous steps function correctly. (TO_DO)