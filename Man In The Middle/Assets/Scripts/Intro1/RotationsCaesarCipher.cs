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

    public RevealContinueButton contBut;

    private int currentN = 26;
    private string orgStr = "P JHTL, P ZHD, P JVUXBLYLK";
    private string decStr = "";
    private string[] alphabetOrg = new string[] {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"};
    private string[] alphabetRot = new string[] {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"};

    private bool decrypted = false;

    public void startPuzzle() {
        rotationsText.text = currentN.ToString();
        right.SetActive(false);
        alphabet.SetActive(true);
        puzzle.SetActive(true);
        alphabet.GetComponent<DOTweenAnimation>().DORestart();
        puzzle.GetComponent<DOTweenAnimation>().DORestart();
        StartCoroutine(CheckCorretN());
    }

    public void pressLeft() {
        if (currentN > 1) {
            currentN -= 1;
            shiftLeft();
            rotationsText.text = currentN.ToString();
            if (currentN == 1) {
                left.SetActive(false);
            }
        }

        if (currentN < 26) {
            right.SetActive(true);
        }
    }

    public void pressRight() {
        if (currentN < 26) {
            currentN += 1;
            shiftRight();
            rotationsText.text = currentN.ToString();
            if (currentN == 26) {
                right.SetActive(false);
            }
        }

        if (currentN > 1) {
            left.SetActive(true);
        }
    }

    private void shiftLeft() {
        string[] temp = new string[] {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"};
        temp[25] = alphabetRot[0];
        for (int i = 0; i<temp.Length-1; i++) {
            temp[i] = alphabetRot[i + 1];
        }
        alphabetRot = temp;
        alphabetText.text = "\n\n\n\n<align=\"center\">A B C D E F G H I J K L M N O P Q R S T U V W X Y Z<align=\"center\">\n" + getAlphabet();
        changeStr();
    }

    private void shiftRight() {
        string[] temp = new string[] {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"};
        temp[0] = alphabetRot[25];
        for (int i = 1; i < temp.Length; i++) {
            temp[i] = alphabetRot[i-1];
        }
        alphabetRot = temp;
        alphabetText.text = "\n\n\n\n<align=\"center\">A B C D E F G H I J K L M N O P Q R S T U V W X Y Z<align=\"center\">\n" + getAlphabet();
        changeStr();
    }

    private string getAlphabet() {
        string temp = "";
        temp += alphabetRot[0];
        for (int i = 1; i < alphabetRot.Length; i++) {
            temp += " " + alphabetRot[i];
        }
        return temp;
    }

    private int getIndex(char val) {
        string tmp = "" + val;
        for (int i = 0; i < alphabetOrg.Length; i++) {
            if (alphabetOrg[i].Equals(tmp)) {
                return i;
            }
        }

        return -1;
    } 

    private void changeStr() {
        string tmp = "";
        for (int i = 0; i < orgStr.Length; i++) {
            if (getIndex(orgStr[i]) != -1) {
                tmp += alphabetRot[getIndex(orgStr[i])];
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
