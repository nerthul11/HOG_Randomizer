using HallOfGodsRandomizer.IC;
using HallOfGodsRandomizer.Menu;
using Modding;
using Newtonsoft.Json;
using RandomizerCore.Json;
using RandomizerCore.Logic;
using RandomizerCore.StringItems;
using RandomizerMod.Settings;
using RandomizerMod.RC;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Linq;

namespace HallOfGodsRandomizer.Manager
{
    public class LogicHandler
    {
        public static void Hook()
        {
            if (HOG_Interop.Settings.Enabled)
            {
                // Priority set to have it run after TRJR - may change depending on other connection interactions
                RCData.RuntimeLogicOverride.Subscribe(11f, ApplyLogic);
            }
        }

        private static void ApplyLogic(GenerationSettings gs, LogicManagerBuilder lmb)
        {
            JsonLogicFormat fmt = new();
            AddLogic(lmb, fmt);
            EditConnections(lmb);
        }

        private static void AddLogic(LogicManagerBuilder lmb, JsonLogicFormat fmt)
        {
            // Add macros and waypoints.
            lmb.DeserializeFile(LogicFileType.Macros, fmt, typeof(HallOfGodsRandomizer).Assembly.GetManifestResourceStream($"HallOfGodsRandomizer.Resources.Logic.macros.json"));
            lmb.DeserializeFile(LogicFileType.Waypoints, fmt, typeof(HallOfGodsRandomizer).Assembly.GetManifestResourceStream($"HallOfGodsRandomizer.Resources.Logic.waypoints.json"));

            // Read item definitions
            Assembly assembly = Assembly.GetExecutingAssembly();
            JsonSerializer jsonSerializer = new() {TypeNameHandling = TypeNameHandling.Auto};
            using Stream itemStream = assembly.GetManifestResourceStream("HallOfGodsRandomizer.Resources.Data.Items.json");
            StreamReader itemReader = new(itemStream);
            List<StatueItem> itemList = jsonSerializer.Deserialize<List<StatueItem>>(new JsonTextReader(itemReader));

            HallOfGodsRandomizationSettings settings = HOG_Interop.Settings;
            int req = (int)settings.RandomizeStatueAccess;
            foreach (StatueItem item in itemList)
            {
                string boss = item.name.Split('-').Last();

                // Add terms
                lmb.GetOrAddTerm($"GG_{boss}", TermType.Int);

                // Add logic items
                lmb.AddItem(new StringItemTemplate($"Statue_Mark-{boss}", $"GG_{boss}++"));

                // Add location logic
                if (settings.RandomizeStatueAccess == StatueAccessMode.Randomized)
                {
                    lmb.AddLogicDef(new($"Empty_Mark-{boss}", $"STATUE + GG_{boss}>0"));
                }
                if (settings.RandomizeTiers > TierLimitMode.Vanilla)
                {
                    lmb.AddLogicDef(new($"Bronze_Mark-{boss}", $"STATUE + ATTUNED + GG_{boss}>0 + COMBAT[{boss}]"));
                    if (settings.RandomizeStatueAccess == StatueAccessMode.Vanilla)
                        lmb.DoLogicEdit(new($"Bronze_Mark-{boss}", $"STATUE + ATTUNED + GG_{boss}>0 + Defeated_{boss}"));
                }
                if (settings.RandomizeTiers > TierLimitMode.ExcludeAscended)
                {
                    lmb.AddLogicDef(new($"Silver_Mark-{boss}", $"STATUE + ASCENDED + GG_{boss}>0 + COMBAT[{boss}]"));
                    if (settings.RandomizeStatueAccess == StatueAccessMode.Vanilla)
                        lmb.DoLogicEdit(new($"Silver_Mark-{boss}", $"STATUE + ASCENDED + GG_{boss}>0 + Defeated_{boss}"));
                }
                if (settings.RandomizeTiers > TierLimitMode.ExcludeRadiant)
                {
                    lmb.AddLogicDef(new($"Gold_Mark-{boss}", $"STATUE + RADIANT + GG_{boss}>{req + 1} + COMBAT[{boss}]"));
                    if (settings.RandomizeStatueAccess == StatueAccessMode.Vanilla)
                        lmb.DoLogicEdit(new($"Gold_Mark-{boss}", $"STATUE + RADIANT + GG_{boss}>{req + 1} + Defeated_{boss}"));
                }
            }
        }

        private static void EditConnections(LogicManagerBuilder lmb)
        {
            // Read item definitions
            Assembly assembly = Assembly.GetExecutingAssembly();
            JsonSerializer jsonSerializer = new() {TypeNameHandling = TypeNameHandling.Auto};
            using Stream itemStream = assembly.GetManifestResourceStream("HallOfGodsRandomizer.Resources.Data.Items.json");
            StreamReader itemReader = new(itemStream);
            List<StatueItem> itemList = jsonSerializer.Deserialize<List<StatueItem>>(new JsonTextReader(itemReader));

            HallOfGodsRandomizationSettings settings = HOG_Interop.Settings;
            int req = (int)settings.RandomizeStatueAccess;

            // Connection with TRJR's Void Idol entries.
            if (ModHooks.GetMod("TheRealJournalRando") is Mod)
            {
                // Add HOG mark requirements to logic.
                if (settings.RandomizeTiers > TierLimitMode.Vanilla)
                {
                    string logic = "GG_Workshop";
                    foreach (StatueItem item in itemList)
                    {
                        string boss = item.name.Split('-').Last();
                        logic += $" + GG_{boss}>{req}";
                    }
                    lmb.DoMacroEdit(new("ATTUNED_IDOL", logic));
                    lmb.DoLogicEdit(new("Journal_Entry-Void_Idol_1", "ATTUNED_IDOL"));
                }

                if (settings.RandomizeTiers > TierLimitMode.ExcludeAscended)
                {
                    string logic = "GG_Workshop";
                    foreach (StatueItem item in itemList)
                    {
                        string boss = item.name.Split('-').Last();
                        logic += $" + GG_{boss}>{req + 1}";
                    }
                    lmb.DoMacroEdit(new("ASCENDED_IDOL", logic));
                    lmb.DoLogicEdit(new("Journal_Entry-Void_Idol_2", "ASCENDED_IDOL"));                
                }
                if (settings.RandomizeTiers == TierLimitMode.IncludeAll)
                {
                    string logic = "GG_Workshop";
                    foreach (StatueItem item in itemList)
                    {
                        string boss = item.name.Split('-').Last();
                        logic += $" + GG_{boss}>{req + 2}";
                    }
                    lmb.DoMacroEdit(new("RADIANT_IDOL", logic));
                    lmb.DoLogicEdit(new("Journal_Entry-Void_Idol_3", "RADIANT_IDOL"));
                }
            }
        }
    }
}