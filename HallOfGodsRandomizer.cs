using HallOfGodsRandomizer.Manager;
using HallOfGodsRandomizer.Menu;
using Modding;
using System;

namespace HallOfGodsRandomizer
{
    public class HallOfGodsRandomizer : Mod, ILocalSettings<LocalSettings>, IGlobalSettings<GlobalSettings>
    {
        new public string GetName() => "HallOfGodsRandomizer";
        public override string GetVersion() => "0.4.0.0";

        private static HallOfGodsRandomizer _instance;
        public HallOfGodsRandomizer() : base()
        {
            _instance = this;
        }
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
        public LocalSettings LS { get; internal set; } = new();
        public GlobalSettings GS { get; internal set; } = new();
        public override void Initialize()
        {
            // Ignore completely if Randomizer 4 is inactive
            if (ModHooks.GetMod("Randomizer 4") is Mod)
            {
                Log("Initializing");
                HOG_Interop.Hook();
                Log("Initialized");
            }
        }
        public void OnLoadGlobal(GlobalSettings s) => GS = s;
        public GlobalSettings OnSaveGlobal() => GS;
        public void OnLoadLocal(LocalSettings s) => LS = s;
        public LocalSettings OnSaveLocal() => LS;

        public void ManageState(string statueName, string tier, bool setAsTrue)
        {
            if (statueName == "statueStateGruzMother")
            {
                BossStatue.Completion statue = Instance.LS.statueStateGruzMother;
                Instance.LS.statueStateGruzMother = Override(statueName, statue, tier, setAsTrue);
            }
            if (statueName == "statueStateVengefly")
            {
                BossStatue.Completion statue = Instance.LS.statueStateVengefly;
                Instance.LS.statueStateVengefly = Override(statueName, statue, tier, setAsTrue);
            }
            if (statueName == "statueStateBroodingMawlek")
            {
                BossStatue.Completion statue = Instance.LS.statueStateBroodingMawlek;
                Instance.LS.statueStateBroodingMawlek = Override(statueName, statue, tier, setAsTrue);
            }
            if (statueName == "statueStateFalseKnight")
            {
                BossStatue.Completion statue = Instance.LS.statueStateFalseKnight;
                Instance.LS.statueStateFalseKnight = Override(statueName, statue, tier, setAsTrue);
            }
            if (statueName == "statueStateFailedChampion")
            {
                BossStatue.Completion statue = Instance.LS.statueStateFailedChampion;
                Instance.LS.statueStateFailedChampion = Override(statueName, statue, tier, setAsTrue);
            }
            if (statueName == "statueStateHornet1")
            {
                BossStatue.Completion statue = Instance.LS.statueStateHornet1;
                Instance.LS.statueStateHornet1 = Override(statueName, statue, tier, setAsTrue);
            }
            if (statueName == "statueStateHornet2")
            {
                BossStatue.Completion statue = Instance.LS.statueStateHornet2;
                Instance.LS.statueStateHornet2 = Override(statueName, statue, tier, setAsTrue);
            }
            if (statueName == "statueStateMegaMossCharger")
            {
                BossStatue.Completion statue = Instance.LS.statueStateMegaMossCharger;
                Instance.LS.statueStateMegaMossCharger = Override(statueName, statue, tier, setAsTrue);
            }
            if (statueName == "statueStateMantisLords")
            {
                BossStatue.Completion statue = Instance.LS.statueStateMantisLords;
                Instance.LS.statueStateMantisLords = Override(statueName, statue, tier, setAsTrue);
            }
            if (statueName == "statueStateOblobbles")
            {
                BossStatue.Completion statue = Instance.LS.statueStateOblobbles;
                Instance.LS.statueStateOblobbles = Override(statueName, statue, tier, setAsTrue);
            }
            if (statueName == "statueStateGreyPrince")
            {
                BossStatue.Completion statue = Instance.LS.statueStateGreyPrince;
                Instance.LS.statueStateGreyPrince = Override(statueName, statue, tier, setAsTrue);
            }
            if (statueName == "statueStateBrokenVessel")
            {
                BossStatue.Completion statue = Instance.LS.statueStateBrokenVessel;
                Instance.LS.statueStateBrokenVessel = Override(statueName, statue, tier, setAsTrue);
            }
            if (statueName == "statueStateLostKin")
            {
                BossStatue.Completion statue = Instance.LS.statueStateLostKin;
                Instance.LS.statueStateLostKin = Override(statueName, statue, tier, setAsTrue);
            }
            if (statueName == "statueStateNosk")
            {
                BossStatue.Completion statue = Instance.LS.statueStateNosk;
                Instance.LS.statueStateNosk = Override(statueName, statue, tier, setAsTrue);
            }
            if (statueName == "statueStateFlukemarm")
            {
                BossStatue.Completion statue = Instance.LS.statueStateFlukemarm;
                Instance.LS.statueStateFlukemarm = Override(statueName, statue, tier, setAsTrue);
            }
            if (statueName == "statueStateCollector")
            {
                BossStatue.Completion statue = Instance.LS.statueStateCollector;
                Instance.LS.statueStateCollector = Override(statueName, statue, tier, setAsTrue);
            }
            if (statueName == "statueStateWatcherKnights")
            {
                BossStatue.Completion statue = Instance.LS.statueStateWatcherKnights;
                Instance.LS.statueStateWatcherKnights = Override(statueName, statue, tier, setAsTrue);
            }
            if (statueName == "statueStateSoulMaster")
            {
                BossStatue.Completion statue = Instance.LS.statueStateSoulMaster;
                Instance.LS.statueStateSoulMaster = Override(statueName, statue, tier, setAsTrue);
            }
            if (statueName == "statueStateSoulTyrant")
            {
                BossStatue.Completion statue = Instance.LS.statueStateSoulTyrant;
                Instance.LS.statueStateSoulTyrant = Override(statueName, statue, tier, setAsTrue);
            }
            if (statueName == "statueStateGodTamer")
            {
                BossStatue.Completion statue = Instance.LS.statueStateGodTamer;
                Instance.LS.statueStateGodTamer = Override(statueName, statue, tier, setAsTrue);
            }
            if (statueName == "statueStateCrystalGuardian1")
            {
                BossStatue.Completion statue = Instance.LS.statueStateCrystalGuardian1;
                Instance.LS.statueStateCrystalGuardian1 = Override(statueName, statue, tier, setAsTrue);
            }
            if (statueName == "statueStateCrystalGuardian2")
            {
                BossStatue.Completion statue = Instance.LS.statueStateCrystalGuardian2;
                Instance.LS.statueStateCrystalGuardian2 = Override(statueName, statue, tier, setAsTrue);
            }
            if (statueName == "statueStateUumuu")
            {
                BossStatue.Completion statue = Instance.LS.statueStateUumuu;
                Instance.LS.statueStateUumuu = Override(statueName, statue, tier, setAsTrue);
            }
            if (statueName == "statueStateDungDefender")
            {
                BossStatue.Completion statue = Instance.LS.statueStateDungDefender;
                Instance.LS.statueStateDungDefender = Override(statueName, statue, tier, setAsTrue);
            }
            if (statueName == "statueStateWhiteDefender")
            {
                BossStatue.Completion statue = Instance.LS.statueStateWhiteDefender;
                Instance.LS.statueStateWhiteDefender = Override(statueName, statue, tier, setAsTrue);
            }
            if (statueName == "statueStateHiveKnight")
            {
                BossStatue.Completion statue = Instance.LS.statueStateHiveKnight;
                Instance.LS.statueStateHiveKnight = Override(statueName, statue, tier, setAsTrue);
            }
            if (statueName == "statueStateTraitorLord")
            {
                BossStatue.Completion statue = Instance.LS.statueStateTraitorLord;
                Instance.LS.statueStateTraitorLord = Override(statueName, statue, tier, setAsTrue);
            }
            if (statueName == "statueStateGrimm")
            {
                BossStatue.Completion statue = Instance.LS.statueStateGrimm;
                Instance.LS.statueStateGrimm = Override(statueName, statue, tier, setAsTrue);
            }
            if (statueName == "statueStateNightmareGrimm")
            {
                BossStatue.Completion statue = Instance.LS.statueStateNightmareGrimm;
                Instance.LS.statueStateNightmareGrimm = Override(statueName, statue, tier, setAsTrue);
            }
            if (statueName == "statueStateHollowKnight")
            {
                BossStatue.Completion statue = Instance.LS.statueStateHollowKnight;
                Instance.LS.statueStateHollowKnight = Override(statueName, statue, tier, setAsTrue);
            }
            if (statueName == "statueStateElderHu")
            {
                BossStatue.Completion statue = Instance.LS.statueStateElderHu;
                Instance.LS.statueStateElderHu = Override(statueName, statue, tier, setAsTrue);
            }
            if (statueName == "statueStateGalien")
            {
                BossStatue.Completion statue = Instance.LS.statueStateGalien;
                Instance.LS.statueStateGalien = Override(statueName, statue, tier, setAsTrue);
            }
            if (statueName == "statueStateMarkoth")
            {
                BossStatue.Completion statue = Instance.LS.statueStateMarkoth;
                Instance.LS.statueStateMarkoth = Override(statueName, statue, tier, setAsTrue);
            }
            if (statueName == "statueStateMarmu")
            {
                BossStatue.Completion statue = Instance.LS.statueStateMarmu;
                Instance.LS.statueStateMarmu = Override(statueName, statue, tier, setAsTrue);
            }
            if (statueName == "statueStateNoEyes")
            {
                BossStatue.Completion statue = Instance.LS.statueStateNoEyes;
                Instance.LS.statueStateNoEyes = Override(statueName, statue, tier, setAsTrue);
            }
            if (statueName == "statueStateXero")
            {
                BossStatue.Completion statue = Instance.LS.statueStateXero;
                Instance.LS.statueStateXero = Override(statueName, statue, tier, setAsTrue);
            }
            if (statueName == "statueStateGorb")
            {
                BossStatue.Completion statue = Instance.LS.statueStateGorb;
                Instance.LS.statueStateGorb = Override(statueName, statue, tier, setAsTrue);
            }
            if (statueName == "statueStateRadiance")
            {
                BossStatue.Completion statue = Instance.LS.statueStateRadiance;
                Instance.LS.statueStateRadiance = Override(statueName, statue, tier, setAsTrue);
            }
            if (statueName == "statueStateSly")
            {
                BossStatue.Completion statue = Instance.LS.statueStateSly;
                Instance.LS.statueStateSly = Override(statueName, statue, tier, setAsTrue);
            }
            if (statueName == "statueStateNailmasters")
            {
                BossStatue.Completion statue = Instance.LS.statueStateNailmasters;
                Instance.LS.statueStateNailmasters = Override(statueName, statue, tier, setAsTrue);
            }
            if (statueName == "statueStateMageKnight")
            {
                BossStatue.Completion statue = Instance.LS.statueStateMageKnight;
                Instance.LS.statueStateMageKnight = Override(statueName, statue, tier, setAsTrue);
            }
            if (statueName == "statueStatePaintmaster")
            {
                BossStatue.Completion statue = Instance.LS.statueStatePaintmaster;
                Instance.LS.statueStatePaintmaster = Override(statueName, statue, tier, setAsTrue);
            }
            if (statueName == "statueStateNoskHornet")
            {
                BossStatue.Completion statue = Instance.LS.statueStateNoskHornet;
                Instance.LS.statueStateNoskHornet = Override(statueName, statue, tier, setAsTrue);
            }
            if (statueName == "statueStateMantisLordsExtra")
            {
                BossStatue.Completion statue = Instance.LS.statueStateMantisLordsExtra;
                Instance.LS.statueStateMantisLordsExtra = Override(statueName, statue, tier, setAsTrue);
            }
        }

        public BossStatue.Completion Override(string statueName, BossStatue.Completion statue, string tier, bool setAsTrue)
        {
            BossStatue.Completion orig = PlayerData.instance.GetVariable<BossStatue.Completion>(statueName);
            // Set LocalSettings statue values if item is obtained
            if (tier == "isUnlocked" && setAsTrue)
                statue.isUnlocked = true;
            if (tier == "completedTier1" && setAsTrue)
                statue.completedTier1 = true;
            if (tier == "completedTier2" && setAsTrue)
                statue.completedTier2 = true;
            if (tier == "completedTier3" && setAsTrue)
                statue.completedTier3 = true;
            
            // Override: If settings enabled, orig is replaced. If not enabled, orig settings are copied.
            HallOfGodsRandomizationSettings settings = HOG_Interop.Settings;
            if (settings.RandomizeStatueAccess == StatueAccessMode.Randomized)
                orig.isUnlocked = statue.isUnlocked;
            else
                statue.isUnlocked = orig.isUnlocked;
            
            if (settings.RandomizeTiers > TierLimitMode.Vanilla)
                orig.completedTier1 = statue.completedTier1;
            else
                statue.completedTier1 = orig.completedTier1;

            if (settings.RandomizeTiers > TierLimitMode.ExcludeAscended)
                orig.completedTier2 = statue.completedTier2;
            else
                statue.completedTier2 = orig.completedTier2;

            if (settings.RandomizeTiers > TierLimitMode.ExcludeRadiant)
                orig.completedTier3 = statue.completedTier3;
            else
                statue.completedTier3 = orig.completedTier3;

            // Other properties are unhandled by the mod and always take orig values       
            statue.hasBeenSeen = orig.hasBeenSeen;
            statue.seenTier3Unlock = orig.seenTier3Unlock;
            statue.usingAltVersion = orig.usingAltVersion;

            // Save changes
            PlayerData.instance.SetVariable<BossStatue.Completion>(statueName, orig);
            return statue;
        }
    }   
}