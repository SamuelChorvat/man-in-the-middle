using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtocolAttack1Controller: MonoBehaviour
{
    [Header("Framework Controller")]
    public GameObject protocolFramework;
    public ProtocolFrameworkController frameworkControl;

    public void StartProtocol() {
        frameworkControl.RemoveAll();
        frameworkControl.NewStep();
        protocolFramework.GetComponent<DOTweenAnimation>().DORestart();
        frameworkControl.lastStepControl.SetAliceBobMessageArrow("\"Pay Bob £5\"");
    }
    
    public void Intercept() {
        frameworkControl.lastStepControl.Intercept();
        frameworkControl.SetInteractableInterceptButton(false);
    }

    public void Send() {
        frameworkControl.sendWindowController.ShowWindow();
    }

    public void Capture() {
        frameworkControl.SetInteractableCaptureButton(false);
    }

    public void Continue() {
        throw new System.NotImplementedException();
    }

    public void Restart() {
        throw new System.NotImplementedException();
    }
    
}
