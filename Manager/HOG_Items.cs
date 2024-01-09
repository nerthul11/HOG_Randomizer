using ItemChanger.Items;

namespace HallOfGodsRandomizer.Manager {

    public class HOG_Item : BoolItem {
        /// <summary>
        /// All items are boolean and will affect "statueStateBOSSNAME" properties.
        /// 
        /// Tier 1 will affect "isUnlocked"
        /// Tier 2 will affect "completedTier1"
        /// Tier 3 will affect "completedTier2"
        /// Tier 4 will affect "completedTier3"
        /// 
        /// When called, two parameters should be used: Boss name and item tier.
        /// 
        /// At some place, the original setting of the switches must be overriden.
        /// </summary>
    }
}