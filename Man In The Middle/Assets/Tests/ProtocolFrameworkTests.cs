using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class ProtocolFrameworkTests
    {
        [Test]
        public void ProtocolFrameworkTest1() {
            ScriptInstantiator instantiator = new ScriptInstantiator();
            CapturedMessage cap = new CapturedMessage("test", "test", "test", "test", "test");
            Assert.AreEqual("test", cap.message);
            instantiator.CleanUp();
        }

        [Test]
        public void ProtocolFrameworkTest2() {
            ScriptInstantiator instantiator = new ScriptInstantiator();
            CapturedMessage cap = new CapturedMessage("test", "test", "test", "test", "test");
            cap.SetMessage("SetMessageTest");
            Assert.AreEqual("SetMessageTest", cap.message);
            instantiator.CleanUp();
        }

        [Test]
        public void ProtocolFrameworkTest3() {
            ScriptInstantiator instantiator = new ScriptInstantiator();
            CapturedMessage cap = new CapturedMessage("test", "test", "test", "test", "test");
            Assert.AreEqual("test", cap.GetMessage());
            instantiator.CleanUp();
        }

        [Test]
        public void ProtocolFrameworkTest4() {
            ScriptInstantiator instantiator = new ScriptInstantiator();
            MessageRef msg = instantiator.InstantiateScript<MessageRef>();
            instantiator.CleanUp();
        }

        [Test]
        public void ProtocolFrameworkTest5() {
            ScriptInstantiator instantiator = new ScriptInstantiator();
            ProtocolFrameworkController prot = instantiator.InstantiateScript<ProtocolFrameworkController>();
            prot.scrollViewContentObject = new GameObject();
            prot.lastStepRef = new GameObject();
            prot.RemoveAll();
            Assert.AreEqual(null, prot.lastStepRef);
            instantiator.CleanUp();
        }

        [Test]
        public void ProtocolFrameworkTest6() {
            ScriptInstantiator instantiator = new ScriptInstantiator();
            ProtocolFrameworkController prot = instantiator.InstantiateScript<ProtocolFrameworkController>();
            prot.scrollViewContentObject = new GameObject();
            prot.restartOnlyRef = new GameObject();
            prot.PrepareForNewStep();
            Assert.AreEqual(null, prot.restartOnlyRef);
            instantiator.CleanUp();
        }

        [Test]
        public void ProtocolFrameworkTest7() {
            ScriptInstantiator instantiator = new ScriptInstantiator();
            SendWindowController send = instantiator.InstantiateScript<SendWindowController>();
            send.sendWindow = new GameObject();
            send.ClickCloseWindowButton();
            Assert.AreEqual(false, send.sendWindow.gameObject.activeSelf);
            instantiator.CleanUp();
        }

        [Test]
        public void ProtocolFrameworkTest8() {
            ScriptInstantiator instantiator = new ScriptInstantiator();
            SendWindowController send = instantiator.InstantiateScript<SendWindowController>();
            send.selectedMessageEditsScrollViewContent = new GameObject();
            send.RemoveAllMessageEdits();
            instantiator.CleanUp();
        }

        [Test]
        public void ProtocolFrameworkTest9() {
            ScriptInstantiator instantiator = new ScriptInstantiator();
            SendWindowController send = instantiator.InstantiateScript<SendWindowController>();
            send.capturedMessages = new ArrayList();
            send.capturedMessages.Add(new GameObject());
            send.messageScrollViewContent = new GameObject();
            send.RemoveAllMessages();
            Assert.AreEqual(0, send.capturedMessages.Count);
            instantiator.CleanUp();
        }
    }
}
