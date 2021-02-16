using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtocolAttack2Controller : MonoBehaviour
{
    [Header("Framework Controller")]
    public GameObject protocolFramework;
    public ProtocolFrameworkController frameworkControl;

    private int lastStepAB = 0;
    private int lastStepCA = 0;
    private int lastStepCB = 0;

    public void RestartProtocol() {
        lastStepAB = 0;
        lastStepCA = 0;
        lastStepCB = 0;
        SendAliceBobStep1();
    }

    public void Intercept() {
        if (lastStepAB > 0) {
            lastStepAB -= 1; 
        }
    }

    public void SendMessage() {
    }

    public void Continue() {
        switch (lastStepAB) {
            case 0:
                SendAliceBobStep1();
                break;
            case 1:
                SendAliceBobStep2();
                break;
            case 2:
                SendAliceBobStep3();
                break;
            case 3:
                SendAliceBobStep4();
                break;
            case 4:
                SendAliceBobStep5();
                break;
            case 5:
                SendAliceBobStep6();
                frameworkControl.Fail("Attack failed because the protocol finished as expected without you affecting it in any way.");
                break;
        }
    }

    public void SelectMessage() {
        switch (frameworkControl.sendWindowController.currentlySelectedMessage.messageName) {
            case ("AliceBobMessage1"):
                break;
        }
    }

    private void SendAliceBobStep1() {
        frameworkControl.NewStep();
        lastStepAB = 1;
        CapturedMessage newMessage = new CapturedMessage("AliceBobMessage" + lastStepAB, "A");
        frameworkControl.latestMessage = newMessage;
        frameworkControl.lastStepControl.SetMessageArrow("Alice", "Bob", frameworkControl.latestMessage.GetMessage(), "");
    }

    private void SendAliceBobStep2() {
        frameworkControl.NewStep();
        lastStepAB = 2;
        CapturedMessage newMessage = new CapturedMessage("AliceBobMessage" + lastStepAB, "{ N<sub><size=110%>a</size></sub> }<sub><size=130%>Kab</sub>");
        frameworkControl.latestMessage = newMessage;
        frameworkControl.lastStepControl.SetMessageArrow("Bob", "Alice", frameworkControl.latestMessage.GetMessage(), "");
    }

    private void SendAliceBobStep3() {
        frameworkControl.NewStep();
        lastStepAB = 3;
        CapturedMessage newMessage = new CapturedMessage("AliceBobMessage" + lastStepAB, "{ N<sub><size=110%>a</size></sub> + 1 }<sub><size=130%>Kab</size></sub> , { Pay Carol £5 }<sub><size=130%>Kab</size>");
        frameworkControl.latestMessage = newMessage;
        frameworkControl.lastStepControl.SetMessageArrow("Alice", "Bob", frameworkControl.latestMessage.GetMessage(), "");
    }

    private void SendAliceBobStep4() {
        frameworkControl.NewStep();
        lastStepAB = 4;
        CapturedMessage newMessage = new CapturedMessage("AliceBobMessage" + lastStepAB, "A");
        frameworkControl.latestMessage = newMessage;
        frameworkControl.lastStepControl.SetMessageArrow("Alice", "Bob", frameworkControl.latestMessage.GetMessage(), "");
    }

    private void SendAliceBobStep5() {
        frameworkControl.NewStep();
        lastStepAB = 5;
        CapturedMessage newMessage = new CapturedMessage("AliceBobMessage" + lastStepAB, "{ N<sub><size=110%>a2</size></sub> }<sub><size=130%>Kab</sub>");
        frameworkControl.latestMessage = newMessage;
        frameworkControl.lastStepControl.SetMessageArrow("Bob", "Alice", frameworkControl.latestMessage.GetMessage(), "");
    }

    private void SendAliceBobStep6() {
        frameworkControl.NewStep();
        lastStepAB = 3;
        CapturedMessage newMessage = new CapturedMessage("AliceBobMessage" + lastStepAB, "{ N<sub><size=110%>a2</size></sub> + 1 }<sub><size=130%>Kab</size></sub> , { Pay Bob £5 }<sub><size=130%>Kab</size>");
        frameworkControl.latestMessage = newMessage;
        frameworkControl.lastStepControl.SetMessageArrow("Alice", "Bob", frameworkControl.latestMessage.GetMessage(), "");
    }
}
