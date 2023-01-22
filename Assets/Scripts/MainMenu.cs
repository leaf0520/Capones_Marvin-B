using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    private Button PlayGameButton;
    private Button QuitGameButton;
    private Button OpenGameSettingsButton;
    private Button CloseGameSettingsButton;
    private TMP_Dropdown ResolutionDropdown;

    public Slider BgmVolumeSlider;

    private GameObject SettingsPanel;

    private void Awake()
    {
        SettingsPanel = GameObject.Find("SettingsPanel").gameObject;
        ResolutionDropdown = GameObject.Find("ResolutionDropdown").gameObject.GetComponent<TMP_Dropdown>();

        PlayGameButton = GameObject.Find("Play").gameObject.GetComponent<Button>();
        QuitGameButton = GameObject.Find("Quit").gameObject.GetComponent<Button>();
        OpenGameSettingsButton = GameObject.Find("Settings").gameObject.GetComponent<Button>();
        CloseGameSettingsButton = GameObject.Find("CloseSettings").gameObject.GetComponent<Button>();

        PlayGameButton.onClick.AddListener(PlayGame);
        QuitGameButton.onClick.AddListener(QuitGame);
        OpenGameSettingsButton.onClick.AddListener(OpenGameSettings);
        CloseGameSettingsButton.onClick.AddListener(CloseGameSettings);
        ResolutionDropdown.onValueChanged.AddListener(ResolutionDropdownValueChanged);

        BgmVolumeSlider.onValueChanged.AddListener(BgmVolumeOnValueChanged);

        BgmVolumeSlider.value = AudioController.Instance.LoadBGMVolume();

        SettingsPanel.SetActive(false);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game Button Clicked");
        Application.Quit();
    }
    public void OpenGameSettings()
    {
        SettingsPanel.SetActive(true);
    }
    public void CloseGameSettings()
    {
        SettingsPanel.SetActive(false);
    }

    public void ResolutionDropdownValueChanged(int value)
    {
        switch (value)
        {
            case 0:
                Screen.SetResolution(1920, 1080, true);
                break;
            case 1:
                Screen.SetResolution(900, 600, true);
                break;
            case 2:
                Screen.SetResolution(1024, 1024, true);
                break;
        }
    }

    public void BgmVolumeOnValueChanged(float value)
    {
        AudioController.Instance.BgmAudioSource.volume = BgmVolumeSlider.value;
        AudioController.Instance.SaveBgmVolume(BgmVolumeSlider.value);
    }

    public void DeleteSave()
    {
        PlayerPrefs.DeleteAll();
    }
}
