using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProtocolStepController : MonoBehaviour
{
    [Header("Alice")]
    public GameObject alice;
    
    [Header("Bob")]
    public GameObject bob;

    [Header("Carol")]
    public GameObject carol;

    [Header("Messages")]
    public GameObject aliceBobMessage;
    public GameObject bobAliceMessage;
    public GameObject aliceCarolMessage;
    public GameObject carolAliceMessage;
    public GameObject carolBobMessage;
    public GameObject bobCarolMessage;

    [Header("Arrows")]
    public GameObject aliceBobArrow;
    public GameObject bobAliceArrow;
    public GameObject aliceCarolArrow;
    public GameObject carolAliceArrow;
    public GameObject carolBobArrow;
    public GameObject bobCarolArrow;

    //Carol strings
    private string carolCarol = "Carol";
    private string carolAlice = "Carol<size=50%>(Alice)</size>";
    private string carolBob = "Carol<size=50%>(Bob)</size>";

    public void ResetProtocolStep() {
        GameObject[] temp = new GameObject[] {alice, bob, carol};   
        for (int i = 0; i < temp.Length; i++) {
            temp[i].GetComponent<Image>().color = Color.white;
            temp[i].transform.Find("Name").GetComponent<TextMeshProUGUI>().color = Color.white;
            temp[i].SetActive(false);
        }

        temp = new GameObject[] { aliceBobMessage, bobAliceMessage, aliceCarolMessage, carolAliceMessage, carolBobMessage, bobCarolMessage };
        for (int i = 0; i < temp.Length; i++) {
            temp[i].GetComponent<TextMeshProUGUI>().color = Color.white;
            temp[i].SetActive(false);
        }

        temp = new GameObject[] { aliceBobArrow, bobAliceArrow, aliceCarolArrow, carolAliceArrow, carolBobArrow, bobCarolArrow };
        for (int i = 0; i < temp.Length; i++) {
            temp[i].GetComponent<Image>().color = Color.white;
            temp[i].transform.Find("ArrowHead").GetComponent<Image>().color = Color.white;
            temp[i].SetActive(false);
        }
    }

    public void SetCarol(string name) {
        if (name.Equals("Alice")) {
            SetCarolAlice();
        } else if (name.Equals("Bob")) {
            SetCarolBob();
        } else if (name.Equals("Carol")) {
            SetCarolCarol();
        }
    }

    private void SetCarolCarol() {
        carol.SetActive(true);
        carol.GetComponent<Image>().color = Color.white;
        carol.transform.Find("Name").GetComponent<TextMeshProUGUI>().text = carolCarol;
        carol.transform.Find("Name").GetComponent<TextMeshProUGUI>().color = Color.white;
    }

    private void SetCarolAlice() {
        carol.SetActive(true);
        carol.GetComponent<Image>().color = Color.red;
        carol.transform.Find("Name").GetComponent<TextMeshProUGUI>().text = carolAlice;
        carol.transform.Find("Name").GetComponent<TextMeshProUGUI>().color = Color.red;
    }

    private void SetCarolBob() {
        carol.SetActive(true);
        carol.GetComponent<Image>().color = Color.red;
        carol.transform.Find("Name").GetComponent<TextMeshProUGUI>().text = carolBob;
        carol.transform.Find("Name").GetComponent<TextMeshProUGUI>().color = Color.red;
    }

    public void SetAliceBobMessageArrow(string msg) {
        alice.SetActive(true);
        bob.SetActive(true);
        aliceBobArrow.SetActive(true);
        aliceBobMessage.SetActive(true);
        aliceBobMessage.GetComponent<TextMeshProUGUI>().text = msg;
    }

    public void SetBobAliceMessageArrow(string msg) {
        alice.SetActive(true);
        bob.SetActive(true);
        bobAliceArrow.SetActive(true);
        bobAliceMessage.SetActive(true);
        bobAliceMessage.GetComponent<TextMeshProUGUI>().text = msg;
    }

    public void SetAliceCarolMessageArrow(string msg, bool red) {
        alice.SetActive(true);
        aliceCarolArrow.SetActive(true);
        aliceCarolMessage.SetActive(true);
        aliceCarolMessage.GetComponent<TextMeshProUGUI>().text = msg;
        if (red) {
            aliceCarolMessage.GetComponent<TextMeshProUGUI>().color = Color.red;
            aliceCarolArrow.GetComponent<Image>().color = Color.red;
            aliceCarolArrow.transform.Find("ArrowHead").GetComponent<Image>().color = Color.red;
        } 
    }

    public void SetCarolAliceMessageArrow(string msg, bool red) {
        alice.SetActive(true);
        carolAliceArrow.SetActive(true);
        carolAliceMessage.SetActive(true);
        carolAliceMessage.GetComponent<TextMeshProUGUI>().text = msg;
        if (red) {
            carolAliceMessage.GetComponent<TextMeshProUGUI>().color = Color.red;
            carolAliceArrow.GetComponent<Image>().color = Color.red;
            carolAliceArrow.transform.Find("ArrowHead").GetComponent<Image>().color = Color.red;
        }
    }

    public void SetBobCarolMessageArrow(string msg, bool red) {
        bob.SetActive(true);
        bobCarolArrow.SetActive(true);
        bobCarolMessage.SetActive(true);
        bobCarolMessage.GetComponent<TextMeshProUGUI>().text = msg;
        if (red) {
            bobCarolMessage.GetComponent<TextMeshProUGUI>().color = Color.red;
            bobCarolArrow.GetComponent<Image>().color = Color.red;
            bobCarolArrow.transform.Find("ArrowHead").GetComponent<Image>().color = Color.red;
        }
    }

    public void SetCarolBobMessageArrow(string msg, bool red) {
        bob.SetActive(true);
        carolBobArrow.SetActive(true);
        carolBobMessage.SetActive(true);
        carolBobMessage.GetComponent<TextMeshProUGUI>().text = msg;
        if (red) {
            carolBobMessage.GetComponent<TextMeshProUGUI>().color = Color.red;
            carolBobArrow.GetComponent<Image>().color = Color.red;
            carolBobArrow.transform.Find("ArrowHead").GetComponent<Image>().color = Color.red;
        }
    }

    public void Intercept() {
        if(carol.activeSelf) {
            return;
        }

        if (aliceBobArrow.activeSelf) {
            SetCarolBob();
            SetAliceCarolMessageArrow(aliceBobMessage.GetComponent<TextMeshProUGUI>().text, false);
            aliceBobArrow.SetActive(false);
            aliceBobMessage.SetActive(false);
            bob.SetActive(false);

        } else if (bobAliceArrow.activeSelf) {
            SetCarolAlice();
            SetBobCarolMessageArrow(bobAliceMessage.GetComponent<TextMeshProUGUI>().text, false);
            bobAliceArrow.SetActive(false);
            bobAliceMessage.SetActive(false);
            alice.SetActive(false);
        }
    }
}
