using System;
using ItemChanger;
using ItemChanger.Locations;
using Steamworks;

namespace HallOfGodsRandomizer.IC 
{
    /// <summary>
    /// Each location should add an item when completing a tier for the first time.
    /// The method for setting statueState completion boolean values should be overriden.
    /// </summary>
    public enum Tier
    {
        Unlock,
        Attuned,
        Ascended,
        Radiant
    }
    
    public class StatueLocation : AutoLocation
    {
        public string statueStateName { get; set; }
        public Tier statueTier { get; set; }
        public string statueName { get; set; }
        public bool unlock { get; private set; }
        public bool attuned { get; private set; }
        public bool ascended { get; private set; }
        public bool radiant { get; private set; }

        protected override void OnUnload()
        {
            On.BossStatue.SetPlaqueState -= BossStatue_SetPlaqueState;
            On.BossStatue.UpdateDetails -= BossStatue_UpdateDetails;
        }

        protected override void OnLoad()
        {
            On.BossStatue.SetPlaqueState += BossStatue_SetPlaqueState;
            On.BossStatue.UpdateDetails += BossStatue_UpdateDetails;
        }

        private void BossStatue_UpdateDetails(On.BossStatue.orig_UpdateDetails orig, BossStatue self)
        {
            if (self.statueStatePD == statueStateName)
            {
                HallOfGodsRandomizer.Instance.Log($"BossStatue_UpdateDetails | {statueStateName}{statueTier}");

                // Save current statue state depending on settings
                if (HallOfGodsRandomizer.Instance.GS.MainSettings.RandomizeStatueAccess == Menu.StatueAccessMode.Randomized)
                {
                    unlock = self.StatueState.isUnlocked;
                }
                if (HallOfGodsRandomizer.Instance.GS.MainSettings.RandomizeTiers > Menu.TierLimitMode.Vanilla)
                {
                    attuned = self.StatueState.completedTier1;
                }
                if (HallOfGodsRandomizer.Instance.GS.MainSettings.RandomizeTiers > Menu.TierLimitMode.ExcludeAscended)
                {
                    ascended = self.StatueState.completedTier2;
                }
                if (HallOfGodsRandomizer.Instance.GS.MainSettings.RandomizeTiers > Menu.TierLimitMode.ExcludeRadiant)
                {
                    radiant = self.StatueState.completedTier3;
                }
            }
            orig(self);
            if (self.statueStatePD == statueStateName)
            {
                // Check the statue state matches with the stored variable, if there are mismatches, this is the critical event.
                if (HallOfGodsRandomizer.Instance.GS.MainSettings.RandomizeStatueAccess == Menu.StatueAccessMode.Randomized)
                {
                    HallOfGodsRandomizer.Instance.Log(unlock == self.StatueState.isUnlocked);
                }
                if (HallOfGodsRandomizer.Instance.GS.MainSettings.RandomizeTiers > Menu.TierLimitMode.Vanilla)
                {
                    HallOfGodsRandomizer.Instance.Log(attuned == self.StatueState.completedTier1);
                }
                if (HallOfGodsRandomizer.Instance.GS.MainSettings.RandomizeTiers > Menu.TierLimitMode.ExcludeAscended)
                {
                    HallOfGodsRandomizer.Instance.Log(ascended == self.StatueState.completedTier2);
                }
                if (HallOfGodsRandomizer.Instance.GS.MainSettings.RandomizeTiers > Menu.TierLimitMode.ExcludeRadiant)
                {
                    HallOfGodsRandomizer.Instance.Log(radiant == self.StatueState.completedTier3);
                }
            }   
        }

        private void BossStatue_SetPlaqueState(On.BossStatue.orig_SetPlaqueState orig, BossStatue self, BossStatue.Completion statueState, BossStatueTrophyPlaque plaque, string playerDataKey)
        {
            HallOfGodsRandomizer.Instance.Log($"BossStatue_SetPlaqueState | {statueStateName} {self.statueStatePD}");
            if (self.statueStatePD == statueStateName)
            {
                HallOfGodsRandomizer.Instance.Log($"BossStatue_SetPlaqueState | {statueStateName}{statueTier}");
                HallOfGodsRandomizer.Instance.Log($"self={self.statueStatePD} | statueState={statueState} | plaque={plaque} | pdk={playerDataKey}");
                if (!Placement.AllObtained() && statueTier == Tier.Unlock)
                {
                    HeroController.instance.RelinquishControl();
                    Placement.GiveAll(new()
                    {
                        FlingType = FlingType.DirectDeposit,
                        MessageType = MessageType.Any
                    }, HeroController.instance.RegainControl);
                }
            }
            orig(self, statueState, plaque, playerDataKey);
        }
    }
}