﻿using HallOfGodsRandomizer.Manager;
using HallOfGodsRandomizer.Menu;
using ItemChanger;
using ItemChanger.Extensions;
using ItemChanger.Items;
using ItemChanger.Locations;
using ItemChanger.Tags;
using ItemChanger.UIDefs;
using Modding;
using RandomizerMod.RandomizerData;
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
                InitializeVariables();
                Log("Initialized");
            }
        }

        /// <summary>
        ///  This should create instance variables and set it to value based on StatueAccessMode (0 or -1).
        /// </summary>
        public void InitializeVariables() 
        {
        }

        public void OnLoadGlobal(GlobalSettings s) => GS = s;

        public GlobalSettings OnSaveGlobal() => GS;

        public void OnLoadLocal(LocalSaveData saveData) 
        {
            saveData = OnSaveLocal();
            return;
        }

        public LocalSaveData OnSaveLocal()
        {
            List<string> BossList = [
            "GruzMother","Vengefly","BroodingMawlek","FalseKnight","FailedChampion",
            "Hornet1","Hornet2","MegaMossCharger","MantisLords","Oblobbles","GreyPrince","BrokenVessel",
            "LostKin","Nosk","Flukemarm","Collector","WatcherKnights","SoulMaster","SoulTyrant","GodTamer",
            "CrystalGuardian1","CrystalGuardian2","Uumuu","DungDefender","WhiteDefender","HiveKnight",
            "TraitorLord","Grimm","NightmareGrimm","HollowKnight","ElderHu","Galien","Markoth","Marmu",
            "NoEyes","Xero","Gorb","Radiance","Sly","Nailmasters","MageKnight","Paintmaster",
            "NoskHornet","MantisLordsExtra"];
            LocalSaveData saveData = new()
            {
                Data = BossList
            };
        return saveData;
        }
    }   
}