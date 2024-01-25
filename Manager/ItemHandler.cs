using HallOfGodsRandomizer.Menu;
using ItemChanger;
using ItemChanger.Locations;
using Newtonsoft.Json;
using RandomizerMod.RC;
using System.IO;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace HallOfGodsRandomizer.Manager {
    internal static class ItemHandler
    {
        internal static void Hook()
        {
            if (HOG_Interop.Settings.Enabled)
            {
                RequestBuilder.OnUpdate.Subscribe(100f, AddObjects);
            }            
        }

        public static void AddObjects(RequestBuilder builder)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            JsonSerializer jsonSerializer = new() {TypeNameHandling = TypeNameHandling.Auto};
            HallOfGodsRandomizationSettings settings = HallOfGodsRandomizer.Instance.GS.MainSettings;
            
            // Define items
            using Stream itemStream = assembly.GetManifestResourceStream("HallOfGodsRandomizer.Resources.Data.Items.json");
            StreamReader itemReader = new(itemStream);
            List<AbstractItem> itemList = jsonSerializer.Deserialize<List<AbstractItem>>(new JsonTextReader(itemReader));
            foreach (AbstractItem item in itemList)
                Finder.DefineCustomItem(item);
            
            int itemCount = (int)settings.RandomizeTiers + (int)settings.RandomizeStatueAccess;
            foreach (AbstractItem item in itemList)
                builder.AddItemByName(item.name, itemCount);

            // Define locations
            using Stream locationStream = assembly.GetManifestResourceStream("HallOfGodsRandomizer.Resources.Data.Locations.json");
            StreamReader locationReader = new(locationStream);
            List<AutoLocation> locationList = jsonSerializer.Deserialize<List<AutoLocation>>(new JsonTextReader(locationReader));
            
            // Filter Gold, Silver and Bronze marks if TierLimitMode excludes them.
            if (settings.RandomizeTiers == TierLimitMode.ExcludeRadiant)
            {
                locationList = (List<AutoLocation>)locationList.Where(location => !location.name.StartsWith("Gold"));
            }
            else if (settings.RandomizeTiers == TierLimitMode.ExcludeAscended)
            {
                locationList = (List<AutoLocation>)locationList.Where(location => !location.name.StartsWith("Gold") || !location.name.StartsWith("Silver"));
            }
            else if (settings.RandomizeTiers == TierLimitMode.Vanilla)
            {
                locationList = (List<AutoLocation>)locationList.Where(location => location.name.StartsWith("Empty"));
            }

            // Remove statue access locations if StatueAccessMode is Vanilla
            if (settings.RandomizeStatueAccess == StatueAccessMode.Vanilla)
            {
                locationList = (List<AutoLocation>)locationList.Where(location => !location.name.StartsWith("Empty"));
            }

            foreach (AutoLocation location in locationList)
                Finder.DefineCustomLocation(location);

            foreach (AutoLocation location in locationList)
                builder.AddLocationByName(location.name);
        }
    }
}