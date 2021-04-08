using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class HintsTests {

        [Test]
        public void HintsTest1() {
            ScriptInstantiator instantiator = new ScriptInstantiator();
            HintsController hint = instantiator.InstantiateScript<HintsController>();
            hint.getHintRef = new GameObject();
            hint.scrollViewContentObject = new GameObject();
            hint.RemoveAllHints();
            Assert.AreEqual(null, hint.getHintRef);
            instantiator.CleanUp();
        }

        [Test]
        public void HintsTest2() {
            ScriptInstantiator instantiator = new ScriptInstantiator();
            HintsController hint = instantiator.InstantiateScript<HintsController>();
            hint.getHintRef = new GameObject();
            hint.scrollViewContentObject = new GameObject();
            hint.RemoveAllHints();
            Assert.AreEqual(0, hint.scrollViewContentObject.transform.childCount);
            instantiator.CleanUp();
        }

        [Test]
        public void HintsTest3() {
            ScriptInstantiator instantiator = new ScriptInstantiator();
            HintsController hint = instantiator.InstantiateScript<HintsController>();
            hint.getHintRef = new GameObject();
            hint.PrepareForNewHint();
            Assert.AreEqual(null, hint.getHintRef);
            instantiator.CleanUp();
        }

        [Test]
        public void HintsTest4() {
            ScriptInstantiator instantiator = new ScriptInstantiator();
            HintsController hint = instantiator.InstantiateScript<HintsController>();
            hint.hintsWindow = new GameObject();
            hint.OpenHintsWindow();
            Assert.AreEqual(true, hint.hintsWindow.gameObject.activeSelf);
            instantiator.CleanUp();
        }

        [Test]
        public void HintsTest5() {
            ScriptInstantiator instantiator = new ScriptInstantiator();
            HintsController hint = instantiator.InstantiateScript<HintsController>();
            hint.hintsWindow = new GameObject();
            hint.CloseHintsWindow();
            Assert.AreEqual(false, hint.hintsWindow.gameObject.activeSelf);
            instantiator.CleanUp();
        }
    }
}
