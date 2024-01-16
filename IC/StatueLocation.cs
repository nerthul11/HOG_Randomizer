using ItemChanger;
using ItemChanger.Locations;

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
    public class StatueLocation : AutoLocation
    {
        public override GiveInfo GetGiveInfo() => new()
        {
           FlingType = flingType,
           Callback = null,
           Container = Container.Unknown,
           MessageType = MessageType.Corner
        };

        protected override void OnUnload()
        {
        }

        protected override void OnLoad()
        {
        }
    }
}