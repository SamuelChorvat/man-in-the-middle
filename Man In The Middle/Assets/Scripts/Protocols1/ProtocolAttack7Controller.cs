using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtocolAttack7Controller : MonoBehaviour {

    [Header("Framework Controller")]
    public GameObject protocolFramework;
    public ProtocolFrameworkController frameworkControl;

    public int lastStepAB = 0;

    private CapturedMessage secondLastAliceBobMsg = new CapturedMessage("", "", "", "", "");
    public CapturedMessage lastAliceBobMsg = new CapturedMessage("", "", "", "", "");

    private bool gzReceived = false;

    public void RestartProtocol() {
        lastAliceBobMsg = new CapturedMessage("", "", "", "", "");
        secondLastAliceBobMsg = new CapturedMessage("", "", "", "", "");
        lastStepAB = 0;
        gzReceived = false;
        SendAliceBobStep1();
        frameworkControl.AddCapturedMessage(new CapturedMessage("CarolBobMessage1", "g<sup>z</sup>", "Carol", "Bob", "Carol"));
    }

    public void Intercept() {
        if ((frameworkControl.latestMessage.from.Equals("Bob") || frameworkControl.latestMessage.from.Equals("Alice")) && (frameworkControl.latestMessage.to.Equals("Bob") || frameworkControl.latestMessage.to.Equals("Alice"))) {
            if (lastStepAB > 0) {
                lastStepAB -= 1;
            }

            lastAliceBobMsg = secondLastAliceBobMsg;
        }
    }

    public void SendMessage() {
        if (!frameworkControl.latestMessage.alias.Equals("Carol")) {
            lastStepAB += 1;
        }

        if (frameworkControl.latestMessage.to.Equals("Alice")) {
            AliceReply(frameworkControl.latestMessage);
        } else if (frameworkControl.latestMessage.to.Equals("Bob")) {
            BobReply(frameworkControl.latestMessage);
        }
    }

    public void Continue() {
        if (lastStepAB == 0) {
            SendAliceBobStep1();
        } else if (lastAliceBobMsg.to.Equals("Alice")) {
            AliceReply(lastAliceBobMsg);
        } else if (lastAliceBobMsg.to.Equals("Bob")) {
            BobReply(lastAliceBobMsg);
        }
    }

    public void SelectMessage() {

    }

    private void AliceReply(CapturedMessage msg) {
        if (msg.from.Equals("Bob") || msg.alias.Equals("Bob")) {
            if ((msg.message.Equals("g<sup>y</sup>") || msg.message.Equals("g<sup>z</sup>")) && lastStepAB == 2) {
                frameworkControl.NewStep();
                lastStepAB += 1;
                CapturedMessage newMessage = new CapturedMessage("AliceBobMessage" + lastStepAB, "S<sub>A</sub>( " + msg.message + " )", "Alice", "Bob", "");
                SetMessages(newMessage);
                frameworkControl.lastStepControl.SetMessageArrow("Alice", "Bob", frameworkControl.latestMessage.GetMessage(), "");
                return;
            }
        } else if (msg.from.Equals("Carol")) {
            frameworkControl.Fail("Do not try to communicate with Alice as Carol. Try impersonating Bob instead.");
            return;
        }

        frameworkControl.Fail("Invalid or unexpected message.");
    }

    private void BobReply(CapturedMessage msg) {
        if (msg.from.Equals("Alice") || msg.alias.Equals("Alice")) {
            if (msg.message.Equals("g<sup>x</sup>") && lastStepAB == 1) {
                frameworkControl.NewStep();
                lastStepAB += 1;
                CapturedMessage newMessage = new CapturedMessage("AliceBobMessage" + lastStepAB, "g<sup>y</sup>", "Bob", "Alice", "");
                SetMessages(newMessage);
                frameworkControl.lastStepControl.SetMessageArrow("Bob", "Alice", frameworkControl.latestMessage.GetMessage(), "");
                return;
            }

            if (msg.message.Equals("g<sup>z</sup>") && lastStepAB == 1) {
                frameworkControl.NewStep();
                lastStepAB += 1;
                CapturedMessage newMessage = new CapturedMessage("AliceBobMessage" + lastStepAB, "g<sup>y</sup>", "Bob", "Alice", "");
                SetMessages(newMessage);
                frameworkControl.lastStepControl.SetMessageArrow("Bob", "Alice", frameworkControl.latestMessage.GetMessage(), "");
                gzReceived = true;
                return;
            }

            if (msg.message.Equals("S<sub>A</sub>( g<sup>y</sup> )") && lastStepAB == 3 && !gzReceived) {
                frameworkControl.NewStep();
                lastStepAB += 1;
                CapturedMessage newMessage = new CapturedMessage("AliceBobMessage" + lastStepAB, "S<sub>B</sub>( g<sup>x</sup> ) , { M }<size=120%><sub>g</sub></size><size=50%>xy</size>", "Bob", "Alice", "");
                SetMessages(newMessage);
                frameworkControl.lastStepControl.SetMessageArrow("Bob", "Alice", frameworkControl.latestMessage.GetMessage(), "");
                frameworkControl.Fail("Attack failed because the protocol finished without being exploited.");
                return;
            }

            if (msg.message.Equals("S<sub>A</sub>( g<sup>y</sup> )") && lastStepAB == 3 && gzReceived) {
                frameworkControl.NewStep();
                lastStepAB += 1;
                CapturedMessage newMessage = new CapturedMessage("AliceBobMessage" + lastStepAB, "S<sub>B</sub>( g<sup>z</sup> ) , { M }<size=120%><sub>g</sub></size><size=50%>zy</size>", "Bob", "Alice", "");
                SetMessages(newMessage);
                frameworkControl.lastStepControl.SetMessageArrow("Bob", "Alice", frameworkControl.latestMessage.GetMessage(), "");
                frameworkControl.Success("You are now able to decrypt the message sent by Bob.");
                return;
            }

        } else if (msg.from.Equals("Carol")) {
            frameworkControl.Fail("Do not try to communicate with Bob as Carol. Try impersonating Alice instead.");
            return;
        }

        frameworkControl.Fail("Invalid or unexpected message.");
    }

    private void SendAliceBobStep1() {
        frameworkControl.NewStep();
        lastStepAB = 1;
        CapturedMessage newMessage = new CapturedMessage("AliceBobMessage" + lastStepAB, "g<sup>x</sup>", "Alice", "Bob", "");
        SetMessages(newMessage);
        frameworkControl.lastStepControl.SetMessageArrow("Alice", "Bob", frameworkControl.latestMessage.GetMessage(), "");
    }

    private void SetMessages(CapturedMessage msg) {
        this.secondLastAliceBobMsg = lastAliceBobMsg;
        lastAliceBobMsg = msg;
        frameworkControl.latestMessage = msg;
    }
}
