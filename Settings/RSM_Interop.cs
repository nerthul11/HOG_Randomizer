using HallOfGodsRandomizer.Manager;
using RandoSettingsManager;
using RandoSettingsManager.SettingsManagement;
using RandoSettingsManager.SettingsManagement.Versioning;

namespace HallOfGodsRandomizer.Settings
{
    internal static class RSM_Interop
    {
        public static void Hook()
        {
            RandoSettingsManagerMod.Instance.RegisterConnection(new HOG_SettingsProxy());
        }
    }

    internal class HOG_SettingsProxy : RandoSettingsProxy<HallOfGodsRandomizationSettings, string>
    {
        public override string ModKey => HallOfGodsRandomizer.Instance.GetName();

        public override VersioningPolicy<string> VersioningPolicy { get; }
            = new EqualityVersioningPolicy<string>(HallOfGodsRandomizer.Instance.GetVersion());

        public override void ReceiveSettings(HallOfGodsRandomizationSettings settings)
        {
            if (settings != null)
            {
                ConnectionMenu.Instance!.Apply(settings);
            }
            else
            {
                ConnectionMenu.Instance!.Disable();
            }
        }

        public override bool TryProvideSettings(out HallOfGodsRandomizationSettings settings)
        {
            settings = HOG_Interop.GlobalSettings;
            return settings.Enabled;
        }
    }
}