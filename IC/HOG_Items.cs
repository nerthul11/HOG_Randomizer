using System.IO;
using System.Reflection;
using ItemChanger;
using ItemChanger.Items;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace HallOfGodsRandomizer.IC
{
    public static class HOG_Items
    {
        internal static void Initialize()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            JsonSerializer jsonSerializer = new() {TypeNameHandling = TypeNameHandling.Auto};
            HallOfGodsRandomizer.Instance.Log("Serializer defined.");
            using Stream itemStream = assembly.GetManifestResourceStream("HallOfGodsRandomizer.IC.Items.json");
            StreamReader itemReader = new(itemStream);
            foreach (AbstractItem item in jsonSerializer.Deserialize<List<AbstractItem>>(new JsonTextReader(itemReader)))
            Finder.DefineCustomItem(item);
            HallOfGodsRandomizer.Instance.Log("Item defined.");
        }
    }
}