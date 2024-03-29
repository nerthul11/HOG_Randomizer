using HallOfGodsRandomizer.Settings;
using Newtonsoft.Json;
using RandomizerMod.Logging;

namespace HallOfGodsRandomizer.Manager
{
    internal static class HOG_Interop
    {
        public static HallOfGodsRandomizationSettings GlobalSettings => HallOfGodsRandomizer.Instance.GS.MainSettings;
        public static HallOfGodsRandomizationSettings Settings => HallOfGodsRandomizer.Instance.LS.Settings;
        public static void Hook()
        {
            ItemHandler.Hook();
            LogicHandler.Hook();
            ConnectionMenu.Hook();
            SettingsLog.AfterLogSettings += AddFileSettings;
        }

        private static void AddFileSettings(LogArguments args, System.IO.TextWriter tw)
        {
            // Log settings into the settings file
            tw.WriteLine("Hall of Gods Randomizer Settings:");
            using JsonTextWriter jtw = new(tw) { CloseOutput = false };
            RandomizerMod.RandomizerData.JsonUtil._js.Serialize(jtw, GlobalSettings);
            tw.WriteLine();

            // Copy GlobalSettings into local to save settings snapshot for game logic use
            Settings.Enabled = GlobalSettings.Enabled;
            Settings.RandomizeTiers = GlobalSettings.RandomizeTiers;
            Settings.RandomizeStatueAccess = GlobalSettings.RandomizeStatueAccess;
        }        
    }
}