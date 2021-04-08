using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class Intro1SceneTests
    {
        [Test]
        public void Intro1SceneTest1() {
            ScriptInstantiator instantiator = new ScriptInstantiator();
            IntroCaesarPuzzle caesar = instantiator.InstantiateScript<IntroCaesarPuzzle>();
            caesar.oldText = new GameObject();
            caesar.newText = new GameObject();
            caesar.SwapText();
            Assert.AreEqual(false, caesar.oldText.activeSelf);
            instantiator.CleanUp();
        }

        [Test]
        public void Intro1SceneTest2() {
            ScriptInstantiator instantiator = new ScriptInstantiator();
            IntroCaesarPuzzle caesar = instantiator.InstantiateScript<IntroCaesarPuzzle>();
            caesar.oldText = new GameObject();
            caesar.newText = new GameObject();
            caesar.SwapTextBack();
            Assert.AreEqual(true, caesar.oldText.activeSelf);
            instantiator.CleanUp();
        }

        [Test]
        public void Intro1SceneTest3() {
            ScriptInstantiator instantiator = new ScriptInstantiator();
            IntroCaesarPuzzle caesar = instantiator.InstantiateScript<IntroCaesarPuzzle>();
            caesar.ResetBooleans();
            Assert.AreEqual(false, caesar.experienceSolved);
            instantiator.CleanUp();
        }

        [Test]
        public void Intro1SceneTest4() {
            ScriptInstantiator instantiator = new ScriptInstantiator();
            FrequenciesWindowController freq = instantiator.InstantiateScript<FrequenciesWindowController>();
            freq.window = new GameObject();
            freq.frequenciesButton = new GameObject();
            freq.substituteButton = new GameObject();
            freq.CloseWindow();
            Assert.AreEqual(false, freq.window.activeSelf);
            instantiator.CleanUp();
        }

        [Test]
        public void Intro1SceneTest5() {
            ScriptInstantiator instantiator = new ScriptInstantiator();
            FrequencyAnalysisController freq = instantiator.InstantiateScript<FrequencyAnalysisController>();
            Assert.AreEqual(false, freq.IsLetter('1'));
            instantiator.CleanUp();
        }

        [Test]
        public void Intro1SceneTest6() {
            ScriptInstantiator instantiator = new ScriptInstantiator();
            FrequencyAnalysisController freq = instantiator.InstantiateScript<FrequencyAnalysisController>();
            Assert.AreEqual(true, freq.IsLetter('a'));
            instantiator.CleanUp();
        }

        [Test]
        public void Intro1SceneTest7() {
            ScriptInstantiator instantiator = new ScriptInstantiator();
            FrequencyAnalysisController freq = instantiator.InstantiateScript<FrequencyAnalysisController>();
            Assert.AreEqual(true, freq.IsLetter('Z'));
            instantiator.CleanUp();
        }

        [Test]
        public void Intro1SceneTest8() {
            ScriptInstantiator instantiator = new ScriptInstantiator();
            FrequencyAnalysisController freq = instantiator.InstantiateScript<FrequencyAnalysisController>();
            freq.IncreaseCorrect();
            Assert.AreEqual(1, freq.correct);
            instantiator.CleanUp();
        }

        [Test]
        public void Intro1SceneTest9() {
            ScriptInstantiator instantiator = new ScriptInstantiator();
            RotationsCaesarCipher rot = instantiator.InstantiateScript<RotationsCaesarCipher>();
            Assert.AreEqual(0, rot.GetIndex('A'));
            instantiator.CleanUp();
        }

        [Test]
        public void Intro1SceneTest10() {
            ScriptInstantiator instantiator = new ScriptInstantiator();
            RotationsCaesarCipher rot = instantiator.InstantiateScript<RotationsCaesarCipher>();
            Assert.AreEqual(true, rot.GetAlphabet().Contains("A"));
            instantiator.CleanUp();
        }

        [Test]
        public void Intro1SceneTest11() {
            ScriptInstantiator instantiator = new ScriptInstantiator();
            SubstituteWindowController sub = instantiator.InstantiateScript<SubstituteWindowController>();
            sub.window = new GameObject();
            sub.substituteButton = new GameObject();
            sub.frequenciesButton = new GameObject();
            sub.CloseWindow();
            Assert.AreEqual(false, sub.window.activeSelf);
            instantiator.CleanUp();
        }

        [Test]
        public void Intro1SceneTest12() {
            ScriptInstantiator instantiator = new ScriptInstantiator();
            SubstituteWindowController sub = instantiator.InstantiateScript<SubstituteWindowController>();
            sub.window = new GameObject();
            sub.substituteButton = new GameObject();
            sub.frequenciesButton = new GameObject();
            sub.subAnim = new DG.Tweening.DOTweenAnimation();
            sub.OpenWindow();
            Assert.AreEqual(true, sub.window.activeSelf);
            instantiator.CleanUp();
        }
    }
}
