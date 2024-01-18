
using System.IO;
using ItemChanger;
using Newtonsoft.Json;
using UnityEngine;

namespace HallOfGodsRandomizer.IC
{
    internal class StatueSprite : ISprite
    {
        [JsonIgnore] public Sprite Value => LoadSprite(ref sprite, "HallOfGodsRandomizer.Resources.Sprites.StatueMark.png");
        public ISprite Clone() => (ISprite)MemberwiseClone();

        private static Sprite sprite;

        private static Sprite LoadSprite(ref Sprite store, string name)
        {
            if (store != null)
            {
                return store;
            }
            var loc = Path.Combine(Path.GetDirectoryName(typeof(StatueSprite).Assembly.Location), name);
            var imageData = File.ReadAllBytes(loc);
            var tex = new Texture2D(1, 1, TextureFormat.RGBA32, false);
            ImageConversion.LoadImage(tex, imageData, true);
            tex.filterMode = FilterMode.Bilinear;
            store = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(.5f, .5f));
            return store;
        }
    }
}