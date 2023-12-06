using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralAudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip jumpSoundEffect;
    [SerializeField] private AudioClip collectSoundEffect;
    [SerializeField] private AudioClip deathSoundEffect;
    [SerializeField] private AudioClip finishSoundEffect;

    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource effectSource;

    public static GeneralAudioManager Instance { get; set; }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            Instance = this;
        }
        DontDestroyOnLoad(Instance);
        PlayerPrefs.SetFloat("Music", .5f);
        PlayerPrefs.SetFloat("Sfx", .5f);
        PlayerPrefs.Save();
    }

    public void MusicVolume(float volume)
    {
        musicSource.volume = volume;
    }
    public void EffectValue(float volume)
    {
        effectSource.volume = volume;
    }

    public void PlayJumpSoundEffect()
    {
        effectSource.PlayOneShot(jumpSoundEffect);
    }

    public void PlayCollectSoundEffect()
    {
        effectSource.PlayOneShot(collectSoundEffect);
    }

    public void PlayDeathSoundEffect()
    {
        effectSource.PlayOneShot(deathSoundEffect);
    }
    public void PlayFinishSoundEffect()
    {
        effectSource.PlayOneShot(finishSoundEffect);
    }
}
