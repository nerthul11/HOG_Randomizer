using System;
using ItemChanger;
using ItemChanger.Locations;

namespace HallOfGodsRandomizer.IC {
    /// <summary>
    /// Each location should add an item when completing a tier for the first time.
    /// The method for setting statueState completion boolean values should be overriden.
    /// </summary>
    public enum Tier
    {
        Unlock = 0,
        Attuned = 1,
        Ascended = 2,
        Radiant = 3
    }
    
    public class StatueLocation : AutoLocation
    {
        public string statueName { get; set; }
        public Tier statueTier { get; set; }
        public string eventName { get; set; }

        public override GiveInfo GetGiveInfo() => new()
        {
           FlingType = flingType,
           Container = Container.Unknown,
           MessageType = MessageType.Corner
        };

        protected override void OnUnload()
        {
            On.BossStatue.SetPlaqueState -= BossStatue_SetPlaqueState;
            On.BossStatue.SetPlaquesVisible -= BossStatue_SetPlaquesVisible;
        }

        protected override void OnLoad()
        {
            On.BossStatue.SetPlaqueState += BossStatue_SetPlaqueState;
            On.BossStatue.SetPlaquesVisible += BossStatue_SetPlaquesVisible;
        }

        private void BossStatue_SetPlaquesVisible(On.BossStatue.orig_SetPlaquesVisible orig, BossStatue self, bool isEnabled)
        {
            HallOfGodsRandomizer.Instance.Log("SET PLAQUES VISIBLE HAS BEEN CALLED.");
            orig(self, isEnabled);
        }

        private void BossStatue_SetPlaqueState(On.BossStatue.orig_SetPlaqueState orig, BossStatue self, BossStatue.Completion statueState, BossStatueTrophyPlaque plaque, string playerDataKey)
        {
            HallOfGodsRandomizer.Instance.Log("SET PLAQUE STATE HAS BEEN CALLED.");
            orig(self, statueState, plaque, playerDataKey);
        }
    }
}