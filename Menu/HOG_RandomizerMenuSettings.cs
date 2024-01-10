using MenuChanger.Attributes;
using System;

namespace HallOfGodsRandomizer
{
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
        [MenuLabel("HOG Statue access")]
        public bool RandomizeAccess { get; set; } = false;
        [MenuLabel("HOG Battle randomization")]
        public TierLimitMode RandomizeTiers { get; set; } = TierLimitMode.IncludeAll;
    }
}