using HallOfGodsRandomizer.Menu;
using Newtonsoft.Json;
using RandomizerMod.Logging;

namespace HallOfGodsRandomizer.Manager
{
    internal static class HOG_Interop
    {
        public static HallOfGodsRandomizationSettings Settings => HallOfGodsRandomizer.Instance.GS.MainSettings;

        public static void Hook()
        {
            ItemHandler.Hook();
            ConnectionMenu.Hook();
            LogicHandler.Hook();
            SettingsLog.AfterLogSettings += AddHOGSettings;
        }

        private static void AddHOGSettings(LogArguments args, System.IO.TextWriter tw)
        {
            tw.WriteLine("Hall of Gods Randomizer Settings:");
            using JsonTextWriter jtw = new(tw) { CloseOutput = false };
            RandomizerMod.RandomizerData.JsonUtil._js.Serialize(jtw, Settings);
            tw.WriteLine();
        }        
    }
}