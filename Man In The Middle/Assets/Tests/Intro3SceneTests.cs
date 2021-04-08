using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

namespace Tests
{
    public class Intro3SceneTests
    {
        [Test]
        public void Intro3SceneTest1() {
            ScriptInstantiator instantiator = new ScriptInstantiator();
            CBCDemoControl cbc = instantiator.InstantiateScript<CBCDemoControl>();
            cbc.gameObject.AddComponent(typeof(DG.Tweening.DOTweenAnimation));
            cbc.gameObject.AddComponent(typeof(RectTransform));
            cbc.ShowDemo();
            Assert.AreEqual(true, cbc.gameObject.activeSelf);
            instantiator.CleanUp();
        }

        [Test]
        public void Intro3SceneTest2() {
            ScriptInstantiator instantiator = new ScriptInstantiator();
            CBCDemoControl cbc = instantiator.InstantiateScript<CBCDemoControl>();
            cbc.gameObject.AddComponent(typeof(DG.Tweening.DOTweenAnimation));
            cbc.gameObject.AddComponent(typeof(RectTransform));
            cbc.ShowDemo();
            Assert.AreEqual(new Vector3(0, 0, 0), cbc.gameObject.GetComponent<RectTransform>().localScale);
            instantiator.CleanUp();
        }

        [Test]
        public void Intro3SceneTest3() {
            ScriptInstantiator instantiator = new ScriptInstantiator();
            DESBruteforce brut = instantiator.InstantiateScript<DESBruteforce>();
            brut.moneyObj = new GameObject();
            brut.fillImage = brut.moneyObj.AddComponent<Image>();
            Assert.AreEqual(true, brut.moneyObj.activeSelf);
            instantiator.CleanUp();
        }

        [Test]
        public void Intro3SceneTest4() {
            ScriptInstantiator instantiator = new ScriptInstantiator();
            DESBruteforceControl brut = instantiator.InstantiateScript<DESBruteforceControl>();
            brut.demo = new GameObject();
            brut.bruteObj = new GameObject[0];
            brut.ShowBruteForce();
            Assert.AreEqual(true, brut.demo.activeSelf);
            instantiator.CleanUp();
        }

        [Test]
        public void Intro3SceneTest5() {
            ScriptInstantiator instantiator = new ScriptInstantiator();
            DESBruteforceControl brut = instantiator.InstantiateScript<DESBruteforceControl>();
            brut.demo = new GameObject();
            brut.bruteObj = new GameObject[0];
            brut.ResetDemo();
            Assert.AreEqual(false, brut.demo.activeSelf);
            instantiator.CleanUp();
        }

        [Test]
        public void Intro3SceneTest6() {
            ScriptInstantiator instantiator = new ScriptInstantiator();
            DESBruteforceControl brut = instantiator.InstantiateScript<DESBruteforceControl>();
            brut.ForcedDes();
            Assert.AreEqual(1, brut.forced);
            instantiator.CleanUp();
        }

        [Test]
        public void Intro3SceneTest7() {
            ScriptInstantiator instantiator = new ScriptInstantiator();
            GameConsoleAttack game = instantiator.InstantiateScript<GameConsoleAttack>();
            game.copyButObj = new GameObject();
            game.copyButAnim = new DG.Tweening.DOTweenAnimation();
            game.ShowCopy();
            Assert.AreEqual(true, game.copyButObj.activeSelf);
            instantiator.CleanUp();
        }

        [Test]
        public void Intro3SceneTest8() {
            ScriptInstantiator instantiator = new ScriptInstantiator();
            GameConsoleAttack game = instantiator.InstantiateScript<GameConsoleAttack>();
            game.copyButObj = new GameObject();
            game.pasteButObj = new GameObject();
            game.pasteButAnim = new DG.Tweening.DOTweenAnimation();
            game.CopyClick();
            Assert.AreEqual(false, game.copyButObj.activeSelf);
            instantiator.CleanUp();
        }

        [Test]
        public void Intro3SceneTest9() {
            ScriptInstantiator instantiator = new ScriptInstantiator();
            GameConsoleAttack game = instantiator.InstantiateScript<GameConsoleAttack>();
            game.copyButObj = new GameObject();
            game.pasteButObj = new GameObject();
            game.pasteButAnim = new DG.Tweening.DOTweenAnimation();
            game.CopyClick();
            Assert.AreEqual(true, game.pasteButObj.activeSelf);
            instantiator.CleanUp();
        }
    }
}
