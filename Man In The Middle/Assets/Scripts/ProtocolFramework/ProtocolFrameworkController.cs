using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text.RegularExpressions;
using System;

public class ProtocolFrameworkController : MonoBehaviour
{
    [Header("Protocol Attacks")]
    public ProtocolAttack1Controller attack1Ref;
    public ProtocolAttack2Controller attack2Ref;
    public ProtocolAttack3Controller attack3Ref;
    public ProtocolAttack4Controller attack4Ref;
    public ProtocolAttack5Controller attack5Ref;
    public ProtocolAttack6Controller attack6Ref;
    public ProtocolAttack7Controller attack7Ref;
    public ProtocolAttack8Controller attack8Ref;

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

    [Header("Message Edit Prefabs Attack 2")]
    public GameObject attack2AliceBobMessage1Letter;
    public GameObject attack2AliceBobMessage3Nonce;
    public GameObject attack2AliceBobMessage6Message;

    [Header("Message Edit Prefabs Attack 3")]
    public GameObject attack3AliceCarolMessage1Encryption;

    [Header("Message Edit Prefabs Attack 4")]
    public GameObject attack4AliceCarolMessage2Signature;

    [Header("Scroll View")]
    public GameObject scrollViewObject;

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
    public string toMessageName = "";

    private int attackNo = -1;

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
        continueRestartRef.transform.Find("RestartButton").GetComponent<Button>().onClick.AddListener(delegate { RestartProtocol(attackNo.ToString()); });
        return continueRestart;
    }

    private GameObject InstantiateRestartOnly() {
        GameObject restartOnly = Instantiate(restartOnlyPrefab);
        restartOnly.transform.SetParent(scrollViewContentObject.transform, false);
        restartOnlyRef = restartOnly;
        restartOnlyRef.transform.Find("RestartButton").GetComponent<Button>().onClick.AddListener(delegate { RestartProtocol(attackNo.ToString()); });
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
        ScrollToBottomProtocolView();
    }

    public void Success(string msg) {
        PrepareForNewStep();
        InstantiateSuccess();
        InstantiateEndMessage(msg);
        ScrollToBottomProtocolView();
        contBut.StartReveal();
    }

    public void Message(string msg) {
        PrepareForNewStep();
        InstantiateEndMessage(msg);
        InstantiateCaptureInterceptSend();
        InstantiateContinueRestart();
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
            attack1Ref.Intercept();
        } else if (attackNo == 2) {
            attack2Ref.Intercept();
        } else if (attackNo == 3) {
            attack3Ref.Intercept();
        } else if (attackNo == 4) {
            attack4Ref.Intercept();
        } else if (attackNo == 5) {
            attack5Ref.Intercept();
        } else if (attackNo == 6) {
            attack6Ref.Intercept();
        } else if (attackNo == 7) {
            attack7Ref.Intercept();
        } else if (attackNo == 8) {
            attack8Ref.Intercept();
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
        toMessageName = "";

        if (sendWindowController.capturedMessages.Count == 0) {
            sendWindowController.noMessages.SetActive(true);
        } else {
            sendWindowController.messageView.SetActive(true);
        }
    }

    public void Capture() {
        SetInteractableCaptureButton(false);
        sendWindowController.capturedMessages.Add(latestMessage);
        int index = sendWindowController.capturedMessages.Count - 1;
        sendWindowController.AddMessage(latestMessage).transform.Find("SelectButton").GetComponent<Button>().onClick.AddListener(delegate { SelectMessage(index);});
    }

    public void AddCapturedMessage(CapturedMessage toAdd) {
        sendWindowController.capturedMessages.Add(toAdd);
        int index = sendWindowController.capturedMessages.Count - 1;
        sendWindowController.AddMessage(toAdd).transform.Find("SelectButton").GetComponent<Button>().onClick.AddListener(delegate { SelectMessage(index); });
    }

    public void Continue() {
        if (attackNo == 1) {
            attack1Ref.Continue();
        } else if (attackNo == 2) {
            attack2Ref.Continue();
        } else if (attackNo == 3) {
            attack3Ref.Continue();
        } else if (attackNo == 4) {
            attack4Ref.Continue();
        } else if (attackNo == 5) {
            attack5Ref.Continue();
        } else if (attackNo == 6) {
            attack6Ref.Continue();
        } else if (attackNo == 7) {
            attack7Ref.Continue();
        } else if (attackNo == 8) {
            attack8Ref.Continue();
        }
    }

    public void SelectMessage(int n) {
        CapturedMessage selectedMessage = (CapturedMessage) sendWindowController.capturedMessages[n];
        sendWindowController.currentlySelectedMessage = selectedMessage;
        sendWindowController.ShowSelectedMessage();

        if (attackNo == 1) {
            attack1Ref.SelectMessage();
        } else if (attackNo == 2) {
            attack2Ref.SelectMessage();
        } else if (attackNo == 3) {
            attack3Ref.SelectMessage();
        } else if (attackNo == 4) {
            attack4Ref.SelectMessage();
        } else if (attackNo == 5) {
            attack5Ref.SelectMessage();
        } else if (attackNo == 6) {
            attack6Ref.SelectMessage();
        } else if (attackNo == 7) {
            attack7Ref.SelectMessage();
        } else if (attackNo == 8) {
            attack8Ref.SelectMessage();
        }
    }

    public void SendMessage() {
        fromSend = "Carol";
        carolAlias = sendWindowController.fromSelected;
        toSend = sendWindowController.toSelected;
        toSendMessage = sendWindowController.selectedMessage.transform.Find("SelectedMessageText").GetComponent<TextMeshProUGUI>().text;
        toMessageName = sendWindowController.selectedMessageName;

        NewStep();
        CapturedMessage newMessage = new CapturedMessage(toMessageName, toSendMessage, fromSend, toSend, carolAlias);
        latestMessage = newMessage;
        lastStepControl.SetMessageArrow(fromSend, toSend, latestMessage.GetMessage(), carolAlias);

        if (attackNo == 1) {
            attack1Ref.SendMessage();
        } else if (attackNo == 2) {
            attack2Ref.SendMessage();
        } else if (attackNo == 3) {
            attack3Ref.SendMessage();
        } else if (attackNo == 4) {
            attack4Ref.SendMessage();
        } else if (attackNo == 5) {
            attack5Ref.SendMessage();
        } else if (attackNo == 6) {
            attack6Ref.SendMessage();
        } else if (attackNo == 7) {
            attack7Ref.SendMessage();
        } else if (attackNo == 8) {
            attack8Ref.SendMessage();
        }

        sendWindowController.ClickCloseWindowButton();
    }

    public void RestartProtocol(string attackNumber) {
        contBut.ResetButton();
        sendWindowController.ResetAll();
        RemoveAll();
        this.gameObject.GetComponent<DOTweenAnimation>().DORestart();
        attackNo = Int32.Parse(attackNumber);

        if (attackNo == 1) {
            attack1Ref.RestartProtocol();
        } else if (attackNo == 2) {
            attack2Ref.RestartProtocol();
        } else if (attackNo == 3) {
            attack3Ref.RestartProtocol();
        } else if (attackNo == 4) {
            attack4Ref.RestartProtocol();
        } else if (attackNo == 5) {
            attack5Ref.RestartProtocol();
        } else if (attackNo == 6) {
            attack6Ref.RestartProtocol();
        } else if (attackNo == 7) {
            attack7Ref.RestartProtocol();
        } else if (attackNo == 8) {
            attack8Ref.RestartProtocol();
        }
    }

    public void ScrollToBottomProtocolView() {
        Canvas.ForceUpdateCanvases();
        scrollViewObject.GetComponent<ScrollRect>().verticalNormalizedPosition = 0f;
        Canvas.ForceUpdateCanvases();
    }

    public void ResetProtocolAttack() {
        contBut.ResetButton();
        sendWindowController.ResetAll();
        RemoveAll();
        this.gameObject.transform.localScale = new Vector3(0, 0, 0);
    }
}
