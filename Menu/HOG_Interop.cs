using ItemChanger;
using Modding;
using Newtonsoft.Json;
using RandomizerMod.Logging;
using RandomizerMod.RC;

namespace HallOfGodsRandomizer.Menu
{
    internal static class HOG_Interop
    {
        public static HOG_RandomizationSettings Settings => HallOfGodsRandomizer.Instance.GS.MainSettings;

        public static void HookRandomizer()
        {
            ConnectionMenu.Hook();
        }

        private static void OnExportCompleted(RandoController rc)
        {
        }
    }
}