using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;

public class ProtocolAttack2Controller : MonoBehaviour
{
    [Header("Framework Controller")]
    public GameObject protocolFramework;
    public ProtocolFrameworkController frameworkControl;

    private int lastStepAB = 0;
    private int lastStepCA = 0;
    private int lastStepCB = 0;

    private CapturedMessage secondLastAliceBobMsg = new CapturedMessage("", "", "", "", "");
    private CapturedMessage lastAliceBobMsg = new CapturedMessage("","","","","");

    private CapturedMessage lastCarolAliceMsg;
    private CapturedMessage lastCarolBobMsg;

    private int nonceCounter = 0;

    public void RestartProtocol() {
        lastStepAB = 0;
        lastStepCA = 0;
        lastStepCB = 0;
        nonceCounter = 0;
        lastAliceBobMsg = new CapturedMessage("", "", "", "", "");
        secondLastAliceBobMsg = new CapturedMessage("", "", "", "", "");
        SendAliceBobStep1();
    }

    public void Intercept() {
        if (lastStepAB > 0) {
            lastStepAB -= 1; 
        }

        lastAliceBobMsg = secondLastAliceBobMsg;
    }

    public void SendMessage() {
        if (frameworkControl.latestMessage.to.Equals("Alice")) {
            AliceReply(frameworkControl.latestMessage);
        } else if (frameworkControl.latestMessage.to.Equals("Bob")) {
            BobReply(frameworkControl.latestMessage);
        }
    }

    public void Continue() {
        if(lastStepAB == 0) {
            SendAliceBobStep1();
        } else if (lastStepAB == 3) {
            SendAliceBobStep4();
        } else if (lastAliceBobMsg.to.Equals("Alice")) {
            AliceReply(lastAliceBobMsg);
        } else if (lastAliceBobMsg.to.Equals("Bob")) {
            BobReply(lastAliceBobMsg);
        }
    }

    public void SelectMessage() {
        switch (frameworkControl.sendWindowController.currentlySelectedMessage.messageName) {
            case ("AliceBobMessage1"):
                InstantiateAliceBobMessage1Letter();
                break;
            case ("AliceBobMessage4"):
                InstantiateAliceBobMessage1Letter();
                break;
        }
    }

    private void AliceReply(CapturedMessage msg) {
        if (msg.from.Equals("Bob")) {
            if(lastStepAB == 2) {
                Match m = Regex.Match(msg.GetMessage(), @"\>\d+");
                string toSend = Regex.Replace("{ N<sub><size=110%>1</size></sub> + 1 }<sub><size=130%>Kab</size></sub> , { Pay Carol £5 }<sub><size=130%>Kab</size>", @"\>\d+", m.Value);
                frameworkControl.NewStep();
                lastStepAB += 1;
                CapturedMessage newMessage = new CapturedMessage("AliceBobMessage" + lastStepAB, toSend, "Alice", "Bob", "");
                SetMessages(newMessage);
                frameworkControl.lastStepControl.SetMessageArrow("Alice", "Bob", frameworkControl.latestMessage.GetMessage(), "");
            } else if (lastStepAB == 5) {
                Match m = Regex.Match(msg.GetMessage(), @"\>\d+");
                string toSend = Regex.Replace("{ N<sub><size=110%>2</size></sub> + 1 }<sub><size=130%>Kab</size></sub> , { Pay Bob £5 }<sub><size=130%>Kab</size>", @"\>\d+", m.Value);
                frameworkControl.NewStep();
                lastStepAB += 1;
                CapturedMessage newMessage = new CapturedMessage("AliceBobMessage" + lastStepAB, toSend, "Alice", "Bob", "");
                SetMessages(newMessage);
                frameworkControl.lastStepControl.SetMessageArrow("Alice", "Bob", frameworkControl.latestMessage.GetMessage(), "");
            } 
        } else if (msg.from.Equals("Carol")) {
            if (msg.message.Equals("A")) {
                frameworkControl.Fail("Invalid message.");
            } else if(msg.alias.Equals("Bob")) {
                if (msg.message.Equals("C")) {
                    frameworkControl.Fail("Invalid message.");
                    return;
                }

                if (msg.message.Equals("B")) {
                    frameworkControl.Fail("Unexpected message.");
                    return;
                }

            } else if (msg.alias.Equals("Carol")) {
                if (msg.message.Equals("B")) {
                    frameworkControl.Fail("Invalid message.");
                    return;
                }
            }
        }
    }

    private void BobReply(CapturedMessage msg) {
        if(msg.from.Equals("Alice")) {
            if (lastStepAB == 6) {
                frameworkControl.Fail("Attack failed because the protocol finished without being exploited.");
                return;
            }
            lastStepAB += 1;
            frameworkControl.NewStep();
            CapturedMessage newMessage = new CapturedMessage("AliceBobMessage" + lastStepAB, "{ " + GenerateNonce() + " }<sub><size=130%>Kab</sub>", "Bob", "Alice", "");
            SetMessages(newMessage);
            frameworkControl.lastStepControl.SetMessageArrow("Bob", "Alice", frameworkControl.latestMessage.GetMessage(), "");
        } else if (msg.from.Equals("Carol")) {
            if (msg.message.Equals("B")) {
                frameworkControl.Fail("Invalid message.");
            } else if (msg.alias.Equals("Alice")) {
                if (msg.message.Equals("C")) {
                    frameworkControl.Fail("Invalid message.");
                    return;
                }

                if (msg.message.Equals("A")) {
                    if(lastAliceBobMsg.message.Equals("A")) {
                        frameworkControl.Fail("Unexpected message.");
                        return;
                    } else {
                        if (lastStepAB == 0 || lastStepAB == 3) {
                            lastStepAB += 2;
                            frameworkControl.NewStep();
                            CapturedMessage newMessage = new CapturedMessage("AliceBobMessage" + lastStepAB, "{ " + GenerateNonce() + " }<sub><size=130%>Kab</sub>", "Bob", "Alice", "");
                            SetMessages(newMessage);
                            frameworkControl.lastStepControl.SetMessageArrow("Bob", "Alice", frameworkControl.latestMessage.GetMessage(), "");
                        } else {
                            frameworkControl.Fail("Unexpected message.");
                            return;
                        }
                    }
                }

            } else if (msg.alias.Equals("Carol")) {
                if (msg.message.Equals("A")) {
                    frameworkControl.Fail("Invalid message.");
                    return;
                }
            }
        }
    }

    private void SendAliceBobStep1() {
        frameworkControl.NewStep();
        lastStepAB = 1;
        CapturedMessage newMessage = new CapturedMessage("AliceBobMessage" + lastStepAB, "A", "Alice", "Bob", "");
        SetMessages(newMessage);
        frameworkControl.lastStepControl.SetMessageArrow("Alice", "Bob", frameworkControl.latestMessage.GetMessage(), "");
    }

    private void SendAliceBobStep4() {
        frameworkControl.NewStep();
        lastStepAB = 4;
        CapturedMessage newMessage = new CapturedMessage("AliceBobMessage" + lastStepAB, "A", "Alice", "Bob", "");
        SetMessages(newMessage);
        frameworkControl.lastStepControl.SetMessageArrow("Alice", "Bob", frameworkControl.latestMessage.GetMessage(), "");
    }

    private void InstantiateAliceBobMessage1Letter() {
        GameObject temp = Instantiate(frameworkControl.attack2AliceBobMessage1Letter);
        temp.transform.Find("AButton").GetComponent<Button>().onClick.AddListener(ClickA);
        temp.transform.Find("BButton").GetComponent<Button>().onClick.AddListener(ClickB);
        temp.transform.Find("CButton").GetComponent<Button>().onClick.AddListener(ClickC);
        temp.transform.SetParent(frameworkControl.sendWindowController.selectedMessageEditsScrollViewContent.transform, false);
    }

    public void ClickA() {
        frameworkControl.sendWindowController.SetSelectedMessage(Regex.Replace(frameworkControl.sendWindowController.currentlySelectedMessage.message, @"[ABC]", "A"));
    }

    public void ClickB() {
        frameworkControl.sendWindowController.SetSelectedMessage(Regex.Replace(frameworkControl.sendWindowController.currentlySelectedMessage.message, @"[ABC]", "B"));
    }

    public void ClickC() {
        frameworkControl.sendWindowController.SetSelectedMessage(Regex.Replace(frameworkControl.sendWindowController.currentlySelectedMessage.message, @"[ABC]", "C"));
    }

    private string GenerateNonce() {
        nonceCounter += 1;
        return "N<sub><size=110%>" + nonceCounter + "</size></sub>";
    }

    private void SetMessages(CapturedMessage msg) {
        this.secondLastAliceBobMsg = lastAliceBobMsg;
        lastAliceBobMsg = msg;
        frameworkControl.latestMessage = msg;
    }
}
