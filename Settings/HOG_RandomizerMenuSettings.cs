using MenuChanger.Attributes;
using System;

namespace HallOfGodsRandomizer.Settings
{
    [Flags]
    public enum StatueAccessMode
    {
        /// <summary>
        /// Statues will be unlocked the same way they are in the original game.
        /// </summary>
        Vanilla,
        /// <summary>
        /// Statues will be unlocked after obtaining a Statue Mark for them.
        /// </summary>
        Randomized,
        /// <summary>
        /// Statues will always be unlocked.
        ///
        AllUnlocked
    }
    [Flags]
    public enum TierLimitMode
    {
        /// <summary>
        /// All Hall of Gods tiers will be randomized.
        /// </summary>
        IncludeAll = 3,
        /// <summary>
        /// Attuned and Ascended Hall of Gods marks will be randomized.
        /// </summary>
        ExcludeRadiant = 2,
        /// <summary>
        /// Attuned Hall of Gods marks will be randomized.
        /// </summary>
        ExcludeAscended = 1,
        /// <summary>
        /// All Hall of Gods tiers will have vanilla behaviour.
        /// </summary>
        Vanilla = 0
    }

    public class HallOfGodsRandomizationSettings
    {
        public bool Enabled { get; set; } = true;
        [MenuLabel("HOG Statue access")]
        public StatueAccessMode RandomizeStatueAccess { get; set; } = StatueAccessMode.Vanilla;
        [MenuLabel("HOG Battle randomization")]
        public TierLimitMode RandomizeTiers { get; set; } = TierLimitMode.Vanilla;
    }
}