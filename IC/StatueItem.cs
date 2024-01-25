using HallOfGodsRandomizer.Menu;
using ItemChanger;
using System;

namespace HallOfGodsRandomizer.IC
{
    public class StatueItem : AbstractItem
    {
        public string statueStateName { get; set; }
        public override void GiveImmediate(GiveInfo info)
        {
            BossStatue.Completion statueCompletion = PlayerData.instance.GetVariable<BossStatue.Completion>(statueStateName);
            if (!statueCompletion.isUnlocked && HallOfGodsRandomizer.Instance.GS.MainSettings.RandomizeStatueAccess == StatueAccessMode.Randomized)
            {
                HallOfGodsRandomizer.Instance.ManageState(statueStateName, "isUnlocked", true);
            }
            else if (!statueCompletion.completedTier1 && HallOfGodsRandomizer.Instance.GS.MainSettings.RandomizeTiers > TierLimitMode.Vanilla)
            {
                HallOfGodsRandomizer.Instance.ManageState(statueStateName, "completedTier1", true);
            }
            else if (!statueCompletion.completedTier2 && HallOfGodsRandomizer.Instance.GS.MainSettings.RandomizeTiers > TierLimitMode.ExcludeAscended)
            {
                HallOfGodsRandomizer.Instance.ManageState(statueStateName, "completedTier2", true);
            }
            else if (!statueCompletion.completedTier3 && HallOfGodsRandomizer.Instance.GS.MainSettings.RandomizeTiers > TierLimitMode.ExcludeRadiant)
            {
                HallOfGodsRandomizer.Instance.ManageState(statueStateName, "completedTier3", true);
            }
            else
            {
                throw new NotImplementedException("The item had no effect due to logic inconsistencies.");
            }
        }
    }
}