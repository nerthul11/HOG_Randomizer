using HallOfGodsRandomizer.Manager;
using HallOfGodsRandomizer.Settings;
using ItemChanger;
using ItemChanger.Locations;

namespace HallOfGodsRandomizer.IC 
{    
    public class StatueLocation : AutoLocation
    {
        public enum Tier
        {
            Unlock = -1,
            Attuned = 0,
            Ascended = 1,
            Radiant = 2
        }
        public string battleScene { get; set; }
        public string statueStateName { get; set; }
        public Tier statueTier { get; set; }
        public string lastBossScene { get; private set; }
        public int lastBossLevel { get; private set; }


        protected override void OnUnload()
        {
            On.BossScene.IsUnlocked -= BossScene_IsUnlocked;
            On.BossStatue.SetPlaqueState -= BossStatue_SetPlaqueState;
            On.BossChallengeUI.LoadBoss_int_bool -= BossChallengeUI_LoadBoss_int_bool;
            On.BossSceneController.Awake -= BossSceneController_Awake;
            On.BossStatue.UpdateDetails -= BossStatue_UpdateDetails;
        }

        protected override void OnLoad()
        {   
            On.BossScene.IsUnlocked += BossScene_IsUnlocked;
            On.BossStatue.SetPlaqueState += BossStatue_SetPlaqueState;
            On.BossChallengeUI.LoadBoss_int_bool += BossChallengeUI_LoadBoss_int_bool;
            On.BossSceneController.Awake += BossSceneController_Awake;
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

        private void BossStatue_SetPlaqueState(On.BossStatue.orig_SetPlaqueState orig, BossStatue self, BossStatue.Completion statueState, BossStatueTrophyPlaque plaque, string playerDataKey)
        {
            bool locationMatch = self.UsingDreamVersion && self.dreamStatueStatePD == statueStateName || !self.UsingDreamVersion && self.statueStatePD == statueStateName;
            if (self.StatueState.isUnlocked == true && statueTier == Tier.Unlock && locationMatch)
            {
                if (!Placement.AllObtained())
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
        

        private bool BossScene_IsUnlocked(On.BossScene.orig_IsUnlocked orig, BossScene self, BossSceneCheckSource source)
        {
            if (GameManager.instance.sceneName == SceneNames.GG_Workshop)
            {
                if (HOG_Interop.Settings.RandomizeStatueAccess == StatueAccessMode.AllUnlocked)
                    return true;
                
                if (HOG_Interop.Settings.RandomizeStatueAccess == StatueAccessMode.Randomized && battleScene == self.Tier1Scene)
                {
                    BossStatue.Completion completion = PlayerData.instance.GetVariable<BossStatue.Completion>(statueStateName);
                    return completion.isUnlocked;
                }
            }
            return orig(self, source);
        }

        private void BossChallengeUI_LoadBoss_int_bool(On.BossChallengeUI.orig_LoadBoss_int_bool orig, BossChallengeUI self, int level, bool doHideAnim)
        {
            lastBossLevel = level;
            orig(self, level, doHideAnim);
        }

        private void BossSceneController_Awake(On.BossSceneController.orig_Awake orig, BossSceneController self)
        {
            lastBossScene = self.gameObject.scene.name;
            if ((int)statueTier == lastBossLevel && battleScene == lastBossScene)
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
    }
}