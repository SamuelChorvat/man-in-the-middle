using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProtocolFrameworkController : MonoBehaviour
{
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

    //References
    private GameObject lastStepRef = null;
    private GameObject captureInterceptSendRef = null;
    private GameObject continueRestartRef = null;
    private GameObject restartOnlyRef = null;

    public ProtocolStepController lastStepControl = null;

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
        continueRestartRef.transform.Find("RestartButton").GetComponent<Button>().onClick.AddListener(Restart);
        return continueRestart;
    }

    private GameObject InstantiateRestartOnly() {
        GameObject restartOnly = Instantiate(restartOnlyPrefab);
        restartOnly.transform.SetParent(scrollViewContentObject.transform, false);
        restartOnlyRef = restartOnly;
        restartOnlyRef.transform.Find("RestartButton").GetComponent<Button>().onClick.AddListener(Restart);
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

    private void SetInteractableInterceptButton(bool interactable) {
        captureInterceptSendRef.transform.Find("InterceptButton").GetComponent<Button>().interactable = interactable;
    }

    private void SetInteractableCaptureButton(bool interactable) {
        captureInterceptSendRef.transform.Find("CaptureButton").GetComponent<Button>().interactable = interactable;
    }

    public void Intercept() {
        lastStepControl.Intercept();
        SetInteractableInterceptButton(false);
    }

    public void Send() {

    }

    public void Capture() {
        SetInteractableCaptureButton(false);
    }

    public void Restart() {

    }

    public void Continue() {

    }

    public void Start() {
        NewStep();
    }
}
