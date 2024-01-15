using ItemChanger;
using ItemChanger.Locations;
using System.Reflection;
using UnityEngine;

namespace HallOfGodsRandomizer.IC {
    /// <summary>
    /// Each location should add an item when completing a tier for the first time.
    /// The method for setting boolean values as true should be overriden in the original functions.
    /// </summary>
    public enum Tier
    {
        Unlock = 0,
        Attuned = 1,
        Ascended = 2,
        Radiant = 3
    }
    public class HOG_Location : AutoLocation
    {
        public string bossName;
        public Tier locationTier;

        public override GiveInfo GetGiveInfo() => new()
        {
           FlingType = flingType,
           Callback = null,
           Container = Container.Unknown,
           MessageType = MessageType.Corner
        };

        public HOG_Location(string bossName, Tier locationTier)
        {
            this.bossName = bossName;
            this.locationTier = locationTier;
        }
        protected override void OnUnload()
        {
            var tierSwitch = this.locationTier == 0 ? "isUnlocked" : $"completedTier{this.locationTier}";
            PropertyInfo statueSwitch = PlayerData.instance.GetType().GetProperty(this.bossName).GetType().GetProperty(tierSwitch);
        }

        protected override void OnLoad()
        {
        }
    }
}