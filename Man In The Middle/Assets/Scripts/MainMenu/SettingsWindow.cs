﻿using System;
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
    public GameObject confirmResetWindow;
    public GameObject confirmResetBackground;

    Resolution[] resolutions;

    private void Start() {
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        resolutions = Screen.resolutions;

        for (int i = 0; i < resolutions.Length; i++) {
            string option = resolutions[i].width + "x" + resolutions[i].height + " " + resolutions[i].refreshRate + "Hz";
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height && resolutions[i].refreshRate == Screen.currentResolution.refreshRate) {
                ES3.Save("currentResolutionIndex", i);
            }   
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.RefreshShownValue();

        resolutionDropdown.value = ES3.Load("currentResolutionIndex", 1);
        volumeSlider.value = (float) ES3.Load("currentVolume", 0.5f);
        soundToggle.isOn = ES3.Load("soundEnabled", true);
        fullScreenToggle.isOn = Screen.fullScreen;
    }

    public void SetVolume(float volume) {
        if (ES3.Load("soundEnabled", true)) {
            AudioListener.volume = volume;
        }
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
        ES3.Save("currentResolutionIndex", resolutionIndex);
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
        confirmResetWindow.SetActive(true);
        confirmResetBackground.SetActive(true);
    }

    public void NoConfirmResetWindow() {
        confirmResetWindow.SetActive(false);
        confirmResetBackground.SetActive(false);
    }

    public void YesConfirmResetWindow() {
        confirmResetWindow.SetActive(false);
        confirmResetBackground.SetActive(false);
        settingWindow.SetActive(false);
        settingsWindowBackground.SetActive(false);
        int resolution = ES3.Load("currentResolutionIndex", 1);
        float currentVol = ES3.Load("currentVolume", 0.5f);
        bool soundOn = ES3.Load("soundEnabled", true);
        ES3.DeleteFile("SaveFile.es3");
        ES3.Save("currentResolutionIndex", resolution);
        ES3.Save("currentVolume", currentVol);
        ES3.Save("soundEnabled", soundOn);
        SceneManager.LoadScene("MainMenu");
    }

    public void ExitGame() {
        Application.Quit();
    }
}
