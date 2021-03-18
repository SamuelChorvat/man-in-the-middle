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

        switch (currentPuzzle) {
            case "ProtocolAttack1":
                if (currentHintNo == 1) {
                    NewHint("\n1. Try to intercept and capture the first message.");
                } else if (currentHintNo == 2) {
                    NewHint("\n2. Change the money amount in the captured message.");
                } else if (currentHintNo == 3) {
                    NewHint("\n3. Send the modified message to Bob while impersonating Alice.");
                }
                break;

            case "ProtocolAttack2":
                if (currentHintNo == 1) {
                    NewHint("\n1. Notice the fact that the Nonce is encrypted separately from the actual message.");
                } else if (currentHintNo == 2) {
                    NewHint("\n2. Capture the message that says \"Pay Carol £5\".");
                } else if (currentHintNo == 3) {
                    NewHint("\n3. Intercept and swap the \"Pay Bob £5\" message with the previously captured message to get paid twice.");
                } 
                break;

            case "ProtocolAttack3":
                if (currentHintNo == 1) {
                    NewHint("\n1. Communicate with Bob while impersonating Alice.");
                } else if (currentHintNo == 2) {
                    NewHint("\n2. Capture Bob's reply and send it to Alice.");
                } else if (currentHintNo == 3) {
                    NewHint("\n3. Use the Alice's reply to trick Bob.");
                } else if (currentHintNo == 4) {
                    NewHint("\n4. Do not forget to change the public key encryption of the Alice's reply accordingly.");
                }
                break;

            case "ProtocolAttack4":
                if (currentHintNo == 1) {
                    NewHint("\n1. Impersonate Alice.");
                } else if (currentHintNo == 2) {
                    NewHint("\n2. Change signature on the message received from Bob and use it to trick Alice.");
                } else if (currentHintNo == 3) {
                    NewHint("\n3. Use the Alice's reply to trick Bob.");
                }
                break;

            case "ProtocolAttack5":
                if (currentHintNo == 1) {
                    NewHint("\n1. Start communication with Bob using the obtained key.");
                } else if (currentHintNo == 2) {
                    NewHint("\n2. Complete the protocol run.");
                } else if (currentHintNo == 3) {
                    NewHint("\n3. Start a new conversation using the same key that you obtained from the trusted 3rd party.");
                } 
                break;

            case "ProtocolAttack6":
                if (currentHintNo == 1) {
                    NewHint("\n1. Use Carol's login and password to receive symmetric key from Bob's shop.");
                } else if (currentHintNo == 2) {
                    NewHint("\n2. Impersonate Bob's shop.");
                } else if (currentHintNo == 3) {
                    NewHint("\n3. Change the public key encryption on the symmetric key you receive from Bob's shop.");
                } else if (currentHintNo == 4) {
                    NewHint("\n4. Send the symmetric key to Alice. Make sure you change the public key encryption accordingly.");
                }
                break;

            case "ProtocolAttack7":
                if (currentHintNo == 1) {
                    NewHint("\n1. Impersonate Bob when communicating with Alice and impersonate Alice when communicating with Bob.");
                } else if (currentHintNo == 2) {
                    NewHint("\n2. Intercept the first message.");
                } else if (currentHintNo == 3) {
                    NewHint("\n3. Trick Bob into using your g<sup>z</sup>.");
                }
                break;

            case "ProtocolAttack8":
                if (currentHintNo == 1) {
                    NewHint("\n1. Try impersonating Alice.");
                } else if (currentHintNo == 2) {
                    NewHint("\n2. Capture the first message and send it to Bob.");
                } else if (currentHintNo == 3) {
                    NewHint("\n3. Change the public key encryption to trick Bob.");
                }
                break;
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
            case "ProtocolAttack1":
                maxHintNo = 3;
                break;
            case "ProtocolAttack2":
                maxHintNo = 3;
                break;
            case "ProtocolAttack3":
                maxHintNo = 4;
                break;
            case "ProtocolAttack4":
                maxHintNo = 3;
                break;
            case "ProtocolAttack5":
                maxHintNo = 3;
                break;
            case "ProtocolAttack6":
                maxHintNo = 4;
                break;
            case "ProtocolAttack7":
                maxHintNo = 3;
                break;
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
