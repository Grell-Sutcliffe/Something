using UnityEngine;
using UnityEngine.UI;

namespace BHSCamp.Options
{
    public class AudioOptions : MonoBehaviour
    {
        [SerializeField] private Slider _masterVolume;
        [SerializeField] private Slider _sfxVolume;
        [SerializeField] private Slider _musicVolume;

        private SoundOptions _currentOptions;

        private void Start()
        {
            _currentOptions = SaveLoadSystem.LoadSound();
            _masterVolume.value = _currentOptions.Master;
            _sfxVolume.value = _currentOptions.SFX;
            _musicVolume.value = _currentOptions.Music;
        }

        private void Update()
        {
            if (Input.GetMouseButtonUp(0))
                SaveSoundSettings();
        }

        public void SetMasterVolume()
        {
            _currentOptions.Master = _masterVolume.value;
        }

        public void SetSFXVolume()
        {
            _currentOptions.SFX = _sfxVolume.value;
        }

        public void SetMusicVolume()
        {
            _currentOptions.Music = _musicVolume.value;
        }

        private void SaveSoundSettings()
        {
            SaveLoadSystem.SaveSound(_currentOptions);
        }
    }
}