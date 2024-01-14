using MenuChanger.Attributes;
using System;

namespace HallOfGodsRandomizer.Menu
{
    [Flags]
    public enum StatueAccessMode
    {
        Vanilla = 0,
        Randomized = -1
    }
    [Flags]
    public enum TierLimitMode
    {
        IncludeAll = 3,
        ExcludeRadiant = 2,
        ExcludeAscended = 1,
        ExcludeAll = 0
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