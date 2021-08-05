using System.Linq;
using UnityModManagerNet;

namespace DvMod.CustomRemoteRange
{
    public class Settings : UnityModManager.ModSettings, IDrawable
    {
        [Draw("Normal range")]
        public int normalRange = 650;
        [Draw("Extended range")]
        public int extendedRange = 2000;
        [Draw("Enable logging")]
        public bool enableLogging = false;

        public readonly string? version = Main.mod?.Info.Version;

        public void Draw()
        {
        }

        public void OnChange()
        {
        }

        override public void Save(UnityModManager.ModEntry entry)
        {
            Save<Settings>(this, entry);
        }
    }
}
