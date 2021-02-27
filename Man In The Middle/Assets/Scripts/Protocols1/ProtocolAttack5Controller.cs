using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtocolAttack5Controller : MonoBehaviour
{
    [Header("Framework Controller")]
    public GameObject protocolFramework;
    public ProtocolFrameworkController frameworkControl;

    private int lastStepCB = 0;
    private bool replyAdded = false;

    public void RestartProtocol() {
        lastStepCB = 0;
        replyAdded = false;
        GetThirdPartyKey();
    }

    public void Intercept() {

    }

    public void SendMessage() {
        if (!frameworkControl.latestMessage.alias.Equals("Carol")) {
            frameworkControl.Fail("You do not need to impersonate " + frameworkControl.latestMessage.alias + " to exploit this protocol.");
            return;
        }

        if (frameworkControl.latestMessage.to.Equals("Alice")) {
            frameworkControl.Fail("You do not need to communicate with Alice to exploit this protocol.");
            return;
        }

        if (frameworkControl.latestMessage.to.Equals("Bob")) {
            lastStepCB += 1;
        }

        if (lastStepCB == 6) {
            frameworkControl.Success("As you can see, you are able to reuse old key anytime you want which is not good.");
        } else {
            BobReply(frameworkControl.latestMessage);
        }
    }

    public void Continue() {

    }

    public void SelectMessage() {

    }

    private void BobReply(CapturedMessage msg) {
        if (msg.from.Equals("Carol")) {
            if ((lastStepCB == 1 || lastStepCB == 4) && msg.message.Equals("{ K<sub>CB</sub> , C }<size=70%>K</size><sub>BS</sub>")) {
                frameworkControl.NewStep();
                lastStepCB += 1;
                CapturedMessage newMessage = new CapturedMessage("CarolBobMessage" + lastStepCB, "{ N<sub>B</sub> }<size=70%>K</size><sub>CB</sub>", "Bob", "Carol", "Carol");
                frameworkControl.latestMessage = newMessage;
                frameworkControl.lastStepControl.SetMessageArrow("Bob", "Carol", frameworkControl.latestMessage.GetMessage(), "Carol");

                if (!replyAdded) {
                    frameworkControl.AddCapturedMessage(new CapturedMessage("CarolBobMessage1", "{ N<sub>B</sub> + 1 }<size=70%>K</size><sub>CB</sub>", "Carol", "Bob", "Carol"));
                    replyAdded = true;
                }

                return;
            }

            if (lastStepCB == 3) {
                frameworkControl.Message("Protocol finished.");
                return;
            }

            frameworkControl.Fail("Invalid or unexpected message.");
        } else {
            frameworkControl.Fail("Invalid or unexpected message.");
        }
    }

    private void GetThirdPartyKey() {
        frameworkControl.NewStep();
        CapturedMessage newMessage1 = new CapturedMessage("ThirdPartyMessage1", "C , B , N<sub>C</sub>", "Carol", "Bob", "Carol");
        frameworkControl.latestMessage = newMessage1;
        frameworkControl.lastStepControl.SetMessageArrow("Carol", "Bob", frameworkControl.latestMessage.GetMessage(), "Carol");
        frameworkControl.lastStepControl.SetBob("P");

        frameworkControl.NewStep();
        CapturedMessage newMessage2 = new CapturedMessage("ThirdPartyMessage2", "{ N<sub>C</sub> , B , K<sub>CB</sub> , { K<sub>CB</sub> , A }<size=70%>K</size><sub>BS</sub> }<size=70%>K</size><sub>CS</sub>", "Bob", "Carol", "Carol");
        frameworkControl.latestMessage = newMessage2;
        frameworkControl.lastStepControl.SetMessageArrow("Bob", "Carol", frameworkControl.latestMessage.GetMessage(), "Carol");
        frameworkControl.lastStepControl.SetBob("P");

        frameworkControl.AddCapturedMessage(new CapturedMessage("CarolBobMessage1", "{ K<sub>CB</sub> , C }<size=70%>K</size><sub>BS</sub>", "Carol", "Bob", "Carol"));
    }
}
