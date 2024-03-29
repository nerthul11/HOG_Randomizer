using System;

namespace HallOfGodsRandomizer.Settings
{
    public class GlobalSettings
    {
        public HallOfGodsRandomizationSettings MainSettings { get; set; } = new();
    }
    public class LocalSettings
    {
        public HallOfGodsRandomizationSettings Settings { get; set; } = new();
        public BossStatue.Completion statueStateGruzMother { get; set; }
        public BossStatue.Completion statueStateVengefly { get; set; }
        public BossStatue.Completion statueStateBroodingMawlek { get; set; }
        public BossStatue.Completion statueStateFalseKnight { get; set; }
        public BossStatue.Completion statueStateFailedChampion { get; set; }
        public BossStatue.Completion statueStateHornet1 { get; set; }
        public BossStatue.Completion statueStateHornet2 { get; set; }
        public BossStatue.Completion statueStateMegaMossCharger { get; set; }
        public BossStatue.Completion statueStateMantisLords { get; set; }
        public BossStatue.Completion statueStateOblobbles { get; set; }
        public BossStatue.Completion statueStateGreyPrince { get; set; }
        public BossStatue.Completion statueStateBrokenVessel { get; set; }
        public BossStatue.Completion statueStateLostKin { get; set; }
        public BossStatue.Completion statueStateNosk { get; set; }
        public BossStatue.Completion statueStateFlukemarm { get; set; }
        public BossStatue.Completion statueStateCollector { get; set; }
        public BossStatue.Completion statueStateWatcherKnights { get; set; }
        public BossStatue.Completion statueStateSoulMaster { get; set; }
        public BossStatue.Completion statueStateSoulTyrant { get; set; }
        public BossStatue.Completion statueStateGodTamer { get; set; }
        public BossStatue.Completion statueStateCrystalGuardian1 { get; set; }
        public BossStatue.Completion statueStateCrystalGuardian2 { get; set; }
        public BossStatue.Completion statueStateUumuu { get; set; }
        public BossStatue.Completion statueStateDungDefender { get; set; }
        public BossStatue.Completion statueStateWhiteDefender { get; set; }
        public BossStatue.Completion statueStateHiveKnight { get; set; }
        public BossStatue.Completion statueStateTraitorLord { get; set; }
        public BossStatue.Completion statueStateGrimm { get; set; }
        public BossStatue.Completion statueStateNightmareGrimm { get; set; }
        public BossStatue.Completion statueStateHollowKnight { get; set; }
        public BossStatue.Completion statueStateElderHu { get; set; }
        public BossStatue.Completion statueStateGalien { get; set; }
        public BossStatue.Completion statueStateMarkoth { get; set; }
        public BossStatue.Completion statueStateMarmu { get; set; }
        public BossStatue.Completion statueStateNoEyes { get; set; }
        public BossStatue.Completion statueStateXero { get; set; }
        public BossStatue.Completion statueStateGorb { get; set; }
        public BossStatue.Completion statueStateRadiance { get; set; }
        public BossStatue.Completion statueStateSly { get; set; }
        public BossStatue.Completion statueStateNailmasters { get; set; }
        public BossStatue.Completion statueStateMageKnight { get; set; }
        public BossStatue.Completion statueStatePaintmaster { get; set; }
        public BossStatue.Completion statueStateNoskHornet { get; set; }
        public BossStatue.Completion statueStateMantisLordsExtra { get; set; }

        public T GetVariable<T>(string propertyName) {
            var property = typeof(LocalSettings).GetProperty(propertyName);
            if (property == null) {
                throw new ArgumentException($"Property '{propertyName}' not found in LocalSettings class.");
            }
            return (T)property.GetValue(this);
        }

        public void SetVariable<T>(string propertyName, T value) {
            var property = typeof(LocalSettings).GetProperty(propertyName);
            if (property == null) {
                throw new ArgumentException($"Property '{propertyName}' not found in LocalSettings class.");
            }
            property.SetValue(this, value);
        }
    }
}