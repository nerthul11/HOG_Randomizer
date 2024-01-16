using HallOfGodsRandomizer.Menu;

namespace HallOfGodsRandomizer.Manager
{
    internal static class HOG_Interop
    {
        public static HOG_RandomizationSettings Settings => HallOfGodsRandomizer.Instance.GS.MainSettings;

        public static void Hook()
        {
            ItemHandler.Hook();
            ConnectionMenu.Hook();
            LogicHandler.Hook();
        }
    }
}