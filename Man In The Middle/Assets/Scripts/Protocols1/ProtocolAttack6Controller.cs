using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class ProtocolAttack6Controller : MonoBehaviour
{
    [Header("Framework Controller")]
    public GameObject protocolFramework;
    public ProtocolFrameworkController frameworkControl;

    private int lastStepAB = 0;

    public void RestartProtocol() {
        lastStepAB = 0;
        SendAliceBobStep1();
        frameworkControl.AddCapturedMessage(new CapturedMessage("CarolBobMessage1", "E<sub>B</sub>( LoginCarol , PasswordCarol )", "Carol", "Bob", "Carol"));
    }

    public void Intercept() {
        if (lastStepAB > 0) {
            lastStepAB -= 1;
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
        } else if (lastStepAB == 1) {
            SendAliceBobStep2();
        } else if (lastStepAB == 2) {
            frameworkControl.Fail("Attack failed because the protocol finished without being exploited.");
            return;
        }
    }

    public void SelectMessage() {
        InstantiateAliceCarolMessage1Encryption();
    }

    private void AliceReply(CapturedMessage msg) {
        if (msg.from.Equals("Bob") || msg.alias.Equals("Bob")) {
            if (msg.message.Equals("E<sub>A</sub>( K<sub>AB</sub> )") && lastStepAB == 2) {
                frameworkControl.Fail("Attack failed because the protocol finished without being exploited.");
                return;
            }

            if (msg.message.Equals("E<sub>A</sub>( K<sub>CB</sub> )") && lastStepAB == 2) {
                frameworkControl.Success("You are now able to decrypt messages that Alice encrypts using the symmetric key.");
                return;
            }

        } else if (msg.from.Equals("Carol")) {
            frameworkControl.Fail("Do not try to communicate with Alice as Carol. Try impersonating Bob's store instead.");
            return;
        }

        frameworkControl.Fail("Invalid or unexpected message.");
    }

    private void BobReply(CapturedMessage msg) {
        if (msg.from.Equals("Alice") || msg.alias.Equals("Alice")) {
            if (msg.message.Equals("E<sub>B</sub>( LoginAlice , PasswordAlice )") && lastStepAB == 1) {
                frameworkControl.NewStep();
                lastStepAB += 1;
                CapturedMessage newMessage = new CapturedMessage("AliceBobMessage" + lastStepAB, "E<sub>A</sub>( K<sub>AB</sub> )", "Bob", "Alice", "");
                frameworkControl.latestMessage = newMessage;
                frameworkControl.lastStepControl.SetMessageArrow("Bob", "Alice", frameworkControl.latestMessage.GetMessage(), "");
                return;
            }

        } else if (msg.from.Equals("Carol")) {
            if (msg.message.Equals("E<sub>B</sub>( LoginCarol , PasswordCarol )")) {
                frameworkControl.NewStep();
                CapturedMessage newMessage = new CapturedMessage("BobCarolMessage2", "E<sub>C</sub>( K<sub>CB</sub> )", "Bob", "Carol", "Carol");
                frameworkControl.latestMessage = newMessage;
                frameworkControl.lastStepControl.SetMessageArrow("Bob", "Carol", frameworkControl.latestMessage.GetMessage(), "Carol");
                return;
            }
        } 

        frameworkControl.Fail("Invalid or unexpected message.");
    }

    private void SendAliceBobStep1() {
        frameworkControl.NewStep();
        lastStepAB = 1;
        CapturedMessage newMessage = new CapturedMessage("AliceBobMessage" + lastStepAB, "E<sub>B</sub>( LoginAlice , PasswordAlice )", "Alice", "Bob", "");
        frameworkControl.latestMessage = newMessage;
        frameworkControl.lastStepControl.SetMessageArrow("Alice", "Bob", frameworkControl.latestMessage.GetMessage(), "");
    }

    private void SendAliceBobStep2() {
        frameworkControl.NewStep();
        lastStepAB = 2;
        CapturedMessage newMessage = new CapturedMessage("AliceBobMessage" + lastStepAB, "E<sub>A</sub>( K<sub>AB</sub> )", "Bob", "Alice", "");
        frameworkControl.latestMessage = newMessage;
        frameworkControl.lastStepControl.SetMessageArrow("Bob", "Alice", frameworkControl.latestMessage.GetMessage(), "");
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
