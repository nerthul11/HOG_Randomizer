using HallOfGodsRandomizer.Settings;
using ItemChanger;
using Newtonsoft.Json;
using RandomizerMod.RC;
using System.IO;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using HallOfGodsRandomizer.IC;

namespace HallOfGodsRandomizer.Manager {
    internal static class ItemHandler
    {
        internal static void Hook()
        {
            DefineObjects();
            if (HOG_Interop.GlobalSettings.Enabled)
            {   
                RequestBuilder.OnUpdate.Subscribe(100f, AddObjects);
            }            
        }

        public static void DefineObjects()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            JsonSerializer jsonSerializer = new() {TypeNameHandling = TypeNameHandling.Auto};
            
            using Stream itemStream = assembly.GetManifestResourceStream("HallOfGodsRandomizer.Resources.Data.Items.json");
            StreamReader itemReader = new(itemStream);
            List<StatueItem> itemList = jsonSerializer.Deserialize<List<StatueItem>>(new JsonTextReader(itemReader));
        
            foreach (StatueItem item in itemList)
                Finder.DefineCustomItem(item);

            using Stream locationStream = assembly.GetManifestResourceStream("HallOfGodsRandomizer.Resources.Data.Locations.json");
            StreamReader locationReader = new(locationStream);
            List<StatueLocation> locationList = jsonSerializer.Deserialize<List<StatueLocation>>(new JsonTextReader(locationReader));
            foreach (StatueLocation location in locationList)
                    Finder.DefineCustomLocation(location);
        }

        public static void AddObjects(RequestBuilder builder)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            JsonSerializer jsonSerializer = new() {TypeNameHandling = TypeNameHandling.Auto};
            HallOfGodsRandomizationSettings settings = HOG_Interop.GlobalSettings;
            int itemCount = (int)settings.RandomizeTiers;
            if (settings.RandomizeStatueAccess == StatueAccessMode.Randomized)
                itemCount += 1;

            if (itemCount > 0)
            {
                // Define items
                using Stream itemStream = assembly.GetManifestResourceStream("HallOfGodsRandomizer.Resources.Data.Items.json");
                StreamReader itemReader = new(itemStream);
                List<StatueItem> itemList = jsonSerializer.Deserialize<List<StatueItem>>(new JsonTextReader(itemReader));
            
                foreach (StatueItem item in itemList)
                    builder.AddItemByName(item.name, itemCount);

                // Define locations
                using Stream locationStream = assembly.GetManifestResourceStream("HallOfGodsRandomizer.Resources.Data.Locations.json");
                StreamReader locationReader = new(locationStream);
                List<StatueLocation> locationList = jsonSerializer.Deserialize<List<StatueLocation>>(new JsonTextReader(locationReader));
                
                // Filter Gold, Silver and Bronze marks if TierLimitMode excludes them.
                if (settings.RandomizeTiers == TierLimitMode.ExcludeRadiant)
                {
                    locationList = locationList.Where(location => !location.name.StartsWith("Gold")).ToList();
                }
                else if (settings.RandomizeTiers == TierLimitMode.ExcludeAscended)
                {
                    locationList = locationList.Where(location => !location.name.StartsWith("Gold") && !location.name.StartsWith("Silver")).ToList();
                }
                else if (settings.RandomizeTiers == TierLimitMode.Vanilla)
                {
                    locationList = locationList.Where(location => location.name.StartsWith("Empty")).ToList();
                }

                // Remove statue access locations if StatueAccessMode isn't randomized
                if (settings.RandomizeStatueAccess != StatueAccessMode.Randomized)
                {
                    locationList = locationList.Where(location => !location.name.StartsWith("Empty")).ToList();
                }

                foreach (StatueLocation location in locationList)
                    builder.AddLocationByName(location.name);
            }
        }
    }
}