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

        public override GiveInfo GetGiveInfo() => new()
        {
           FlingType = flingType,
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