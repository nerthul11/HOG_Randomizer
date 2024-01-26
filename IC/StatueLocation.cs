using System;
using ItemChanger;
using ItemChanger.Locations;

namespace HallOfGodsRandomizer.IC 
{
    /// <summary>
    /// Each location should add an item when completing a tier for the first time.
    /// The method for setting statueState completion boolean values should be overriden.
    /// </summary>    
    
    public class StatueLocation : AutoLocation
    {
        public enum Tier
        {
            Unlock = -1,
            Attuned = 0,
            Ascended = 1,
            Radiant = 2
        }
        public string statueStateName { get; set; }
        public Tier statueTier { get; set; }
        public string lastBossScene { get; private set; }
        public int lastBossLevel { get; private set; }

        protected override void OnUnload()
        {
            On.BossChallengeUI.LoadBoss_int_bool -= BossChallengeUI_LoadBoss_int_bool;
            On.BossSceneController.Awake -= BossSceneController_Awake;
            On.BossStatue.SetPlaqueState -= BossStatue_SetPlaqueState;
            On.BossStatue.UpdateDetails -= BossStatue_UpdateDetails;
        }

        protected override void OnLoad()
        {
            On.BossChallengeUI.LoadBoss_int_bool += BossChallengeUI_LoadBoss_int_bool;
            On.BossSceneController.Awake += BossSceneController_Awake;
            On.BossStatue.SetPlaqueState += BossStatue_SetPlaqueState;
            On.BossStatue.UpdateDetails += BossStatue_UpdateDetails;
        }

        private void BossStatue_UpdateDetails(On.BossStatue.orig_UpdateDetails orig, BossStatue self)
        {
            if (statueTier == Tier.Unlock)
            {
            HallOfGodsRandomizer.Instance.ManageState(statueStateName, "isUnlocked", false);
            }
            if (statueTier == Tier.Attuned)
            {
            HallOfGodsRandomizer.Instance.ManageState(statueStateName, "completedTier1", false);
            }
            if (statueTier == Tier.Ascended)
            {
            HallOfGodsRandomizer.Instance.ManageState(statueStateName, "completedTier2", false);
            }
            if (statueTier == Tier.Radiant)
            {
            HallOfGodsRandomizer.Instance.ManageState(statueStateName, "completedTier3", false);
            }
            orig(self);
        }

        private void BossChallengeUI_LoadBoss_int_bool(On.BossChallengeUI.orig_LoadBoss_int_bool orig, BossChallengeUI self, int level, bool doHideAnim)
        {
            lastBossLevel = level;
            orig(self, level, doHideAnim);
        }

        private void BossSceneController_Awake(On.BossSceneController.orig_Awake orig, BossSceneController self)
        {
            lastBossScene = self.gameObject.scene.name;
            if ((int)statueTier == lastBossLevel && sceneName == lastBossScene)
            {
                self.BossLevel = lastBossLevel;
                self.DreamReturnEvent = "DREAM RETURN";
                self.OnBossesDead += delegate ()
                {
                    if (!Placement.AllObtained())
                    {
                        HeroController.instance.RelinquishControl();
                        Placement.GiveAll(new()
                        {
                            FlingType = FlingType.DirectDeposit,
                            MessageType = MessageType.Corner
                        }, HeroController.instance.RegainControl);
                    };
                };
                self.OnBossSceneComplete += self.DoDreamReturn;  
            };
            orig(self);
        }

        private void BossStatue_SetPlaqueState(On.BossStatue.orig_SetPlaqueState orig, BossStatue self, BossStatue.Completion statueState, BossStatueTrophyPlaque plaque, string playerDataKey)
        {
            if (self.statueStatePD == statueStateName)
            {
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