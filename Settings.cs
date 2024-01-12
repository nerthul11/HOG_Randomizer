using System.Collections.Generic;

namespace HallOfGodsRandomizer
{
    public class GlobalSettings
    {
        public Menu.HOG_RandomizationSettings MainSettings { get; set; } = new();
    }

    public class LocalSaveData
    {
        public List<string> Data = [];
    }
}