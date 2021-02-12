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
        frameworkControl.NewStep();
        CapturedMessage newMessage = new CapturedMessage("CarolMessage", frameworkControl.toSendMessage);
        frameworkControl.latestMessage = newMessage;
        frameworkControl.lastStepControl.SetMessageArrow(frameworkControl.fromSend, frameworkControl.toSend, frameworkControl.latestMessage.GetMessage(), frameworkControl.carolAlias);

        Match m = Regex.Match(frameworkControl.latestMessage.GetMessage(), @"\d+");
        if (!frameworkControl.toSend.Equals("Alice")) {
            if (intercepted && m.Success && (Int32.Parse(m.Value) <= 5)) {
                frameworkControl.Fail();
            } else {
                frameworkControl.Success();
            }
        } else {
            frameworkControl.Fail();
        }
    }

    public void Capture() {

    }

    public void Continue() {
        switch(lastStep) {
            case LastStep.AliceBobStep1:
                frameworkControl.Fail();
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
