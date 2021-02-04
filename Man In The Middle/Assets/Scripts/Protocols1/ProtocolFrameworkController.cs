using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

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

    public GameObject InstantiateProtocolStep() {
        GameObject protocolStep = Instantiate(protocolStepPrefab);
        protocolStep.transform.SetParent(scrollViewContentObject.transform,false);
        return protocolStep;
    }

    public GameObject InstantiateCaptureInterceptSend() {
        GameObject captureInterceptSend = Instantiate(captureInterceptSendPrefab);
        captureInterceptSend.transform.SetParent(scrollViewContentObject.transform, false);
        return captureInterceptSend;
    }

    public GameObject InstantiateContinueRestart() {
        GameObject continueRestart = Instantiate(continueRestartPrefab);
        continueRestart.transform.SetParent(scrollViewContentObject.transform, false);
        return continueRestart;
    }

    public GameObject InstantiateRestartOnly() {
        GameObject restartOnly = Instantiate(restartOnlyPrefab);
        restartOnly.transform.SetParent(scrollViewContentObject.transform, false);
        return restartOnly;
    }

    public GameObject InstantiateSuccess() {
        GameObject success = Instantiate(successPrefab);
        success.transform.SetParent(scrollViewContentObject.transform, false);
        return success;
    }

    public GameObject InstantiateFail() {
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
        foreach (Transform child in scrollViewContentObject.transform) {
            Destroy(child.gameObject);
        }
    }

    public void Start() {
        InstantiateProtocolStep();
        InstantiateCaptureInterceptSend();
        InstantiateContinueRestart();
        InstantiateRestartOnly();
        InstantiateSuccess();
        InstantiateFail();
        InstantiateRestartOnly();
        InstantiateSpace();
    }
}
