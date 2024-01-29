using RandomizerCore.Logic;
﻿using RandomizerCore.Json;
using RandomizerMod.Settings;
using RandomizerMod.RC;

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
        private static readonly (LogicFileType type, string fileName)[] files = new[]
        {
            (LogicFileType.Terms, "terms"),
            (LogicFileType.Macros, "macros"),
            (LogicFileType.Locations, "locations"),
            (LogicFileType.ItemStrings, "items")
        };

        private static void ApplyLogic(GenerationSettings gs, LogicManagerBuilder lmb)
        {
            ILogicFormat fmt = new JsonLogicFormat();

            foreach ((LogicFileType type, string fileName) in files)
            {
                lmb.DeserializeFile(type, fmt, typeof(HallOfGodsRandomizer).Assembly.GetManifestResourceStream($"HallOfGodsRandomizer.Resources.Logic.{fileName}.json"));
            }

            
        }
    }
}