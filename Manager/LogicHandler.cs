using System.IO;
using HallOfGodsRandomizer.Menu;
using RandomizerCore.Logic;
using RandomizerMod.RC;
using RandomizerMod.Settings;

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
            AddItems(lmb);
        }

        private static void AddConstantJSONs(LogicManagerBuilder lmb)
        {
            /// Deserialization is not reading the files properly. Needs fixing.
            /// Add terms
            using Stream t = typeof(LogicHandler).Assembly.GetManifestResourceStream("HallOfGodsRandomizer.Resources.Logic.terms.json");
            lmb.DeserializeJson(LogicManagerBuilder.JsonType.Terms, t);

            /// Add macros
            using Stream m = typeof(LogicHandler).Assembly.GetManifestResourceStream("HallOfGodsRandomizer.Resources.Logic.macros.json");
            lmb.DeserializeJson(LogicManagerBuilder.JsonType.Macros, m);

            
        }

        private static void AddItems(LogicManagerBuilder lmb)
        {
            using Stream i = typeof(LogicHandler).Assembly.GetManifestResourceStream("HallOfGodsRandomizer.Resources.Logic.items.json");
            lmb.DeserializeJson(LogicManagerBuilder.JsonType.Items, i);
        }
    }
}