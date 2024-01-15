using HallOfGodsRandomizer.IC;
using HallOfGodsRandomizer.Menu;
using Newtonsoft.Json;
using System.IO;

namespace HallOfGodsRandomizer.Manager
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