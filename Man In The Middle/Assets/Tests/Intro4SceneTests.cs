using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

namespace Tests
{
    public class Intro4SceneTests
    {
        [Test]
        public void Intro4SceneTest1() {
            ScriptInstantiator instantiator = new ScriptInstantiator();
            DiffieHellmanControl diff = instantiator.InstantiateScript<DiffieHellmanControl>();
            diff.stepButtons = new GameObject[] { new GameObject() };
            diff.HideStepButton("0");
            Assert.AreEqual(false, diff.stepButtons[0].activeSelf);
            instantiator.CleanUp();
        }

        [Test]
        public void Intro4SceneTest2() {
            ScriptInstantiator instantiator = new ScriptInstantiator();
            DiffieHellmanControl diff = instantiator.InstantiateScript<DiffieHellmanControl>();
            diff.stepButtons = new GameObject[] { new GameObject() };
            diff.stepButtons[0].gameObject.AddComponent(typeof(DG.Tweening.DOTweenAnimation));
            diff.RevealStepButton("0");
            Assert.AreEqual(true, diff.stepButtons[0].activeSelf);
            instantiator.CleanUp();
        }

        [Test]
        public void Intro4SceneTest3() {
            ScriptInstantiator instantiator = new ScriptInstantiator();
            KnownDemoControl know = instantiator.InstantiateScript<KnownDemoControl>();
            know.aliceText = new DG.Tweening.DOTweenAnimation();
            know.stepBut = new GameObject();
            know.aliceArrow = know.stepBut.AddComponent<Image>();
            know.aliceArrow.GetComponent<Image>().fillMethod = Image.FillMethod.Horizontal;
            know.ShowStep();
            Assert.AreEqual(true, know.aliceText.isActive);
            instantiator.CleanUp();
        }

        [Test]
        public void Intro4SceneTest4() {
            ScriptInstantiator instantiator = new ScriptInstantiator();
            KnownDemoControl know = instantiator.InstantiateScript<KnownDemoControl>();
            know.blockImage = new DG.Tweening.DOTweenAnimation();
            know.blockText = new DG.Tweening.DOTweenAnimation();
            know.attackerImage = new DG.Tweening.DOTweenAnimation();
            know.step = 1;
            know.ShowStep();
            Assert.AreEqual(true, know.blockImage.isActive);
            instantiator.CleanUp();
        }

        [Test]
        public void Intro4SceneTest5() {
            ScriptInstantiator instantiator = new ScriptInstantiator();
            KnownDemoControl know = instantiator.InstantiateScript<KnownDemoControl>();
            know.attackerText1 = new DG.Tweening.DOTweenAnimation();
            know.stepBut = new GameObject();
            know.attackerArrow = know.stepBut.AddComponent<Image>();
            know.attackerArrow.GetComponent<Image>().fillMethod = Image.FillMethod.Horizontal;
            know.step = 2;
            know.ShowStep();
            Assert.AreEqual(true, know.attackerText1.isActive);
            instantiator.CleanUp();
        }

        [Test]
        public void Intro4SceneTest6() {
            ScriptInstantiator instantiator = new ScriptInstantiator();
            PKCAnotControl pkc = instantiator.InstantiateScript<PKCAnotControl>();
            pkc.anot1 = new GameObject();
            pkc.anot1.gameObject.AddComponent(typeof(DG.Tweening.DOTweenAnimation));
            pkc.ShowAnot1();
            Assert.AreEqual(true, pkc.anot1.gameObject.activeSelf);
            instantiator.CleanUp();
        }

        [Test]
        public void Intro4SceneTest7() {
            ScriptInstantiator instantiator = new ScriptInstantiator();
            PKCAnotControl pkc = instantiator.InstantiateScript<PKCAnotControl>();
            pkc.anot2 = new GameObject();
            pkc.anot2.gameObject.AddComponent(typeof(DG.Tweening.DOTweenAnimation));
            pkc.ShowAnot2();
            Assert.AreEqual(true, pkc.anot2.gameObject.activeSelf);
            instantiator.CleanUp();
        }

        [Test]
        public void Intro4SceneTest8() {
            ScriptInstantiator instantiator = new ScriptInstantiator();
            SignatureTrickControl sig = instantiator.InstantiateScript<SignatureTrickControl>();
            sig.signButton = new GameObject();
            sig.signButton.gameObject.AddComponent(typeof(DG.Tweening.DOTweenAnimation));
            sig.ShowSignButton();
            Assert.AreEqual(true, sig.signButton.gameObject.activeSelf);
            instantiator.CleanUp();
        }
    }
}
