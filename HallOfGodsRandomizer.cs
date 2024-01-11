﻿using HallOfGodsRandomizer.Menu;
using ItemChanger;
using ItemChanger.Items;
using ItemChanger.Locations;
using ItemChanger.Tags;
using ItemChanger.UIDefs;
using Modding;
using Steamworks;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;

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
                HOG_Interop.HookRandomizer();
                InitializeStatues();
                Log("Initialized");
            }
        }

        /// <summary>
        ///  This should create instance variables and set it to value based on StatueAccessMode (0 or -1).
        ///  This is also meant to replace all statue logic.
        /// </summary>
        public void InitializeStatues() 
        {
        }

        public void OnLoadGlobal(GlobalSettings s) => GS = s;

        public GlobalSettings OnSaveGlobal() => GS;
    }   
}