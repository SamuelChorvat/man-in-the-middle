using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class ProtocolAttack1Controller: MonoBehaviour
{
    [Header("Framework Controller")]
    public GameObject protocolFramework;
    public ProtocolFrameworkController frameworkControl;

    private LastStep lastStep;
    private CapturedMessage currentlySelectedMessage;

    enum LastStep {
        AliceBobStep1
    }


    public void RestartProtocol() {
        SendAliceBobStep1();
    }
    
    public void Intercept() {
        
    }

    public void Send() {
        
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

    public void SelectMessage(CapturedMessage selectedMessage) {
        switch(selectedMessage.messageName) {
            case "AliceBobMessage1":
                InstantiateAliceBobMessage1Amount();
                currentlySelectedMessage = selectedMessage;
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
        frameworkControl.lastStepControl.SetAliceBobMessageArrow(frameworkControl.latestMessage.GetMessage());
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
        frameworkControl.sendWindowController.SetSelectedMessage(Regex.Replace(currentlySelectedMessage.message, @"\£\d*", "£50"));
    }

    public void ClickAmount500() {
        frameworkControl.sendWindowController.SetSelectedMessage(Regex.Replace(currentlySelectedMessage.message, @"\£\d*", "£500"));
    }

    public void ClickAmount5000() {
        frameworkControl.sendWindowController.SetSelectedMessage(Regex.Replace(currentlySelectedMessage.message, @"\£\d*", "£5000"));
    }

}
