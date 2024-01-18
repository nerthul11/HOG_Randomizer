using System.IO;
using RandomizerCore;
using RandomizerCore.Logic;
using RandomizerCore.LogicItems;
using RandomizerMod.RC;
using RandomizerMod.Settings;
using ItemChanger;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Reflection;
using HallOfGodsRandomizer.IC;

namespace HallOfGodsRandomizer.Manager
{
    public class LogicHandler
    {
        public static void Hook()
        {
            if (HOG_Interop.Settings.Enabled)
            {
                RCData.RuntimeLogicOverride.Subscribe(10f, ApplyLogic);
            }
        }

        private static void ApplyLogic(GenerationSettings gs, LogicManagerBuilder lmb)
        {
            AddConstantJSONs(lmb);
        }

        private static void AddConstantJSONs(LogicManagerBuilder lmb)
        {
            // Add terms
            using Stream t = typeof(LogicHandler).Assembly.GetManifestResourceStream("HallOfGodsRandomizer.Resources.Logic.terms.json");
            lmb.DeserializeJson(LogicManagerBuilder.JsonType.Terms, t);
            
            // Add macros
            using Stream m = typeof(LogicHandler).Assembly.GetManifestResourceStream("HallOfGodsRandomizer.Resources.Logic.macros.json");
            lmb.DeserializeJson(LogicManagerBuilder.JsonType.Macros, m);

            // Add waypoints
            using Stream w = typeof(LogicHandler).Assembly.GetManifestResourceStream("HallOfGodsRandomizer.Resources.Logic.waypoints.json");
            lmb.DeserializeJson(LogicManagerBuilder.JsonType.Waypoints, w);

            // Add items          
            using Stream i = typeof(LogicHandler).Assembly.GetManifestResourceStream("HallOfGodsRandomizer.Resources.Logic.items.json");
            lmb.DeserializeJson(LogicManagerBuilder.JsonType.Items, i);

            // Add locations
            using Stream l = typeof(LogicHandler).Assembly.GetManifestResourceStream("HallOfGodsRandomizer.Resources.Logic.locations.json");
            lmb.DeserializeJson(LogicManagerBuilder.JsonType.Locations, l);
        }
    }
}