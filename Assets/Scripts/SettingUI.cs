using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingUI : MonoBehaviour
{
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;
    [SerializeField] private Button closeButton;
    private void Awake()
    {
        musicSlider.onValueChanged.AddListener(ChangeMusicVolume);
        sfxSlider.onValueChanged.AddListener(ChangeSfxVolume);
        closeButton.onClick.AddListener(() =>
        {
            this.gameObject.SetActive(false);
        });
    }
    void Start()
    {
        if (PlayerPrefs.HasKey("Music"))
        {
            float savedVolume = PlayerPrefs.GetFloat("Music");
            musicSlider.value = savedVolume;
        }
        if (PlayerPrefs.HasKey("Sfx"))
        {
            float savedVolume = PlayerPrefs.GetFloat("Sfx");
            sfxSlider.value = savedVolume;
        }
    }

    private void ChangeMusicVolume(float volume)
    {
        GeneralAudioManager audioManager = FindObjectOfType<GeneralAudioManager>();
        if (audioManager != null)
        {
            audioManager.MusicVolume(volume);
        }
        PlayerPrefs.SetFloat("Music", volume);
        PlayerPrefs.Save();
    }

    private void ChangeSfxVolume(float volume)
    {
        GeneralAudioManager audioManager = FindObjectOfType<GeneralAudioManager>();
        if (audioManager != null)
        {
            audioManager.EffectValue(volume);
        }
        PlayerPrefs.SetFloat("Sfx", volume);
        PlayerPrefs.Save();
    }
}
