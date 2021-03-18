using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProtocolAttack2Controller : MonoBehaviour
{
    [Header("Framework Controller")]
    public GameObject protocolFramework;
    public ProtocolFrameworkController frameworkControl;

    private int lastStepAB = 0;

    private CapturedMessage secondLastAliceBobMsg = new CapturedMessage("", "", "", "", "");
    private CapturedMessage lastAliceBobMsg = new CapturedMessage("","","","","");

    private int nonceCounter = 0;
    private int lastABNonce = 0;
    private bool aliceStartedSecondRun = false;

    private string aliceBobNonce1 = "";
    private string aliceBobNonce2 = "";

    public void RestartProtocol() {
        lastStepAB = 0;
        nonceCounter = 0;
        lastAliceBobMsg = new CapturedMessage("", "", "", "", "");
        aliceStartedSecondRun = false;
        secondLastAliceBobMsg = new CapturedMessage("", "", "", "", "");
        aliceBobNonce1 = "";
        aliceBobNonce2 = "";
        SendAliceBobStep1();
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
        if (frameworkControl.latestMessage.alias.Equals("Alice") || frameworkControl.latestMessage.alias.Equals("Bob")) {
            lastStepAB += 1;
        }

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
            case ("AliceBobMessage3"):
                InstantiateAliceBobMessage3Nonce();
                InstantiateAliceBobMessage6Message();
                break;
            case ("AliceBobMessage4"):
                InstantiateAliceBobMessage1Letter();
                break;
            case ("AliceBobMessage6"):
                InstantiateAliceBobMessage3Nonce();
                InstantiateAliceBobMessage6Message();
                break;
        }
    }

    private void AliceReply(CapturedMessage msg) {
        if (msg.from.Equals("Bob") || msg.alias.Equals("Bob")) { 
            if (msg.message.Equals("C") || msg.message.Equals("A")) {
                frameworkControl.Fail("Invalid message.");
                return;
            }

            if (msg.message.Equals("B")) {
                frameworkControl.Fail("Unexpected message.");
                return;
            }

            if (lastStepAB == 2) {
                Match m = Regex.Match(msg.GetMessage(), @"\>\d+");
                string toSend = Regex.Replace("{ N<sub><size=110%>1</size></sub> + 1 }<sub><size=130%>Kab</size></sub> , { Pay Carol £5 }<sub><size=130%>Kab</size>", @"\>\d+", m.Value);
                aliceBobNonce1 = m.Value;
                frameworkControl.NewStep();
                lastStepAB += 1;
                CapturedMessage newMessage = new CapturedMessage("AliceBobMessage" + lastStepAB, toSend, "Alice", "Bob", "");
                SetMessages(newMessage);
                frameworkControl.lastStepControl.SetMessageArrow("Alice", "Bob", frameworkControl.latestMessage.GetMessage(), "");
                return;
            } else if (lastStepAB == 5) {
                Match m = Regex.Match(msg.GetMessage(), @"\>\d+");
                string toSend = Regex.Replace("{ N<sub><size=110%>2</size></sub> + 1 }<sub><size=130%>Kab</size></sub> , { Pay Bob £5 }<sub><size=130%>Kab</size>", @"\>\d+", m.Value);
                aliceBobNonce2 = m.Value;
                frameworkControl.NewStep();
                lastStepAB += 1;
                CapturedMessage newMessage = new CapturedMessage("AliceBobMessage" + lastStepAB, toSend, "Alice", "Bob", "");
                SetMessages(newMessage);
                frameworkControl.lastStepControl.SetMessageArrow("Alice", "Bob", frameworkControl.latestMessage.GetMessage(), "");
                return;
            } 
        } else if (msg.from.Equals("Carol")) {
            if (msg.message.Equals("A")) {
                frameworkControl.Fail("Invalid message.");
                return;
            } else if (msg.message.Equals("C")) {
                frameworkControl.Fail("Starting a new conversation is not needed to exploit this protocol.");
                return;
            } else {
                frameworkControl.Fail("Invalid or unexpected message.");
                return;
            }
        }

        frameworkControl.Fail("Invalid or unexpected message.");
    }

    private void BobReply(CapturedMessage msg) {
        if(msg.from.Equals("Alice") || msg.alias.Equals("Alice")) {
            if (msg.message.Equals("C")) {
                frameworkControl.Fail("Invalid message.");
                return;
            }

            if ((msg.message.Equals("A") && (lastStepAB != 1) && lastStepAB != 4)) {
                frameworkControl.Fail("Unexpected message.");
                return;
            }

            if (lastStepAB == 6) {
                Match m = Regex.Match(msg.GetMessage(), @"\>\d+");
                int nonceReceived = Int32.Parse(m.Value.Substring(1));
                if (nonceReceived != lastABNonce) {
                    frameworkControl.Fail("Unexpected nonce. Expected N<sub><size=110%>" + lastABNonce + "</size></sub> instead received N<sub><size=110%>" + nonceReceived+ "</size></sub> .");
                    return;
                }

                m = Regex.Match(msg.GetMessage(), @"Pay\sCarol");
                if (m.Success) {
                    frameworkControl.Success("Even though you are not able to change the text itself because of the pre-shared symmetric key encryption, you can still exploit this protocol because of the fact that the nonce is encrypted separately instead of encrypting it together with the message. This allows us to re-use all the previously encrypted messages without the recipient realising it.");
                    return;
                } else {
                    frameworkControl.Fail("Attack failed because the protocol finished without being exploited.");
                    return;
                }
            }

            if ((lastStepAB == 1 || lastStepAB == 4) && msg.message.Equals("A")) {
                SendNonce("Bob", "Alice", msg);
                if (lastStepAB == (4 + 1) && !aliceStartedSecondRun) {
                    frameworkControl.Fail("Unexpected message.");
                }
                return;
            }

            if (lastStepAB == 3) {
                Match m = Regex.Match(msg.GetMessage(), @"\>\d+");
                int nonceReceived = Int32.Parse(m.Value.Substring(1));
                if (nonceReceived != lastABNonce) {
                    frameworkControl.Fail("Unexpected nonce. Expected N<sub><size=110%>" + lastABNonce + "</size></sub> instead received N<sub><size=110%>" + nonceReceived + "</size></sub> .");
                    return;
                } else {
                    SendAliceBobStep4();
                    return;
                }
                
            }

        } else if (msg.from.Equals("Carol")) {
            if (msg.message.Equals("C")) {
                frameworkControl.Fail("Starting a new conversation is not needed to exploit this protocol.");
                return;
            } else {
                frameworkControl.Fail("Invalid or unexpected message.");
                return;
            }
        }

        frameworkControl.Fail("Invalid or unexpected message.");
    }

    private void SendNonce(string from, string to, CapturedMessage msg) {
        lastStepAB += 1;
        frameworkControl.NewStep();
        if(!msg.alias.Equals("")) {
            msg.from = msg.alias;
        }
        string nonce = GenerateNonce();
        lastABNonce = nonceCounter;
        CapturedMessage newMessage = new CapturedMessage("NonceMessage" + nonceCounter, "{ " + nonce + " }<sub><size=130%>Kab</sub>", from, to, "");
        SetMessages(newMessage);
        frameworkControl.lastStepControl.SetMessageArrow(from, to, frameworkControl.latestMessage.GetMessage(), "");
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
        aliceStartedSecondRun = true;
    }

    private void InstantiateAliceBobMessage1Letter() {
        GameObject temp = Instantiate(frameworkControl.attack2AliceBobMessage1Letter);
        temp.transform.Find("AButton").GetComponent<Button>().onClick.AddListener(ClickA);
        temp.transform.Find("BButton").GetComponent<Button>().onClick.AddListener(ClickB);
        temp.transform.Find("CButton").GetComponent<Button>().onClick.AddListener(ClickC);
        temp.transform.SetParent(frameworkControl.sendWindowController.selectedMessageEditsScrollViewContent.transform, false);
    }

    private void InstantiateAliceBobMessage6Message() {
        if (aliceBobNonce2 != "") {
            GameObject temp = Instantiate(frameworkControl.attack2AliceBobMessage6Message);
            temp.transform.Find("CarolButton").GetComponent<Button>().onClick.AddListener(ClickCarol);
            temp.transform.Find("BobButton").GetComponent<Button>().onClick.AddListener(ClickBob);
            temp.transform.SetParent(frameworkControl.sendWindowController.selectedMessageEditsScrollViewContent.transform, false);
        }
    }

    private void InstantiateAliceBobMessage3Nonce() {
        if (aliceBobNonce2 != "") {
            GameObject temp = Instantiate(frameworkControl.attack2AliceBobMessage3Nonce);
            temp.transform.Find("Nonce1Button").Find("ButtonText").GetComponent<TextMeshProUGUI>().text = "{ N<sub><size=110%" + aliceBobNonce1 + "</size></sub> + 1 }<sub><size=130%>Kab</size></sub>";
            temp.transform.Find("Nonce2Button").Find("ButtonText").GetComponent<TextMeshProUGUI>().text = "{ N<sub><size=110%" + aliceBobNonce2 + "</size></sub> + 1 }<sub><size=130%>Kab</size></sub>";
            temp.transform.Find("Nonce1Button").GetComponent<Button>().onClick.AddListener(ClickNonce1);
            temp.transform.Find("Nonce2Button").GetComponent<Button>().onClick.AddListener(ClickNonce2);
            temp.transform.SetParent(frameworkControl.sendWindowController.selectedMessageEditsScrollViewContent.transform, false);
        }
    }

    public void ClickA() {
        frameworkControl.sendWindowController.SetSelectedMessage(Regex.Replace(frameworkControl.sendWindowController.GetSelectedMessage(), @"[ABC]", "A"));
    }

    public void ClickB() {
        frameworkControl.sendWindowController.SetSelectedMessage(Regex.Replace(frameworkControl.sendWindowController.GetSelectedMessage(), @"[ABC]", "B"));
    }

    public void ClickC() {
        frameworkControl.sendWindowController.SetSelectedMessage(Regex.Replace(frameworkControl.sendWindowController.GetSelectedMessage(), @"[ABC]", "C"));
    }

    public void ClickCarol() {
        frameworkControl.sendWindowController.SetSelectedMessage(Regex.Replace(frameworkControl.sendWindowController.GetSelectedMessage(), @"Bob", "Carol"));
    }

    public void ClickBob() {
        frameworkControl.sendWindowController.SetSelectedMessage(Regex.Replace(frameworkControl.sendWindowController.GetSelectedMessage(), @"Carol", "Bob"));
    }

    public void ClickNonce1() {
        frameworkControl.sendWindowController.SetSelectedMessage(Regex.Replace(frameworkControl.sendWindowController.GetSelectedMessage(), @"\>\d+", aliceBobNonce1));
    }

    public void ClickNonce2() {
        frameworkControl.sendWindowController.SetSelectedMessage(Regex.Replace(frameworkControl.sendWindowController.GetSelectedMessage(), @"\>\d+", aliceBobNonce2));
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
