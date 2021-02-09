using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapturedMessage 
{
    private string message;
    private int step;
    
    public bool aliceBob = false;
    public bool aliceCarol = false;
    public bool bobCarol = false;

    public void SetMessage(string msg) {
        message = msg;
    }

    public string GetMessage() {
        return message;
    }

    public void SetStep(int step) {
        this.step = step;
    }

    public int GetStep() {
        return step;
    }
}
