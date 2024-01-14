using HallOfGodsRandomizer.Manager;

namespace HallOfGodsRandomizer.Menu
{
    internal static class HOG_Interop
    {
        public static HOG_RandomizationSettings Settings => HallOfGodsRandomizer.Instance.GS.MainSettings;

        public static void HookRandomizer()
        {
            ConnectionMenu.Hook();
            LogicHandler.Hook();
        }
    }
}