using ItemChanger;
using ItemChanger.Locations;
using Newtonsoft.Json;
using RandomizerMod.RC;
using System.IO;
using System.Collections.Generic;
using System.Reflection;

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
            
            // Define items
            using Stream itemStream = assembly.GetManifestResourceStream("HallOfGodsRandomizer.Resources.Data.Items.json");
            StreamReader itemReader = new(itemStream);
            List<AbstractItem> itemList = jsonSerializer.Deserialize<List<AbstractItem>>(new JsonTextReader(itemReader));
            foreach (AbstractItem item in itemList)
                Finder.DefineCustomItem(item);

            foreach (AbstractItem item in itemList)
                builder.AddItemByName(item.name, 4);

            // Define locations
            using Stream locationStream = assembly.GetManifestResourceStream("HallOfGodsRandomizer.Resources.Data.Locations.json");
            StreamReader locationReader = new(locationStream);
            List<AutoLocation> locationList = jsonSerializer.Deserialize<List<AutoLocation>>(new JsonTextReader(locationReader));
            foreach (AutoLocation location in locationList)
                Finder.DefineCustomLocation(location);

            foreach (AutoLocation location in locationList)
                builder.AddLocationByName(location.name, 3);
        }
    }
}