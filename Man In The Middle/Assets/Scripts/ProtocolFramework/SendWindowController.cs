using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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

    [Header("Message Prefab")]
    public GameObject messagePrefab;

    [Header("To Buttons")]
    public GameObject aliceSelectedRight;
    public GameObject aliceTextRight;
    public GameObject bobSelectedRight;
    public GameObject bobTextRight;

    [Header("Send Button")]
    public GameObject sendButton;

    public ArrayList capturedMessages = new ArrayList();

    public CapturedMessage currentlySelectedMessage = null;
    public string fromSelected = "";
    public string toSelected = "";

    public void ResetFromButton() {
        fromSelected = "";
        aliceSelectedLeft.SetActive(false);
        bobSelectedLeft.SetActive(false);
        carolSelectedLeft.SetActive(false);

        GameObject[] temp = new GameObject[] { aliceTextLeft, bobTextLeft, carolTextLeft };
        for (int i = 0; i < temp.Length; i++) {
            temp[i].GetComponent<TextMeshProUGUI>().color = Color.white;
        }
    }

    public void ResetToButton() {
        toSelected = "";
        aliceSelectedRight.SetActive(false);
        bobSelectedRight.SetActive(false);
        aliceTextRight.GetComponent<TextMeshProUGUI>().color = Color.white;
        bobTextRight.GetComponent<TextMeshProUGUI>().color = Color.white;
    }

    public void ClickAliceFromButton() {
        ResetFromButton();
        aliceSelectedLeft.SetActive(true);
        aliceTextLeft.GetComponent<TextMeshProUGUI>().color = Color.black;
        fromSelected = "Alice";
        CheckSelectedFromMessageTo();
    }

    public void ClickBobFromButton() {
        ResetFromButton();
        bobSelectedLeft.SetActive(true);
        bobTextLeft.GetComponent<TextMeshProUGUI>().color = Color.black;
        fromSelected = "Bob";
        CheckSelectedFromMessageTo();
    }

    public void ClickCarolFromButton() {
        ResetFromButton();
        carolSelectedLeft.SetActive(true);
        carolTextLeft.GetComponent<TextMeshProUGUI>().color = Color.black;
        fromSelected = "Carol";
        CheckSelectedFromMessageTo();
    }

    public void ClickAliceToButton() {
        ResetToButton();
        aliceSelectedRight.SetActive(true);
        aliceTextRight.GetComponent<TextMeshProUGUI>().color = Color.black;
        toSelected = "Alice";
        CheckSelectedFromMessageTo();
    }

    public void ClickBobToButton() {
        ResetToButton();
        bobSelectedRight.SetActive(true);
        bobTextRight.GetComponent<TextMeshProUGUI>().color = Color.black;
        toSelected = "Bob";
        CheckSelectedFromMessageTo();
    }

    public void ClickCloseWindowButton() {
        currentlySelectedMessage = null;
        sendWindow.SetActive(false);
    }

    public void ShowWindow() {
        sendWindow.SetActive(true);
        sendWindow.GetComponent<DOTweenAnimation>().DORestart();
        CheckSelectedFromMessageTo();
    }

    public void RemoveAllMessages() {
        foreach (Transform child in messageScrollViewContent.transform) {
            Destroy(child.gameObject);
        }
        capturedMessages.Clear();
    }

    public void RemoveAllMessageEdits() {
        foreach (Transform child in selectedMessageEditsScrollViewContent.transform) {
            Destroy(child.gameObject);
        }
    }

    public GameObject AddMessage(CapturedMessage msg) {
        GameObject message = Instantiate(messagePrefab);
        message.GetComponent<MessageRef>().capturedMessage = msg;
        message.GetComponent<MessageRef>().messageText.text = msg.GetMessage();
        message.transform.SetParent(messageScrollViewContent.transform, false);
        return message;
    }

    public void ShowSelectedMessage() {
        ResetMessageView();
        RemoveAllMessageEdits();
        selectedMessage.SetActive(true);
        selectedMessageEdits.SetActive(true);
        selectedMessage.transform.Find("SelectedMessageText").GetComponent<TextMeshProUGUI>().text = currentlySelectedMessage.GetMessage();
        CheckSelectedFromMessageTo();
    }

    public void SetSelectedMessage(string msg) {
        selectedMessage.transform.Find("SelectedMessageText").GetComponent<TextMeshProUGUI>().text = msg;
    }

    public void ResetMessageView() {
        noMessages.SetActive(false);
        selectedMessage.SetActive(false);
        selectedMessageEdits.SetActive(false);
        messageView.SetActive(false);
    }

    public void ResetView() {
        ResetFromButton();
        ResetToButton();
        ResetMessageView();
    }

    public void ResetAll() {
        ResetView();
        RemoveAllMessageEdits();
        RemoveAllMessages();
    }

    public void CloseSelectedMessage() {
        currentlySelectedMessage = null;
        ResetMessageView();
        messageView.SetActive(true);
        CheckSelectedFromMessageTo();
    }

    private void CheckSelectedFromMessageTo() {
        if (!fromSelected.Equals("") && !toSelected.Equals("") && currentlySelectedMessage != null && !fromSelected.Equals(toSelected)) {
            sendButton.GetComponent<Button>().interactable = true;
        } else {
            sendButton.GetComponent<Button>().interactable = false;
        }
    }
}
