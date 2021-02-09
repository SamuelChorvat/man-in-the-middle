using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProtocolAttack1Controller: MonoBehaviour
{
    [Header("Framework Controller")]
    public GameObject protocolFramework;
    public ProtocolFrameworkController frameworkControl;

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
        throw new System.NotImplementedException();
    }

    private void SendAliceBobStep1() {
        frameworkControl.NewStep();
        if (frameworkControl.aliceBobStep != 0) {
            return;
        }

        CapturedMessage newMessage = new CapturedMessage();
        newMessage.SetStep(1);
        newMessage.SetMessage("\"Pay Bob £5\"");
        newMessage.aliceBob = true;
        frameworkControl.latestMessage = newMessage;
        frameworkControl.lastStepControl.SetAliceBobMessageArrow(frameworkControl.latestMessage.GetMessage());
    }
}
