using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtocolAttack3Controller : MonoBehaviour {
    [Header("Framework Controller")]
    public GameObject protocolFramework;
    public ProtocolFrameworkController frameworkControl;

    private int lastStepAC = 0;

    public void RestartProtocol() {
        lastStepAC = 0;
        SendAliceCarolStep1();
    }

    public void Intercept() {
    }

    public void SendMessage() {
    }

    public void Continue() {
    }

    public void SelectMessage() {
    }

    private void AliceReply(CapturedMessage msg) {
    }

    private void BobReply(CapturedMessage msg) {
    }

    private string GetNonce(string name) {
        if (name.Equals("Alice")) {
            return "N<sub><size=120%>a</size></sub>";
        } else if (name.Equals("Bob")) {
            return "N<sub><size=120%>b</size></sub>";
        } else if (name.Equals("Carol")) {
            return "N<sub><size=120%>c</size></sub>";
        }
        return null;
    }

    private void SendAliceCarolStep1() {
        frameworkControl.NewStep();
        lastStepAC = 1;
        CapturedMessage newMessage = new CapturedMessage("AliceCarolMessage" + lastStepAC, "E<sub>C</sub>( " + GetNonce("Alice") + " , A )", "Alice", "Carol", "Carol");
        frameworkControl.latestMessage = newMessage;
        frameworkControl.lastStepControl.SetMessageArrow("Alice", "Carol", frameworkControl.latestMessage.GetMessage(), "Carol");
    }
}
