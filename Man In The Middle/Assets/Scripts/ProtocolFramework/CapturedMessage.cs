using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapturedMessage {
    public string messageName;
    public string message;

    public string from;
    public string to;
    public string alias;
    //public int step;

    /*public bool aliceBob = false;
    public bool aliceCarol = false;
    public bool bobCarol = false;*/

    public CapturedMessage(string msgName, string msg, string from, string to, string alias) {
        this.messageName = msgName;
        this.message = msg;
        this.from = from;
        this.to = to;
        this.alias = alias;
    }

    public void SetMessage(string msg) {
        message = msg;
    }

    public string GetMessage() {
        return message;
    }

    /*public void SetStep(int step) {
        this.step = step;
    }

    public int GetStep() {
        return step;
    }*/
}
