﻿using HallOfGodsRandomizer.Manager;
using Modding;
using System;

namespace HallOfGodsRandomizer
{
    public class HallOfGodsRandomizer : Mod, IGlobalSettings<GlobalSettings>
    {
        new public string GetName() => "HallOfGodsRandomizer";
        public override string GetVersion() => "0.1.0";

        private static HallOfGodsRandomizer _instance;
        internal static HallOfGodsRandomizer Instance
        {
            get
            {
                if (_instance == null)
                {
                    throw new InvalidOperationException($"{nameof(HallOfGodsRandomizer)} was never initialized");
                }
                return _instance;
            }
        }
        public HallOfGodsRandomizer() : base()
        {
            _instance = this;
        }
        public GlobalSettings GS { get; set; } = new();
        public override void Initialize()
        {
            if (ModHooks.GetMod("Randomizer 4") is Mod)
            {
                Log("Initializing");
                /// Randomize menu and logic
                HOG_Interop.HookRandomizer();
                Log("Initialized");
            }
        }

        /// <summary>
        ///  This should create instance variables and set it to value based on StatueAccessMode (0 or -1).
        /// </summary>

        public void OnLoadGlobal(GlobalSettings s) => GS = s;

        public GlobalSettings OnSaveGlobal() => GS;
    }   
}