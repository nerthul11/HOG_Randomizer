using ItemChanger;

namespace HallOfGodsRandomizer.IC
{
    public class StatueItem : AbstractItem
    {
        public string hogId { get; set; }
        public string statueName { get; set; }
        public override void GiveImmediate(GiveInfo info)
        {
            BossStatueCompletionStates statueState = PlayerData.instance.GetVariable<BossStatueCompletionStates>($"statueState{statueName}");
            HallOfGodsRandomizer.Instance.LogDebug(statueState);
        }
    }
}