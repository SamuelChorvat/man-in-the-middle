using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class ProtocolAttack3Controller : MonoBehaviour {
    [Header("Framework Controller")]
    public GameObject protocolFramework;
    public ProtocolFrameworkController frameworkControl;

    private int lastStepAB = 0;
    private int lastStepAC = 0;

    private CapturedMessage lastAliceBobMsg = new CapturedMessage("", "", "", "", "");

    private bool intercepted = false;
    private bool abSent = false;

    public void RestartProtocol() {
        lastStepAB = 0;
        lastStepAC = 0;
        intercepted = false;
        abSent = false;
        lastAliceBobMsg = new CapturedMessage("", "", "", "", "");
        SendAliceCarolStep1();
    }

    public void Intercept() {
        intercepted = true;
        if (frameworkControl.latestMessage.message.Equals("{ M }<sub><size=130%>Key(Na,Nb)</size></sub>")) {
            frameworkControl.Success("The fact that the protocol messages do not include any way for the participants to actually check if the other side wants to communicate with them enables this attack.");
            return;
        }
    }

    public void SendMessage() {
        if (abSent && !intercepted) {
            frameworkControl.Fail("Invalid or unexpected message.");
            return;
        }

        intercepted = false;
        abSent = false;

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

        if (!lastAliceBobMsg.messageName.Equals("")) {
            frameworkControl.NewStep();
            frameworkControl.latestMessage = lastAliceBobMsg;
            frameworkControl.lastStepControl.SetMessageArrow("Bob", "Alice", frameworkControl.latestMessage.GetMessage(), "");
            abSent = true;
        }

        intercepted = false;
    }

    public void SelectMessage() {
        InstantiateAliceCarolMessage1Encryption();
    }

    private void AliceReply(CapturedMessage msg) {
        if (msg.from.Equals("Bob") || msg.alias.Equals("Bob")) {
            frameworkControl.Fail("Do not try to impersonate Bob. It is not needed to exploit the vulnerability.");
            return;
        } else if (msg.from.Equals("Carol")) {
            if (lastStepAC == 2 && msg.message.Equals("E<sub>A</sub>( " + GetNonce("Alice") + " , " + GetNonce("Bob") + " )")) {
                frameworkControl.NewStep();
                lastStepAC = 3;
                CapturedMessage newMessage = new CapturedMessage("AliceCarolMessage" + lastStepAB, "E<sub>C</sub>( " + GetNonce("Bob") + " )", "Alice", "Carol", "Carol");
                frameworkControl.latestMessage = newMessage;
                frameworkControl.lastStepControl.SetMessageArrow("Alice", "Carol", frameworkControl.latestMessage.GetMessage(), "Carol");
                return;
            } else if (lastStepAC == 2 && msg.message.Equals("E<sub>A</sub>( " + GetNonce("Alice") + " , " + GetNonce("Carol") + " )")) {
                frameworkControl.NewStep();
                lastStepAC = 3;
                CapturedMessage newMessage = new CapturedMessage("AliceCarolMessage" + lastStepAB, "E<sub>C</sub>( " + GetNonce("Carol") + " )", "Alice", "Carol", "Carol");
                frameworkControl.latestMessage = newMessage;
                frameworkControl.lastStepControl.SetMessageArrow("Alice", "Carol", frameworkControl.latestMessage.GetMessage(), "Carol");
                frameworkControl.Fail("Attack failed because the protocol finished without being exploited.");
                return;
            }
        }

        frameworkControl.Fail("Invalid or unexpected message.");
    }

    private void BobReply(CapturedMessage msg) {
        if (msg.from.Equals("Alice") || msg.alias.Equals("Alice")) {
            if (lastStepAB == 1 && msg.message.Equals("E<sub>B</sub>( " + GetNonce("Alice") + " , A )")) {
                frameworkControl.NewStep();
                lastStepAB = 2;
                CapturedMessage newMessage = new CapturedMessage("AliceBobMessage" + lastStepAB, "E<sub>A</sub>( " + GetNonce("Alice") + " , " + GetNonce("Bob") + " )", "Bob", "Alice", "");
                frameworkControl.latestMessage = newMessage;
                lastAliceBobMsg = newMessage;
                frameworkControl.lastStepControl.SetMessageArrow("Bob", "Alice", frameworkControl.latestMessage.GetMessage(), "");
                return;
            }

            if (lastStepAB == 3 && msg.message.Equals("E<sub>B</sub>( " + GetNonce("Bob") + " )")) {
                frameworkControl.NewStep();
                lastStepAB = 4;
                CapturedMessage newMessage = new CapturedMessage("AliceBobMessage" + lastStepAB, "{ M }<sub><size=130%>Key(Na,Nb)</size></sub>", "Bob", "Alice", "");
                frameworkControl.latestMessage = newMessage;
                lastAliceBobMsg = newMessage;
                frameworkControl.lastStepControl.SetMessageArrow("Bob", "Alice", frameworkControl.latestMessage.GetMessage(), "");
                return;
            }

        } else if (msg.from.Equals("Carol")) {
            frameworkControl.Fail("Do not try to communicate with Bob as Carol. Try impersonating Alice instead.");
            return;
        }

        frameworkControl.Fail("Invalid or unexpected message.");
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

    private void InstantiateAliceCarolMessage1Encryption() {
        if (frameworkControl.sendWindowController.currentlySelectedMessage.message.Contains("E<sub>C</sub>")) {
            GameObject temp = Instantiate(frameworkControl.attack3AliceCarolMessage1Encryption);
            temp.transform.Find("EAButton").GetComponent<Button>().onClick.AddListener(ClickEA);
            temp.transform.Find("EBButton").GetComponent<Button>().onClick.AddListener(ClickEB);
            temp.transform.Find("ECButton").GetComponent<Button>().onClick.AddListener(ClickEC);
            temp.transform.SetParent(frameworkControl.sendWindowController.selectedMessageEditsScrollViewContent.transform, false);
        }
    }

    public void ClickEA() {
        frameworkControl.sendWindowController.SetSelectedMessage(Regex.Replace(frameworkControl.sendWindowController.GetSelectedMessage(), @"\<[a-z]*\>[A-Z]<\/[a-z]*\>", "<sub>A</sub>"));
    }

    public void ClickEB() {
        frameworkControl.sendWindowController.SetSelectedMessage(Regex.Replace(frameworkControl.sendWindowController.GetSelectedMessage(), @"\<[a-z]*\>[A-Z]<\/[a-z]*\>", "<sub>B</sub>"));
    }

    public void ClickEC() {
        frameworkControl.sendWindowController.SetSelectedMessage(Regex.Replace(frameworkControl.sendWindowController.GetSelectedMessage(), @"\<[a-z]*\>[A-Z]<\/[a-z]*\>", "<sub>C</sub>"));
    }
}
