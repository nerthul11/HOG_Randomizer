using HallOfGodsRandomizer.Menu;
using ItemChanger;
using System;

namespace HallOfGodsRandomizer.IC
{
    public class StatueItem : AbstractItem
    {
        public string statueName { get; set; }
        public override void GiveImmediate(GiveInfo info)
        {          
            statueName = $"statueState{statueName}";
            BossStatue.Completion statueCompletion = PlayerData.instance.GetVariable<BossStatue.Completion>(statueName);
            if (!statueCompletion.isUnlocked && HallOfGodsRandomizer.Instance.GS.MainSettings.RandomizeStatueAccess == StatueAccessMode.Randomized)
            {
                statueCompletion.isUnlocked = true;
                PlayerData.instance.SetVariable(statueName, statueCompletion);
            }
            else if (!statueCompletion.completedTier1 && HallOfGodsRandomizer.Instance.GS.MainSettings.RandomizeTiers > TierLimitMode.Vanilla)
            {
                statueCompletion.completedTier1 = true;
                PlayerData.instance.SetVariable(statueName, statueCompletion);
            }
            else if (!statueCompletion.completedTier2 && HallOfGodsRandomizer.Instance.GS.MainSettings.RandomizeTiers > TierLimitMode.ExcludeAscended)
            {
                statueCompletion.completedTier2 = true;
                PlayerData.instance.SetVariable(statueName, statueCompletion);
            }
            else if (!statueCompletion.completedTier3 && HallOfGodsRandomizer.Instance.GS.MainSettings.RandomizeTiers > TierLimitMode.ExcludeRadiant)
            {
                statueCompletion.completedTier3 = true;
                PlayerData.instance.SetVariable(statueName, statueCompletion);
            }
            else
            {
                throw new NotImplementedException("The item had no effect due to logic inconsistencies.");
            }
        }
    }
}