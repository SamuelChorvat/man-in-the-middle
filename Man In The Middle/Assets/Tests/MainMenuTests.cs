using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class MainMenuTests
    {
        [Test]
        public void MainMenuTest1() {
            ScriptInstantiator instantiator = new ScriptInstantiator();
            SettingsWindow settings = instantiator.InstantiateScript<SettingsWindow>();
            settings.SetSound(false);
            Assert.AreEqual(false, ES3.Load("soundEnabled", true));
            instantiator.CleanUp();
        }

        [Test]
        public void MainMenuTest2() {
            ScriptInstantiator instantiator = new ScriptInstantiator();
            SettingsWindow settings = instantiator.InstantiateScript<SettingsWindow>();
            settings.SetSound(true);
            Assert.AreEqual(true, ES3.Load("soundEnabled", true));
            instantiator.CleanUp();
        }

        [Test]
        public void MainMenuTest3() {
            ScriptInstantiator instantiator = new ScriptInstantiator();
            SettingsWindow settings = instantiator.InstantiateScript<SettingsWindow>();
            settings.SetVolume(0.3f);
            Assert.AreEqual(0.3f, ES3.Load("currentVolume", 0.5f));
            instantiator.CleanUp();
        }

        [Test]
        public void MainMenuTest4() {
            ScriptInstantiator instantiator = new ScriptInstantiator();
            SettingsWindow settings = instantiator.InstantiateScript<SettingsWindow>();
            Assert.AreEqual(20, ES3.Load("currentResolutionIndex", 1));
            instantiator.CleanUp();
        }

        [Test]
        public void MainMenuTest5() {
            ScriptInstantiator instantiator = new ScriptInstantiator();
            SettingsWindow settings = instantiator.InstantiateScript<SettingsWindow>();
            settings.SetFullscreen(true);
            Assert.AreEqual(true, ES3.Load("fullScreen", false));
            instantiator.CleanUp();
        }

        [Test]
        public void MainMenuTest6() {
            ScriptInstantiator instantiator = new ScriptInstantiator();
            SettingsWindow settings = instantiator.InstantiateScript<SettingsWindow>();
            Assert.AreEqual(1, ES3.Load("currentQuality", 1));
            instantiator.CleanUp();
        }

        [Test]
        public void MainMenuTest7() {
            ScriptInstantiator instantiator = new ScriptInstantiator();
            SettingsWindow settings = instantiator.InstantiateScript<SettingsWindow>();
            settings.settingWindow = new GameObject();
            settings.settingsWindowBackground = new GameObject();
            settings.OpenSettingsWindow();
            Assert.AreEqual(true, settings.settingWindow.activeSelf);
            instantiator.CleanUp();
        }

        [Test]
        public void MainMenuTest8() {
            ScriptInstantiator instantiator = new ScriptInstantiator();
            SettingsWindow settings = instantiator.InstantiateScript<SettingsWindow>();
            settings.settingWindow = new GameObject();
            settings.settingsWindowBackground = new GameObject();
            settings.CloseSettingsWindow();
            Assert.AreEqual(false, settings.settingWindow.activeSelf);
            instantiator.CleanUp();
        }

        [Test]
        public void MainMenuTest9() {
            ScriptInstantiator instantiator = new ScriptInstantiator();
            SettingsWindow settings = instantiator.InstantiateScript<SettingsWindow>();
            settings.confirmResetWindow = new GameObject();
            settings.confirmResetBackground = new GameObject();
            settings.ResetGame();
            Assert.AreEqual(true, settings.confirmResetBackground.activeSelf);
            instantiator.CleanUp();
        }

        [Test]
        public void MainMenuTest10() {
            ScriptInstantiator instantiator = new ScriptInstantiator();
            SettingsWindow settings = instantiator.InstantiateScript<SettingsWindow>();
            settings.confirmResetWindow = new GameObject();
            settings.confirmResetBackground = new GameObject();
            settings.NoConfirmResetWindow();
            Assert.AreEqual(false, settings.confirmResetBackground.activeSelf);
            instantiator.CleanUp();
        }
    }
}
