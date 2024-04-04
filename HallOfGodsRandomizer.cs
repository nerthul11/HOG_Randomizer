using HallOfGodsRandomizer.Manager;
using HallOfGodsRandomizer.Settings;
using Modding;
using System;

namespace HallOfGodsRandomizer
{
    public class HallOfGodsRandomizer : Mod, ILocalSettings<LocalSettings>, IGlobalSettings<GlobalSettings>
    {
        new public string GetName() => "HallOfGodsRandomizer";
        public override string GetVersion() => "1.1.2.1";

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

                if (ModHooks.GetMod("RandoSettingsManager") is Mod)
                {
                    RSM_Interop.Hook();
                }
            }
        }
        public void OnLoadGlobal(GlobalSettings s) => GS = s;
        public GlobalSettings OnSaveGlobal() => GS;
        public void OnLoadLocal(LocalSettings s) => LS = s;
        public LocalSettings OnSaveLocal() => LS;

        public void ManageState(string statueName, string tier, bool setAsTrue)
        {
            BossStatue.Completion statue = Instance.LS.GetVariable<BossStatue.Completion>(statueName);
            Instance.LS.SetVariable(statueName, Override(statueName, statue, tier, setAsTrue));
        }

        public BossStatue.Completion Override(string statueStateName, BossStatue.Completion statue, string tier, bool setAsTrue)
        {
            BossStatue.Completion orig = PlayerData.instance.GetVariable<BossStatue.Completion>(statueStateName);
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
            PlayerData.instance.SetVariable<BossStatue.Completion>(statueStateName, orig);
            return statue;
        }
    }   
}