using UnityEngine;

namespace _Anark.Scripts.GeneralUse
{
    public static class LocalSettings
    {
        public static float MusicVolume { get; set; } = 0.5f;
        public static float SoundVolume { get; set; } = 0.5f;

        public static void LoadSettings()
        {
            MusicVolume = PlayerPrefs.GetFloat(nameof(MusicVolume), MusicVolume);
            SoundVolume = PlayerPrefs.GetFloat(nameof(SoundVolume), SoundVolume);
        }

        public static void SaveSettings()
        {
            PlayerPrefs.SetFloat(nameof(MusicVolume), MusicVolume);
            PlayerPrefs.SetFloat(nameof(SoundVolume), SoundVolume);
            
            PlayerPrefs.Save();
        }
    }
}