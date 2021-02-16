using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text.RegularExpressions;

public class ProtocolFrameworkController : MonoBehaviour
{
    [Header("Protocol Attack")]
    public GameObject attackRef;
    public int attackNo;

    [Header("Continue Button")]
    public RevealContinueButton contBut;

    [Header("Prefab Refs")]
    public GameObject protocolStepPrefab;
    public GameObject captureInterceptSendPrefab;
    public GameObject continueRestartPrefab;
    public GameObject restartOnlyPrefab;
    public GameObject successPrefab;
    public GameObject failPrefab;
    public GameObject spacePrefab;
    public GameObject endMessagePrefab;

    [Header("Message Edit Prefabs Attack 1")]
    public GameObject attack1AliceBobMessage1Amount;

    [Header("Scroll View Content")]
    public GameObject scrollViewContentObject;

    [Header("Send Window")]
    public GameObject sendWindow;
    public SendWindowController sendWindowController;

    [HideInInspector]
    public ProtocolStepController lastStepControl = null;

    //References
    private GameObject lastStepRef = null;
    private GameObject captureInterceptSendRef = null;
    private GameObject continueRestartRef = null;
    private GameObject restartOnlyRef = null;

    public CapturedMessage latestMessage = null;
    public int aliceBobStep = 0;
    public int aliceCarolStep = 0;
    public int bobCarolStep = 0;

    public string toSend = "";
    public string fromSend = "";
    public string carolAlias = "";
    public string toSendMessage = "";

    private GameObject InstantiateProtocolStep() {
        GameObject protocolStep = Instantiate(protocolStepPrefab);
        protocolStep.transform.SetParent(scrollViewContentObject.transform,false);
        lastStepRef = protocolStep;
        lastStepControl = protocolStep.GetComponent<ProtocolStepController>();
        lastStepControl.ResetProtocolStep();
        return protocolStep;
    }

    private GameObject InstantiateCaptureInterceptSend() {
        GameObject captureInterceptSend = Instantiate(captureInterceptSendPrefab);
        captureInterceptSend.transform.SetParent(scrollViewContentObject.transform, false);
        captureInterceptSendRef = captureInterceptSend;
        captureInterceptSendRef.transform.Find("CaptureButton").GetComponent<Button>().onClick.AddListener(Capture);
        captureInterceptSendRef.transform.Find("InterceptButton").GetComponent<Button>().onClick.AddListener(Intercept);
        captureInterceptSendRef.transform.Find("SendButton").GetComponent<Button>().onClick.AddListener(SendWindow);
        return captureInterceptSend;
    }

    private GameObject InstantiateContinueRestart() {
        GameObject continueRestart = Instantiate(continueRestartPrefab);
        continueRestart.transform.SetParent(scrollViewContentObject.transform, false);
        continueRestartRef = continueRestart;
        continueRestartRef.transform.Find("ContinueButton").GetComponent<Button>().onClick.AddListener(Continue);
        continueRestartRef.transform.Find("RestartButton").GetComponent<Button>().onClick.AddListener(RestartProtocol);
        return continueRestart;
    }

    private GameObject InstantiateRestartOnly() {
        GameObject restartOnly = Instantiate(restartOnlyPrefab);
        restartOnly.transform.SetParent(scrollViewContentObject.transform, false);
        restartOnlyRef = restartOnly;
        restartOnlyRef.transform.Find("RestartButton").GetComponent<Button>().onClick.AddListener(RestartProtocol);
        return restartOnly;
    }

    private GameObject InstantiateSuccess() {
        GameObject success = Instantiate(successPrefab);
        success.transform.SetParent(scrollViewContentObject.transform, false);
        return success;
    }

    private GameObject InstantiateFail() {
        GameObject fail = Instantiate(failPrefab);
        fail.transform.SetParent(scrollViewContentObject.transform, false);
        return fail;
    }

    public GameObject InstantiateSpace() {
        GameObject space = Instantiate(spacePrefab);
        space.transform.SetParent(scrollViewContentObject.transform, false);
        return space;
    }

    public GameObject InstantiateEndMessage(string msg) {
        GameObject endMessage = Instantiate(endMessagePrefab);
        endMessage.GetComponent<TextMeshProUGUI>().text = msg;
        endMessage.transform.SetParent(scrollViewContentObject.transform, false);
        return endMessage;
    }

    public void RemoveAll() {
        lastStepRef = null;
        captureInterceptSendRef = null;
        continueRestartRef = null;
        restartOnlyRef = null;

        latestMessage = null;
        aliceBobStep = 0;
        aliceCarolStep = 0;
        bobCarolStep = 0;
        
        foreach (Transform child in scrollViewContentObject.transform) {
            Destroy(child.gameObject);
        }
    }

    private void PrepareForNewStep() {
        Destroy(captureInterceptSendRef);
        Destroy(continueRestartRef);
        Destroy(restartOnlyRef);
        captureInterceptSendRef = null;
        continueRestartRef = null;
        restartOnlyRef = null;
    }

    public void NewStep() {
        PrepareForNewStep();
        InstantiateProtocolStep();
        InstantiateCaptureInterceptSend();
        InstantiateContinueRestart();
    }

    public void Fail(string msg) {
        PrepareForNewStep();
        InstantiateFail();
        InstantiateEndMessage(msg);
        InstantiateRestartOnly();
        InstantiateSpace();
    }

    public void Success(string msg) {
        PrepareForNewStep();
        InstantiateSuccess();
        InstantiateEndMessage(msg);
        contBut.StartReveal();
    }

    public void SetInteractableInterceptButton(bool interactable) {
        captureInterceptSendRef.transform.Find("InterceptButton").GetComponent<Button>().interactable = interactable;
    }

    public void SetInteractableCaptureButton(bool interactable) {
        captureInterceptSendRef.transform.Find("CaptureButton").GetComponent<Button>().interactable = interactable;
    }

    public void Intercept() {
        lastStepControl.Intercept();
        SetInteractableInterceptButton(false);

        if (attackNo == 1) {
            attackRef.GetComponent<ProtocolAttack1Controller>().Intercept();
        }
    }

    public void SendWindow() {
        sendWindowController.ShowWindow();
        sendWindowController.ResetView();
        sendWindowController.sendButton.GetComponent<Button>().interactable = false;

        toSend = "";
        fromSend = "";
        carolAlias = "";
        toSendMessage = "";

        if (sendWindowController.capturedMessages.Count == 0) {
            sendWindowController.noMessages.SetActive(true);
        } else {
            sendWindowController.messageView.SetActive(true);
        }
    }

    public void Capture() {
        SetInteractableCaptureButton(false);
        sendWindowController.capturedMessages.Add(latestMessage);
        sendWindowController.AddMessage(latestMessage).transform.Find("SelectButton").GetComponent<Button>().onClick.AddListener(delegate { SelectMessage(sendWindowController.capturedMessages.Count - 1);});

        if (attackNo == 1) {
            attackRef.GetComponent<ProtocolAttack1Controller>().Capture();
        }
    }

    public void Continue() {
        if (attackNo == 1) {
            attackRef.GetComponent<ProtocolAttack1Controller>().Continue();
        }
    }

    public void SelectMessage(int n) {
        CapturedMessage selectedMessage = (CapturedMessage) sendWindowController.capturedMessages[n];
        sendWindowController.currentlySelectedMessage = selectedMessage;
        sendWindowController.ShowSelectedMessage();

        if (attackNo == 1) {
            attackRef.GetComponent<ProtocolAttack1Controller>().SelectMessage();
        }
    }

    public void SendMessage() {
        fromSend = "Carol";
        carolAlias = sendWindowController.fromSelected;
        toSend = sendWindowController.toSelected;
        toSendMessage = sendWindowController.selectedMessage.transform.Find("SelectedMessageText").GetComponent<TextMeshProUGUI>().text;

        NewStep();
        CapturedMessage newMessage = new CapturedMessage("CarolMessage", toSendMessage);
        latestMessage = newMessage;
        lastStepControl.SetMessageArrow(fromSend, toSend, latestMessage.GetMessage(), carolAlias);

        if (attackNo == 1) {
            attackRef.GetComponent<ProtocolAttack1Controller>().SendMessage();
        }

        sendWindowController.ClickCloseWindowButton();
    }

    public void RestartProtocol() {
        contBut.ResetButton();
        sendWindowController.ResetAll();
        RemoveAll();
        this.gameObject.GetComponent<DOTweenAnimation>().DORestart();

        if (attackNo == 1) {
            attackRef.GetComponent<ProtocolAttack1Controller>().RestartProtocol();
        } else if (attackNo == 2) {
            attackRef.GetComponent<ProtocolAttack2Controller>().RestartProtocol();
        }
    }
}
