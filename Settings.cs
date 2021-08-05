using UnityModManagerNet;

namespace DvMod.CustomRemoteRange
{
    public class Settings : UnityModManager.ModSettings, IDrawable
    {
        [Draw("Normal range")]
        public int normalRange = 650;
        [Draw("Extended range")]
        public int extendedRange = 2000;

        public readonly string? version = Main.mod?.Info.Version;

        public void OnChange()
        {
        }
    }
}
