using HallOfGodsRandomizer.IC;
using ItemChanger;
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
            // Define items
            Assembly assembly = Assembly.GetExecutingAssembly();
            JsonSerializer jsonSerializer = new() {TypeNameHandling = TypeNameHandling.Auto};
            using Stream itemStream = assembly.GetManifestResourceStream("HallOfGodsRandomizer.Resources.Data.Items.json");
            StreamReader itemReader = new(itemStream);
            List<StatueItem> itemList = jsonSerializer.Deserialize<List<StatueItem>>(new JsonTextReader(itemReader));
            foreach (StatueItem item in itemList)
                Finder.DefineCustomItem(item);

            foreach (StatueItem item in itemList)
                builder.AddItemByName(item.name, 3);
        }
    }
}