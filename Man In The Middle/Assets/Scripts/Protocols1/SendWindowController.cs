using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SendWindowController : MonoBehaviour
{
    [Header("Close Window")]
    public GameObject sendWindow;

    [Header("Scroll View Contents")]
    public GameObject messageScrollViewContent;
    public GameObject selectedMessageEditsScrollViewContent;

    [Header("From Buttons")]
    public GameObject aliceSelectedLeft;
    public GameObject aliceTextLeft;
    public GameObject bobSelectedLeft;
    public GameObject bobTextLeft;
    public GameObject carolSelectedLeft;
    public GameObject carolTextLeft;

    [Header("Message Views")]
    public GameObject noMessages;
    public GameObject selectedMessage;
    public GameObject selectedMessageEdits;
    public GameObject messageView;

    [Header("To Buttons")]
    public GameObject aliceSelectedRight;
    public GameObject aliceTextRight;
    public GameObject bobSelectedRight;
    public GameObject bobTextRight;

    [Header("Send Button")]
    public GameObject sendButton;

    public void ResetFromButton() {
        aliceSelectedLeft.SetActive(false);
        bobSelectedLeft.SetActive(false);
        carolSelectedLeft.SetActive(false);

        GameObject[] temp = new GameObject[] { aliceTextLeft, bobTextLeft, carolTextLeft };
        for (int i = 0; i < temp.Length; i++) {
            temp[i].GetComponent<TextMeshProUGUI>().color = Color.white;
        }
    }

    public void ResetToButton() {
        aliceSelectedRight.SetActive(false);
        bobSelectedRight.SetActive(false);
        aliceTextRight.GetComponent<TextMeshProUGUI>().color = Color.white;
        bobTextRight.GetComponent<TextMeshProUGUI>().color = Color.white;
    }

    public void ClickAliceFromButton() {
        ResetFromButton();
        aliceSelectedLeft.SetActive(true);
        aliceTextLeft.GetComponent<TextMeshProUGUI>().color = Color.black;
    }

    public void ClickBobFromButton() {
        ResetFromButton();
        bobSelectedLeft.SetActive(true);
        bobTextLeft.GetComponent<TextMeshProUGUI>().color = Color.black;
    }

    public void ClickCarolFromButton() {
        ResetFromButton();
        carolSelectedLeft.SetActive(true);
        carolTextLeft.GetComponent<TextMeshProUGUI>().color = Color.black;
    }

    public void ClickAliceToButton() {
        ResetToButton();
        aliceSelectedRight.SetActive(true);
        aliceTextRight.GetComponent<TextMeshProUGUI>().color = Color.black;
    }

    public void ClickBobToButton() {
        ResetToButton();
        bobSelectedRight.SetActive(true);
        bobTextRight.GetComponent<TextMeshProUGUI>().color = Color.black;
    }

    public void ClickCloseWindowButton() {
        sendWindow.SetActive(false);
    }

    public void RemoveAllMessages() {
        foreach (Transform child in messageScrollViewContent.transform) {
            Destroy(child.gameObject);
        }
    }

    public void RemoveAllMessageEdits() {
        foreach (Transform child in selectedMessageEditsScrollViewContent.transform) {
            Destroy(child.gameObject);
        }
    }

    public void ResetMessageView() {
        noMessages.SetActive(false);
        selectedMessage.SetActive(false);
        selectedMessageEdits.SetActive(false);
        messageView.SetActive(false);
    }
}
