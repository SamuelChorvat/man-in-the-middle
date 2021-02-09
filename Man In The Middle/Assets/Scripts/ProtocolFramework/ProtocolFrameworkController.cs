using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProtocolFrameworkController : MonoBehaviour
{
    [Header("Protocol Attack")]
    public GameObject attackRef;
    public int attackNo;

    [Header("Prefab Refs")]
    public GameObject protocolStepPrefab;
    public GameObject captureInterceptSendPrefab;
    public GameObject continueRestartPrefab;
    public GameObject restartOnlyPrefab;
    public GameObject successPrefab;
    public GameObject failPrefab;
    public GameObject spacePrefab;

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
        captureInterceptSendRef.transform.Find("SendButton").GetComponent<Button>().onClick.AddListener(Send);
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

    public void Fail() {
        InstantiateFail();
        InstantiateRestartOnly();
        InstantiateSpace();
    }

    public void Success() {
        InstantiateSuccess();
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

    public void Send() {
        sendWindowController.ShowWindow();
        sendWindowController.ResetView();

        if (sendWindowController.capturedMessages.Count == 0) {
            sendWindowController.sendButton.GetComponent<Button>().interactable = false;
            sendWindowController.noMessages.SetActive(true);
            return;
        }

        sendWindowController.messageView.SetActive(true);

        if (attackNo == 1) {
            attackRef.GetComponent<ProtocolAttack1Controller>().Send();
        }
    }

    public void Capture() {
        SetInteractableCaptureButton(false);
        sendWindowController.capturedMessages.Add(latestMessage);
        sendWindowController.AddMessage(latestMessage);

        if (attackNo == 1) {
            attackRef.GetComponent<ProtocolAttack1Controller>().Capture();
        }
    }

    public void Continue() {
        if (attackNo == 1) {
            attackRef.GetComponent<ProtocolAttack1Controller>().Continue();
        }
    }

    public void RestartProtocol() {
        sendWindowController.ResetAll();
        RemoveAll();
        this.gameObject.GetComponent<DOTweenAnimation>().DORestart();

        if (attackNo == 1) {
            attackRef.GetComponent<ProtocolAttack1Controller>().RestartProtocol();
        }
    }
}
