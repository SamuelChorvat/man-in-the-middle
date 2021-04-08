using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class Intro2SceneTests
    {
        [Test]
        public void Intro2SceneTest1() {
            ScriptInstantiator instantiator = new ScriptInstantiator();
            VigenereController vig = instantiator.InstantiateScript<VigenereController>();
            vig.tableWindow = new GameObject();
            vig.CloseTableWindow();
            Assert.AreEqual(false, vig.tableWindow.activeSelf);
            instantiator.CleanUp();
        }

        [Test]
        public void Intro2SceneTest2() {
            ScriptInstantiator instantiator = new ScriptInstantiator();
            VigenereController vig = instantiator.InstantiateScript<VigenereController>();
            vig.tableWindow = new GameObject();
            vig.tableWindowAnim = new DG.Tweening.DOTweenAnimation();
            vig.OpenTableWindow();
            Assert.AreEqual(true, vig.tableWindow.activeSelf);
            instantiator.CleanUp();
        }

        [Test]
        public void Intro2SceneTest3() {
            ScriptInstantiator instantiator = new ScriptInstantiator();
            XORController xor = instantiator.InstantiateScript<XORController>();
            xor.puzzleObject = new GameObject();
            xor.showPuzzleAnims = new DG.Tweening.DOTweenAnimation[0];
            xor.ShowPuzzle();
            Assert.AreEqual(true, xor.puzzleObject.activeSelf);
            instantiator.CleanUp();
        }

        [Test]
        public void Intro2SceneTest4() {
            ScriptInstantiator instantiator = new ScriptInstantiator();
            XORController xor = instantiator.InstantiateScript<XORController>();
            xor.puzzleObject = new GameObject();
            xor.xorNums = new XORNum[0];
            xor.ResetPuzzle();
            Assert.AreEqual(0, xor.correct);
            instantiator.CleanUp();
        }

        [Test]
        public void Intro2SceneTest5() {
            ScriptInstantiator instantiator = new ScriptInstantiator();
            XORController xor = instantiator.InstantiateScript<XORController>();
            xor.addCorrect();
            Assert.AreEqual(1, xor.correct);
            instantiator.CleanUp();
        }

        [Test]
        public void Intro2SceneTest6() {
            ScriptInstantiator instantiator = new ScriptInstantiator();
            ModuloPuzzleControl mod = instantiator.InstantiateScript<ModuloPuzzleControl>();
            mod.firstNumber = new GameObject();
            mod.firstNumberAnim = new DG.Tweening.DOTweenAnimation();
            mod.DisplayFirstNo();
            Assert.AreEqual(true, mod.firstNumber.activeSelf);
            instantiator.CleanUp();
        }

        [Test]
        public void Intro2SceneTest7() {
            ScriptInstantiator instantiator = new ScriptInstantiator();
            ModuloPuzzleControl mod = instantiator.InstantiateScript<ModuloPuzzleControl>();
            mod.numbers = new GameObject[0];
            mod.ResetPuzzle();
            instantiator.CleanUp();
        }
    }
}
