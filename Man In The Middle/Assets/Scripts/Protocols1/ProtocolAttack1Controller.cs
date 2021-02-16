using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using System;

public class ProtocolAttack1Controller: MonoBehaviour
{
    [Header("Framework Controller")]
    public GameObject protocolFramework;
    public ProtocolFrameworkController frameworkControl;

    private LastStep lastStep;
    private bool intercepted = false;

    enum LastStep {
        AliceBobStep1
    }

    public void RestartProtocol() {
        intercepted = false;
        SendAliceBobStep1();
    }
    
    public void Intercept() {
        intercepted = true;
    }

    public void SendMessage() {
        Match m = Regex.Match(frameworkControl.latestMessage.GetMessage(), @"\d+");
        if ((intercepted && m.Success && (Int32.Parse(m.Value) > 5) && frameworkControl.carolAlias.Equals("Alice")) || !intercepted && frameworkControl.carolAlias.Equals("Alice")) {
            frameworkControl.Success("As you can probably tell this protocol has no security properties at all.");

        } else if (intercepted && m.Success && (Int32.Parse(m.Value) <= 5)) {
            frameworkControl.Fail("Attack failed because even though the message was intercepted it was then relayed without changing anything therefore not affecting the protocol in any way. Alice still paid £5 to Bob as she wanted.");
        } else if (frameworkControl.carolAlias.Equals("Carol") && frameworkControl.toSend.Equals("Bob")) {
            frameworkControl.Fail("Attack failed because we just paid Bob £" + m.Value + " and didn't exploit the protocol in any way.");
        } else if (frameworkControl.carolAlias.Equals("Carol") && frameworkControl.toSend.Equals("Alice")) {
            frameworkControl.Success("As you can probably tell this protocol has no security properties at all.");
        } else if (frameworkControl.carolAlias.Equals("Bob") && frameworkControl.toSend.Equals("Alice")) {
            frameworkControl.Success("As you can probably tell this protocol has no security properties at all.");
        }
    }

    public void Capture() {

    }

    public void Continue() {
        switch(lastStep) {
            case LastStep.AliceBobStep1:
                if (intercepted) {
                    frameworkControl.Fail("Attack failed because even though you intercepted the message, you didn't then use it to your advantage in any way. Just intercepting a message does not count as a valid attack because it is assumed that the attacker owns the network. Attacker can intercept all messages but that is more of a nuisance rather than a valid attack.");
                } else {
                    frameworkControl.Fail("Attack failed because the protocol finished as expected without you affecting it in any way.");
                }
                break;
        }
    }

    public void SelectMessage() {
        switch(frameworkControl.sendWindowController.currentlySelectedMessage.messageName) {
            case "AliceBobMessage1":
                InstantiateAliceBobMessage1Amount();
                break;
        }
    }

    private void SendAliceBobStep1() {
        frameworkControl.NewStep();
        if (frameworkControl.aliceBobStep != 0) {
            return;
        }

        CapturedMessage newMessage = new CapturedMessage("AliceBobMessage1" ,"\"Pay Bob £5\"");
        frameworkControl.latestMessage = newMessage;
        frameworkControl.lastStepControl.SetMessageArrow("Alice", "Bob", frameworkControl.latestMessage.GetMessage(), "");
        lastStep = LastStep.AliceBobStep1;
    }

    private void InstantiateAliceBobMessage1Amount() {
        GameObject temp = Instantiate(frameworkControl.attack1AliceBobMessage1Amount);
        temp.transform.Find("50Button").GetComponent<Button>().onClick.AddListener(ClickAmount50);
        temp.transform.Find("500Button").GetComponent<Button>().onClick.AddListener(ClickAmount500);
        temp.transform.Find("5000Button").GetComponent<Button>().onClick.AddListener(ClickAmount5000);
        temp.transform.SetParent(frameworkControl.sendWindowController.selectedMessageEditsScrollViewContent.transform, false);
    }

    public void ClickAmount50() {
        frameworkControl.sendWindowController.SetSelectedMessage(Regex.Replace(frameworkControl.sendWindowController.currentlySelectedMessage.message, @"\£\d+", "£50"));
    }

    public void ClickAmount500() {
        frameworkControl.sendWindowController.SetSelectedMessage(Regex.Replace(frameworkControl.sendWindowController.currentlySelectedMessage.message, @"\£\d+", "£500"));
    }

    public void ClickAmount5000() {
        frameworkControl.sendWindowController.SetSelectedMessage(Regex.Replace(frameworkControl.sendWindowController.currentlySelectedMessage.message, @"\£\d+", "£5000"));
    }
}
