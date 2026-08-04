using UnityEngine;
using UnityEngine.Audio;

public class SoundMixerManager : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;

    public void SetMasterVolume(float level)
    {
        //audioMixer.SetFloat("masterVolume", level);
        audioMixer.SetFloat("Master", Mathf.Log10(level) * 20f);

    }
    public void SetSoundFXVolume(float level)
    {
        //audioMixer.SetFloat("soundFXVolume", level);
        audioMixer.SetFloat("SoundFX", Mathf.Log10(level) * 20f);
        
    }
    public void SetMusicVolume(float level)
    {
        //audioMixer.SetFloat("musicVolume", level);
        audioMixer.SetFloat("Music", Mathf.Log10(level) * 20f);
        
    }
}
