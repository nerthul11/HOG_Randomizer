This mod will no longer receive support. Please head to https://github.com/nerthul11/GodhomeRandomizer as it contains everything included here.

# Hall of Gods Randomizer

A Randomizer add-on for Hall of Gods statues.

## Description

This will randomize four locations for each HoG Boss and their effects:
- Unlock --> An item is granted when interacting with a statue for the first time.
- Attuned --> An item is granted when defeating the Attuned version.
- Ascended --> An item is granted when defeating the Ascended version.
- Radiant --> An item is granted when defeating the Radiant version.

The Statue_Mark items will improve the statue's state for each boss by 1, meaning you'll unlock the statue and then get the Attuned, Ascended and Radiant marks in progressive order. The amount of copies of this item will depend on the mod settings. Randomizing the statue access will add one copy, while randomizing the tier limits will add up to three extra copies, matching the four location types.

Requirements for the Void Idol will be defined by these locations instead of requiring the actual defeat of each boss. This includes integration with mods that use locations in the Hall of Gods.

All this can add up to a whopping total of 176 new items and locations to the Randomization pool!

## Settings:
- Enabled --> Boolean to define if the connection should be active or not.
- Randomize access --> Defines if statue access is vanilla, randomized or if all of them are unlocked by default. This last option will likely force you to fight Godhome bosses earlier in the progression.
- Limit --> Options: IncludeAll, ExcludeRadiant, ExcludeAscended, Vanilla. Defines which locations should be randomized and contain items and which should remain vanilla. Excluding Ascended also Excludes Radiant entries.

## Dependencies:
- ItemChanger
- KorzUtils (for the moment, might remove in future patches if I get a better understanding of sprite rendering)
- MenuChanger
- Randomizer 4
- RandomizerCore

## Integrations
- RandoSettingsManager
- RandoMapMod (may be improved)
- A few other connections logic

## Known issues

- If every single other Randomizer settings are vanilla AND statue access is randomized, there could be unreachable location issues.
- Having AllUnlocked without randomizing any tier makes the locations behave like in Vanilla.
