using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class Protocols1Tests {
        [Test]
        public void Protocols1Test1() {
            ScriptInstantiator instantiator = new ScriptInstantiator();
            ProtocolAttack1Controller cont = instantiator.InstantiateScript<ProtocolAttack1Controller>();
            cont.Intercept();
            Assert.AreEqual(true, cont.intercepted);
            instantiator.CleanUp();
        }

        [Test]
        public void Protocols1Test2() {
            ScriptInstantiator instantiator = new ScriptInstantiator();
            ProtocolAttack1Controller cont = instantiator.InstantiateScript<ProtocolAttack1Controller>();
            cont.Intercept();
            Assert.AreEqual(true, cont.interceptedOnce);
            instantiator.CleanUp();
        }

        [Test]
        public void Protocols1Test3() {
            ScriptInstantiator instantiator = new ScriptInstantiator();
            ProtocolAttack2Controller cont = instantiator.InstantiateScript<ProtocolAttack2Controller>();
            
            Assert.AreEqual("N<sub><size=110%>1</size></sub>", cont.GenerateNonce());
            instantiator.CleanUp();
        }

        [Test]
        public void Protocols1Test4() {
            ScriptInstantiator instantiator = new ScriptInstantiator();
            ProtocolAttack2Controller cont = instantiator.InstantiateScript<ProtocolAttack2Controller>();
            cont.frameworkControl = instantiator.InstantiateScript<ProtocolFrameworkController>();
            cont.frameworkControl.latestMessage = new CapturedMessage("test", "test", "test", "test", "test");
            cont.Intercept();
            Assert.AreEqual("", cont.lastAliceBobMsg.message);
            instantiator.CleanUp();
        }

        [Test]
        public void Protocols1Test5() {
            ScriptInstantiator instantiator = new ScriptInstantiator();
            ProtocolAttack3Controller cont = instantiator.InstantiateScript<ProtocolAttack3Controller>();
            cont.frameworkControl = instantiator.InstantiateScript<ProtocolFrameworkController>();
            cont.frameworkControl.latestMessage = new CapturedMessage("test", "test", "test", "test", "test");
            cont.Intercept();
            Assert.AreEqual(true, cont.intercepted);
            instantiator.CleanUp();
        }

        [Test]
        public void Protocols1Test6() {
            ScriptInstantiator instantiator = new ScriptInstantiator();
            ProtocolAttack3Controller cont = instantiator.InstantiateScript<ProtocolAttack3Controller>();
            Assert.AreEqual("N<sub><size=120%>a</size></sub>", cont.GetNonce("Alice"));
            instantiator.CleanUp();
        }

        [Test]
        public void Protocols1Test7() {
            ScriptInstantiator instantiator = new ScriptInstantiator();
            ProtocolAttack4Controller cont = instantiator.InstantiateScript<ProtocolAttack4Controller>();
            cont.Intercept();
            Assert.AreEqual(true, cont.intercepted);
            instantiator.CleanUp();
        }

        [Test]
        public void Protocols1Test8() {
            ScriptInstantiator instantiator = new ScriptInstantiator();
            ProtocolAttack5Controller cont = instantiator.InstantiateScript<ProtocolAttack5Controller>();
            cont.Intercept();
            instantiator.CleanUp();
        }

        [Test]
        public void Protocols1Test9() {
            ScriptInstantiator instantiator = new ScriptInstantiator();
            ProtocolAttack5Controller cont = instantiator.InstantiateScript<ProtocolAttack5Controller>();
            cont.Continue();
            instantiator.CleanUp();
        }

        [Test]
        public void Protocols1Test10() {
            ScriptInstantiator instantiator = new ScriptInstantiator();
            ProtocolAttack5Controller cont = instantiator.InstantiateScript<ProtocolAttack5Controller>();
            cont.SelectMessage();
            instantiator.CleanUp();
        }

        [Test]
        public void Protocols1Test11() {
            ScriptInstantiator instantiator = new ScriptInstantiator();
            ProtocolAttack6Controller cont = instantiator.InstantiateScript<ProtocolAttack6Controller>();
            cont.frameworkControl = instantiator.InstantiateScript<ProtocolFrameworkController>();
            cont.frameworkControl.latestMessage = new CapturedMessage("test", "test", "test", "test", "test");
            cont.Intercept();
            Assert.AreEqual(0, cont.lastStepAB);
            instantiator.CleanUp();
        }

        [Test]
        public void Protocols1Test12() {
            ScriptInstantiator instantiator = new ScriptInstantiator();
            ProtocolAttack7Controller cont = instantiator.InstantiateScript<ProtocolAttack7Controller>();
            cont.frameworkControl = instantiator.InstantiateScript<ProtocolFrameworkController>();
            cont.frameworkControl.latestMessage = new CapturedMessage("test", "test", "test", "test", "test");
            cont.Intercept();
            Assert.AreEqual(0, cont.lastStepAB);
            instantiator.CleanUp();
        }

        [Test]
        public void Protocols1Test13() {
            ScriptInstantiator instantiator = new ScriptInstantiator();
            ProtocolAttack7Controller cont = instantiator.InstantiateScript<ProtocolAttack7Controller>();
            cont.frameworkControl = instantiator.InstantiateScript<ProtocolFrameworkController>();
            cont.frameworkControl.latestMessage = new CapturedMessage("test", "test", "test", "test", "test");
            cont.Intercept();
            Assert.AreEqual("", cont.lastAliceBobMsg.message);
            instantiator.CleanUp();
        }

        [Test]
        public void Protocols1Test14() {
            ScriptInstantiator instantiator = new ScriptInstantiator();
            ProtocolAttack7Controller cont = instantiator.InstantiateScript<ProtocolAttack7Controller>();
            cont.SelectMessage();
            instantiator.CleanUp();
        }

        [Test]
        public void Protocols1Test15() {
            ScriptInstantiator instantiator = new ScriptInstantiator();
            ProtocolAttack8Controller cont = instantiator.InstantiateScript<ProtocolAttack8Controller>();
            cont.frameworkControl = instantiator.InstantiateScript<ProtocolFrameworkController>();
            cont.frameworkControl.latestMessage = new CapturedMessage("test", "test", "test", "test", "test");
            cont.Intercept();
            Assert.AreEqual(true, cont.intercepted);
            instantiator.CleanUp();
        }

        [Test]
        public void Protocols1Test16() {
            ScriptInstantiator instantiator = new ScriptInstantiator();
            ProtocolAttack8Controller cont = instantiator.InstantiateScript<ProtocolAttack8Controller>();
            Assert.AreEqual("N<sub><size=120%>A</size></sub>", cont.GetNonce("Alice"));
            instantiator.CleanUp();
        }
    }
}
