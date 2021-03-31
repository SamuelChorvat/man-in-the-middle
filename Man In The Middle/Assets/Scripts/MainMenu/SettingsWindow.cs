using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsWindow : MonoBehaviour {

    public Dropdown resolutionDropdown;
    public Dropdown qualityDropdown;
    public Toggle fullScreenToggle;
    public Toggle soundToggle;
    public Slider volumeSlider;

    public GameObject settingWindow;
    public GameObject settingsWindowBackground;

    Resolution[] resolutions;

    private void Start() {
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        resolutions = Screen.resolutions;
        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++) {
            string option = resolutions[i].width + " x " +
                     resolutions[i].height;
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width
                  && resolutions[i].height == Screen.currentResolution.height)
                currentResolutionIndex = i;
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.RefreshShownValue();

        volumeSlider.value = (float) ES3.Load("currentVolume", 0.5f);
        soundToggle.isOn = ES3.Load("soundEnabled", true);
        fullScreenToggle.isOn = Screen.fullScreen;
    }

    public void SetVolume(float volume) {
        AudioListener.volume = volume;
        ES3.Save("currentVolume", volume);
    }

    public void SetSound(bool isOn) {
        if (isOn) {
            AudioListener.volume = (float)ES3.Load("currentVolume", 0.5f);
        } else {
            AudioListener.volume = 0;
        }
        ES3.Save("soundEnabled", isOn);
    }

    public void SetFullscreen(bool isFullscreen) {
        Screen.fullScreen = isFullscreen;
        ES3.Save("fullScreen", isFullscreen);
    }

    public void SetResolution(int resolutionIndex) {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width,
                  resolution.height, Screen.fullScreen);
        ES3.Save("currentHeight", resolution.height);
        ES3.Save("currentWidth", resolution.width);
    }

	public void SetQuality(int qualityIndex) {
		QualitySettings.SetQualityLevel(qualityIndex);
		qualityDropdown.value = qualityIndex;
        ES3.Save("currentQuality", qualityIndex);
    }

    public void OpenSettingsWindow() {
        settingWindow.SetActive(true);
        settingsWindowBackground.SetActive(true);
    }

    public void CloseSettingsWindow() {
        settingWindow.SetActive(false);
        settingsWindowBackground.SetActive(false);
    }

    public void ResetGame() {
        ES3.DeleteFile("SaveFile.es3");
        SceneManager.LoadScene("MainMenu");
    }
}
