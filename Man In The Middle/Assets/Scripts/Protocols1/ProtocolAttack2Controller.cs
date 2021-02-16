using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtocolAttack2Controller : MonoBehaviour
{
    [Header("Framework Controller")]
    public GameObject protocolFramework;
    public ProtocolFrameworkController frameworkControl;

    private LastStepAliceBob lastStepAB;
    private LastStepCarolAlice lastStepCA;
    private LastStepCarolBob lastStepCB;

    enum LastStepAliceBob {
        AliceBobStep1,
        AliceBobStep2,
        AliceBobStep3
    }

    enum LastStepCarolAlice {
        CarolAliceStep1,
        CarolAliceStep2,
        CarolAliceStep3
    }

    enum LastStepCarolBob {
        CarolBobStep1,
        CarolBobStep2,
        CarolBobStep3
    }

    public void RestartProtocol() {
        SendAliceBobStep1();
    }

    public void Intercept() {
    }

    public void SendMessage() {
    }

    public void Continue() {
    }

    public void SelectMessage() {
    }

    private void SendAliceBobStep1() {
        frameworkControl.NewStep();
        if (frameworkControl.aliceBobStep != 0) {
            return;
        }

        CapturedMessage newMessage = new CapturedMessage("AliceBobMessage1", "A");
        frameworkControl.latestMessage = newMessage;
        frameworkControl.lastStepControl.SetMessageArrow("Alice", "Bob", frameworkControl.latestMessage.GetMessage(), "");
        lastStepAB = LastStepAliceBob.AliceBobStep1;
    }
}
