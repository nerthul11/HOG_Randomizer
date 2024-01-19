using ItemChanger;
using KorzUtils.Helper;
using System;
using UnityEngine;

namespace HallOfGodsRandomizer.IC
{
    [Serializable]
    public class StatueSprite : ISprite
    {
        #region Constructors

        public StatueSprite() { }

        public StatueSprite(string key)
        {
            if (!string.IsNullOrEmpty(key))
                Key = key;
        }

        #endregion

        #region Properties

        public string Key { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        public Sprite Value => SpriteHelper.CreateSprite<HallOfGodsRandomizer>("Sprites." + Key.Replace("/", ".").Replace("\\", "."));

        #endregion

        public ISprite Clone() => new StatueSprite(Key);
    }
}