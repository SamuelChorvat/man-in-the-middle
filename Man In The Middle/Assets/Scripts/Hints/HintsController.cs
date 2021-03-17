using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HintsController : MonoBehaviour
{
    [Header("Hint Button")]
    public GameObject hintButton;

    [Header("Prefab Refs")]
    public GameObject hintPrefab;
    public GameObject getHintPrefab;

    [Header("Hints Window")]
    public GameObject hintsWindow;

    [Header("Scroll View Content")]
    public GameObject scrollViewContentObject;

    private string currentPuzzle = "";
    private int maxHintNo = 0;
    private int currentHintNo = 0;
    private GameObject getHintRef = null;

    private void ResetHintWindow() {
        RemoveAllHints();
        InstantiateGetHint();
        currentPuzzle = "";
        maxHintNo = 0;
        currentHintNo = 0;
    }

    public void RemoveAllHints() {
        getHintRef = null;
        foreach (Transform child in scrollViewContentObject.transform) {
            Destroy(child.gameObject);
        }
    }

    private GameObject InstantiateHint(string msg) {
        GameObject hint = Instantiate(hintPrefab);
        hint.GetComponent<TextMeshProUGUI>().text = msg;
        hint.transform.SetParent(scrollViewContentObject.transform, false);
        return hint;
    }

    private GameObject InstantiateGetHint() {
        GameObject getHint = Instantiate(getHintPrefab);
        getHint.transform.SetParent(scrollViewContentObject.transform, false);
        getHintRef = getHint;
        getHintRef.transform.Find("GetHintButton").GetComponent<Button>().onClick.AddListener(GetHint);
        return getHint;
    }

    public void GetHint() {
        if (currentHintNo >= maxHintNo) {
            return;
        }
        currentHintNo += 1;
        
        if (currentPuzzle.Equals("ProtocolAttack8")) {
            if (currentHintNo == 1) {
                NewHint("Hint 1");
            } else if (currentHintNo == 2) {
                NewHint("Hint 2");
            } else if (currentHintNo == 3) {
                NewHint("Last Hint!");
            }

        }

        
        if (currentHintNo >= maxHintNo) {
            Destroy(getHintRef);
        }
    }

    private void PrepareForNewHint() {
        Destroy(getHintRef);
        getHintRef = null;
    }

    private void NewHint(string hint) {
        PrepareForNewHint();
        InstantiateHint(hint);
        InstantiateGetHint();
    }

    public void SetCurrentPuzzle(string pName) {
        ResetHintWindow();
        hintButton.SetActive(true);
        currentPuzzle = pName;
        switch(currentPuzzle) {
            case "ProtocolAttack8":
                maxHintNo = 3;
                break;
        }
    }

    public void OpenHintsWindow() {
        hintsWindow.gameObject.SetActive(true);
    }

    public void CloseHintsWindow() {
        hintsWindow.gameObject.SetActive(false);
    }
}
