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

    [Header("Scroll View")]
    public GameObject scrollViewObject;

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
            case "CaesarPuzzle":
                if (currentHintNo == 1) {
                    NewHint("1. A = D");
                } else if (currentHintNo == 2) {
                    NewHint("2. B = E");
                } else if (currentHintNo == 3) {
                    NewHint("3. C = F");
                } else if (currentHintNo == 4) {
                    NewHint("4. D = G");
                } else if (currentHintNo == 5) {
                    NewHint("5. E = H");
                } else if (currentHintNo == 6) {
                    NewHint("6. F = I");
                } else if (currentHintNo == 7) {
                    NewHint("7. G = J");
                } else if (currentHintNo == 8) {
                    NewHint("8. H = K");
                } else if (currentHintNo == 9) {
                    NewHint("9. I = L");
                } else if (currentHintNo == 10) {
                    NewHint("10. J = M");
                } else if (currentHintNo == 11) {
                    NewHint("11. K = N");
                } else if (currentHintNo == 12) {
                    NewHint("12. L = O");
                } else if (currentHintNo == 13) {
                    NewHint("13. M = P");
                } else if (currentHintNo == 14) {
                    NewHint("14. N = Q");
                } else if (currentHintNo == 15) {
                    NewHint("15. O = R");
                } else if (currentHintNo == 16) {
                    NewHint("16. P = S");
                } else if (currentHintNo == 17) {
                    NewHint("17. Q = T");
                } else if (currentHintNo == 18) {
                    NewHint("18. R = U");
                } else if (currentHintNo == 19) {
                    NewHint("19. S = V");
                } else if (currentHintNo == 20) {
                    NewHint("20. T = W");
                } else if (currentHintNo == 21) {
                    NewHint("21. U = X");
                } else if (currentHintNo == 22) {
                    NewHint("22. V = Y");
                } else if (currentHintNo == 23) {
                    NewHint("23. W = Z");
                } else if (currentHintNo == 24) {
                    NewHint("24. X = A");
                } else if (currentHintNo == 25) {
                    NewHint("25. Y = B");
                } else if (currentHintNo == 26) {
                    NewHint("26. Z = C");
                }
                break;

            case "CaesarPuzzleRotations":
                if (currentHintNo == 1) {
                    NewHint("\n1. Try to using the arrows until you find the correct rotation.");
                } 
                break;

            case "CaesarPuzzleFrequencies":
                if (currentHintNo == 1) {
                    NewHint("\n1. Compare the english letter frequencies with the frequencies of the letters in the cipher text.");
                } else if (currentHintNo == 2) {
                    NewHint("\n2. Substitute letters with similar frequencies.");
                } 
                break;

            case "VigenereCipher":
                if (currentHintNo == 1) {
                    NewHint("\n1. Look up the letter substitutions in the Vigenere table.");
                } 
                break;

            case "ModuloArithmetic":
                if (currentHintNo == 1) {
                    NewHint("\n1. a mod b = r for largest whole number k such that a = b.k + r");
                } else if (currentHintNo == 2) {
                    NewHint("\n2. 5 mod 2 = 1 because 5 = 2*2 + 1");
                }
                break;

            case "XOR":
                if (currentHintNo == 1) {
                    NewHint("\n1. 0 xor 0 = 0");
                } else if (currentHintNo == 2) {
                    NewHint("\n2. 0 xor 1 = 1");
                } else if (currentHintNo == 3) {
                    NewHint("\n3. 1 xor 1 = 0");
                } else if (currentHintNo == 4) {
                    NewHint("\n4. 1 xor 0 = 1");
                }
                break;

            case "DESBruteforce":
                if (currentHintNo == 1) {
                    NewHint("\n1. Click on all the bruteforce buttons.");
                } 
                break;

            case "ECBPicture":
                if (currentHintNo == 1) {
                    NewHint("\n1. It has black and white fur.");
                } else if (currentHintNo == 2) {
                    NewHint("\n2. It is panda.");
                }
                break;

            case "GameConsole":
                if (currentHintNo == 1) {
                    NewHint("\n1. Follow the steps.");
                } 
                break;

            case "DiffieHellman":
                if (currentHintNo == 1) {
                    NewHint("\n1. Follow the steps.");
                }
                break;

            case "Hashes":
                if (currentHintNo == 1) {
                    NewHint("\n1. Hash one message.");
                }
                break;

            case "Birthday":
                if (currentHintNo == 1) {
                    NewHint("\n1. Try pressing the ask button.");
                }
                break;

            case "KnownText":
                if (currentHintNo == 1) {
                    NewHint("\n1. Follow the steps.");
                }
                break;

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

        ScrollToBottomProtocolView();
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
            case "CaesarPuzzle":
                maxHintNo = 26;
                break;
            case "CaesarPuzzleRotations":
                maxHintNo = 1;
                break;
            case "CaesarPuzzleFrequencies":
                maxHintNo = 2;
                break;
            case "VigenereCipher":
                maxHintNo = 1;
                break;
            case "ModuloArithmetic":
                maxHintNo = 2;
                break;
            case "XOR":
                maxHintNo = 4;
                break;
            case "DESBruteforce":
                maxHintNo = 1;
                break;
            case "ECBPicture":
                maxHintNo = 2;
                break;
            case "GameConsole":
                maxHintNo = 1;
                break;
            case "DiffieHellman":
                maxHintNo = 1;
                break;
            case "Hashes":
                maxHintNo = 1;
                break;
            case "Birthday":
                maxHintNo = 1;
                break;
            case "KnownText":
                maxHintNo = 1;
                break;
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

    public void ScrollToBottomProtocolView() {
        Canvas.ForceUpdateCanvases();
        scrollViewObject.GetComponent<ScrollRect>().verticalNormalizedPosition = 0f;
        Canvas.ForceUpdateCanvases();
    }
}
