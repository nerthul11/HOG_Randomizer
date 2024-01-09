using ItemChanger;

/// This should list the statue item properties and handle switch
/// behaviour once obtained.
namespace HallOfGodsRandomizer.Manager {
    public class StatueItem : AbstractItem
    /// <summary>
    /// Each item should contain:
    /// Attributes:
    /// -Standard item attributes.
    /// 
    /// Methods:
    /// -Unlock a statue location when obtained.
    /// -Unlock the next tier for the item
    /// </summary>
    {
        public override void GiveImmediate(GiveInfo info)
        {
            /// Set bool to true
            PlayerData.instance.statueStateGruzMother.completedTier1 = true;
        }
    }
}