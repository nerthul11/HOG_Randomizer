using ItemChanger;
using ItemChanger.Locations;

namespace HallOfGodsRandomizer {
    /// <summary>
    /// Each location should add an item when completing a tier for the first time.
    /// The method for setting boolean values as true should be overriden in the original functions.
    /// </summary>
    public class UnlockLocation : AutoLocation
    {
        protected override void OnUnload()
        {
        }

        protected override void OnLoad()
        {
        }
    }
}