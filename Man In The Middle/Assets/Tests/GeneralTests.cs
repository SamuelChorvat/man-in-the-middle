using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

namespace Tests
{
    public class GeneralTests {

        [Test]
        public void GeneralTest1() {
            ScriptInstantiator instantiator = new ScriptInstantiator();
            RevealContinueButton rev = instantiator.InstantiateScript<RevealContinueButton>();
            rev.gameObject.AddComponent<Image>();
            rev.gameObject.GetComponent<Image>().fillMethod = Image.FillMethod.Horizontal;
            rev.textrev = new GameObject();
            rev.StartReveal();
            Assert.AreEqual(true, rev.textrev.activeSelf);
            instantiator.CleanUp();
        }

        [Test]
        public void GeneralTest2() {
            ScriptInstantiator instantiator = new ScriptInstantiator();
            RevealContinueButton rev = instantiator.InstantiateScript<RevealContinueButton>();
            rev.gameObject.AddComponent<Image>();
            rev.gameObject.GetComponent<Image>().fillMethod = Image.FillMethod.Horizontal;
            rev.textrev = new GameObject();
            rev.ResetButton();
            Assert.AreEqual(false, rev.gameObject.activeSelf);
            instantiator.CleanUp();
        }

        [Test]
        public void GeneralTest3() {
            ScriptInstantiator instantiator = new ScriptInstantiator();
            RevealContinueButton rev = instantiator.InstantiateScript<RevealContinueButton>();
            rev.gameObject.AddComponent<Image>();
            rev.gameObject.GetComponent<Image>().fillMethod = Image.FillMethod.Horizontal;
            rev.textrev = new GameObject();
            rev.StartDissapear();
            Assert.AreEqual(true, rev.textrev.activeSelf);
            instantiator.CleanUp();
        }
    }
}
