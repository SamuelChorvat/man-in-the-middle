using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class ProtocolAttack4Controller : MonoBehaviour
{
    [Header("Framework Controller")]
    public GameObject protocolFramework;
    public ProtocolFrameworkController frameworkControl;

    private int lastStepAB = 0;
    private int lastStepAC = 0;

    private bool intercepted = false;

    public void RestartProtocol() {
        lastStepAB = 0;
        lastStepAC = 0;
        intercepted = false;
        SendAliceCarolStep1();
    }

    public void Intercept() {
        intercepted = true;
    }

    public void SendMessage() {
        intercepted = false;
        if (frameworkControl.latestMessage.alias.Equals("Alice") || frameworkControl.latestMessage.alias.Equals("Bob")) {
            lastStepAB += 1;
        }

        if (frameworkControl.latestMessage.alias.Equals("Carol") && frameworkControl.latestMessage.to.Equals("Alice")) {
            lastStepAC += 1;
        }

        if (frameworkControl.latestMessage.to.Equals("Alice")) {
            AliceReply(frameworkControl.latestMessage);
        } else if (frameworkControl.latestMessage.to.Equals("Bob")) {
            BobReply(frameworkControl.latestMessage);
        }
    }

    public void Continue() {
        if ((frameworkControl.latestMessage.to.Equals("Alice") || frameworkControl.latestMessage.to.Equals("Bob")) && !intercepted) {
            frameworkControl.Fail("Invalid or unexpected message. Try intercepting the message so that it doesn't reach " + frameworkControl.latestMessage.to + ".");
            return;
        }

        intercepted = false;
    }

    public void SelectMessage() {
        InstantiateAliceCarolMessage2Signature();
    }


    private void AliceReply(CapturedMessage msg) {
        if (msg.from.Equals("Bob") || msg.alias.Equals("Bob")) {
            frameworkControl.Fail("Do not try to impersonate Bob. It is not needed to exploit the vulnerability.");
            return;
        } else if (msg.from.Equals("Carol")) {
            if (lastStepAC == 2 && msg.message.Equals("g<sup>y</sup>, S<sub>C</sub>(g<sup>x</sup>, g<sup>y</sup>)")) {
                frameworkControl.NewStep();
                lastStepAC = 3;
                CapturedMessage newMessage = new CapturedMessage("AliceCarolMessage" + lastStepAB, "{ S<sub>A</sub>(g<sup>x</sup>, g<sup>y</sup>) }<size=120%><sub>g</sub></size><size=50%>xy</size>", "Alice", "Carol", "Carol");
                frameworkControl.latestMessage = newMessage;
                frameworkControl.lastStepControl.SetMessageArrow("Alice", "Carol", frameworkControl.latestMessage.GetMessage(), "Carol");
                return;
            } 
        }

        frameworkControl.Fail("Invalid or unexpected message.");
    }

    private void BobReply(CapturedMessage msg) {
        if (msg.from.Equals("Alice") || msg.alias.Equals("Alice")) {
            if (lastStepAB == 1 && msg.message.Equals("g<sup>x</sup>")) {
                frameworkControl.NewStep();
                lastStepAB = 2;
                CapturedMessage newMessage = new CapturedMessage("AliceBobMessage" + lastStepAB, "g<sup>y</sup>, S<sub>B</sub>(g<sup>x</sup>, g<sup>y</sup>)", "Bob", "Alice", "");
                frameworkControl.latestMessage = newMessage;
                frameworkControl.lastStepControl.SetMessageArrow("Bob", "Alice", frameworkControl.latestMessage.GetMessage(), "");
                return;
            }

            if (lastStepAB == 3 && msg.message.Equals("{ S<sub>A</sub>(g<sup>x</sup>, g<sup>y</sup>) }<size=120%><sub>g</sub></size><size=50%>xy</size>")) {
                frameworkControl.Success("Alice thinks she is talking to Carol but is really talking to Bob.");
                return;
            }

        } else if (msg.from.Equals("Carol")) {
            frameworkControl.Fail("Do not try to communicate with Bob as Carol. Try impersonating Alice instead.");
            return;
        }

        frameworkControl.Fail("Invalid or unexpected message.");
    }

    private void SendAliceCarolStep1() {
        frameworkControl.NewStep();
        lastStepAC = 1;
        CapturedMessage newMessage = new CapturedMessage("AliceCarolMessage" + lastStepAC, "g<sup>x</sup>", "Alice", "Carol", "Carol");
        frameworkControl.latestMessage = newMessage;
        frameworkControl.lastStepControl.SetMessageArrow("Alice", "Carol", frameworkControl.latestMessage.GetMessage(), "Carol");
    }

    private void InstantiateAliceCarolMessage2Signature() {
        if (frameworkControl.sendWindowController.currentlySelectedMessage.message.Contains("S<sub>") && !frameworkControl.sendWindowController.currentlySelectedMessage.message.Contains("<size=120%><sub>g</sub></size><size=50%>xy</size>")) {
            GameObject temp = Instantiate(frameworkControl.attack4AliceCarolMessage2Signature);
            temp.transform.Find("SignButton").GetComponent<Button>().onClick.AddListener(ClickSign);
            temp.transform.SetParent(frameworkControl.sendWindowController.selectedMessageEditsScrollViewContent.transform, false);
        }
    }

    public void ClickSign() {
        frameworkControl.sendWindowController.SetSelectedMessage(Regex.Replace(frameworkControl.sendWindowController.GetSelectedMessage(), @"S\<[a-z]*\>[A-Z]<\/[a-z]*\>", "S<sub>C</sub>"));
    }
}
