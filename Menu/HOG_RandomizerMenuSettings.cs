using MenuChanger.Attributes;
using System;

namespace HallOfGodsRandomizer.Menu
{
    [Flags]
    public enum StatueAccessMode
    {
        /// <summary>
        /// Statues will be unlocked the same way they are in the original game.
        /// </summary>
        Vanilla = 0,
        /// <summary>
        /// Statues will be unlocked after obtaining a Statue Mark for them.
        /// </summary>
        Randomized = 1
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

    public class HOG_RandomizationSettings
    {
        public bool Enabled;
        [MenuLabel("HOG Statue access")]
        public StatueAccessMode RandomizeStatueAccess { get; set; } = StatueAccessMode.Randomized;
        [MenuLabel("HOG Battle randomization")]
        public TierLimitMode RandomizeTiers { get; set; } = TierLimitMode.IncludeAll;
    }
}