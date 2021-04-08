using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using TMPro;
using UnityEngine;

public class RotationsCaesarCipher : MonoBehaviour {
    public TextMeshProUGUI cipherText;
    public TextMeshProUGUI alphabetText;
    public TextMeshProUGUI rotationsText;

    public GameObject alphabet;
    public GameObject puzzle;

    public GameObject left;
    public GameObject right;

    public GameObject textAnimated;
    public GameObject textNormal;

    public RevealContinueButton contBut;

    private int currentN = 26;
    private string orgStr = "P JHTL, P ZHD, P JVUXBLYLK";
    private string decStr = "";
    private string[] alphabetOrg = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
    private string[] alphabetRot = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };

    private bool decrypted = false;

    public void StartPuzzle() {
        rotationsText.text = currentN.ToString();
        right.SetActive(false);
        alphabet.SetActive(true);
        puzzle.SetActive(true);
        alphabet.GetComponent<DOTweenAnimation>().DORestart();
        puzzle.GetComponent<DOTweenAnimation>().DORestart();
        StartCoroutine(CheckCorretN());

        textAnimated.SetActive(false);
        textNormal.SetActive(true);
    }

    public void ResetPuzzle() {
        StopAllCoroutines();
        textAnimated.SetActive(true);
        textNormal.SetActive(false);
        currentN = 26;
        orgStr = "P JHTL, P ZHD, P JVUXBLYLK";
        decStr = "";
        alphabetOrg = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
        alphabetRot = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
        decrypted = false;
        cipherText.text = "Decrypt this \"n\" rotations Caesar cipher:\n\n<align=\"center\">" + orgStr;
        left.SetActive(true);
        right.SetActive(true);
    }

    public void PressLeft() {
        if (currentN > 1) {
            currentN -= 1;
            ShiftLeft();
            rotationsText.text = currentN.ToString();
            if (currentN == 1) {
                left.SetActive(false);
            }
        }

        if (currentN < 26) {
            right.SetActive(true);
        }
    }

    public void PressRight() {
        if (currentN < 26) {
            currentN += 1;
            ShiftRight();
            rotationsText.text = currentN.ToString();
            if (currentN == 26) {
                right.SetActive(false);
            }
        }

        if (currentN > 1) {
            left.SetActive(true);
        }
    }

    private void ShiftLeft() {
        string[] temp = new string[] {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"};
        temp[25] = alphabetRot[0];
        for (int i = 0; i<temp.Length-1; i++) {
            temp[i] = alphabetRot[i + 1];
        }
        alphabetRot = temp;
        alphabetText.text = "\n\n\n\n<align=\"center\">A B C D E F G H I J K L M N O P Q R S T U V W X Y Z<align=\"center\">\n" + GetAlphabet();
        ChangeStr();
    }

    private void ShiftRight() {
        string[] temp = new string[] {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"};
        temp[0] = alphabetRot[25];
        for (int i = 1; i < temp.Length; i++) {
            temp[i] = alphabetRot[i-1];
        }
        alphabetRot = temp;
        alphabetText.text = "\n\n\n\n<align=\"center\">A B C D E F G H I J K L M N O P Q R S T U V W X Y Z<align=\"center\">\n" + GetAlphabet();
        ChangeStr();
    }

    public string GetAlphabet() {
        string temp = "";
        temp += alphabetRot[0];
        for (int i = 1; i < alphabetRot.Length; i++) {
            temp += " " + alphabetRot[i];
        }
        return temp;
    }

    public int GetIndex(char val) {
        string tmp = "" + val;
        for (int i = 0; i < alphabetOrg.Length; i++) {
            if (alphabetOrg[i].Equals(tmp)) {
                return i;
            }
        }

        return -1;
    } 

    private void ChangeStr() {
        string tmp = "";
        for (int i = 0; i < orgStr.Length; i++) {
            if (GetIndex(orgStr[i]) != -1) {
                tmp += alphabetRot[GetIndex(orgStr[i])];
            } else {
                tmp += orgStr[i];
            }
        }
        cipherText.text = "Decrypt this \"n\" rotations Caesar cipher:\n\n<align=\"center\">" + tmp;
        decStr = tmp;
    }
    

    private IEnumerator CheckCorretN() {
        while (!decrypted) {
            if (currentN == 7) {
                decrypted = true;
                left.SetActive(false);
                right.SetActive(false);
                cipherText.text = "Decrypt this \"n\" rotations Caesar cipher:\n\n<align=\"center\"><color=green>" + decStr + "</color>";
                contBut.StartReveal();
            }
            yield return new WaitForSeconds(0.05f);
        }
        
    }
}
