using System.Reflection;
using ItemChanger.Items;

namespace HallOfGodsRandomizer.Manager {

    public class HOG_Item : BoolItem {
        /// <summary>
        /// All items are boolean and will affect "statueStateBOSSNAME" properties.
        /// By default, they should be initialized to -1.
        /// If StatueAccess in settings is set to Vanilla, then it's initialized to 0.
        /// 
        /// Tier 0 will affect "isUnlocked" if StatueAccess is randomized.
        /// Tier 1 will affect "completedTier1"
        /// Tier 2 will affect "completedTier2"
        /// Tier 3 will affect "completedTier3"
        /// 
        /// When called, two parameters should be used: Boss name and item tier.
        /// 
        /// At some place, the original setting of the switches must be overriden.
        /// </summary>
        public string statue;
        public int tier;

        public HOG_Item(string statue, int tier)
        {
            this.statue = $"statueState{statue}";
            this.tier = tier;
            var tierSwitch = this.tier == 0 ? "isUnlocked" : $"completedTier{this.tier}";
            PropertyInfo statueSwitch = PlayerData.instance.GetType().GetProperty(this.statue).GetType().GetProperty(tierSwitch);
            statueSwitch.SetValue(statueSwitch, true);
        }
    }
}