using DG.Tweening;
using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FrequencyAnalysisController : MonoBehaviour {
    [Tooltip("Reveal")]
    public DOTweenAnimation[] revealAnims;
    public GameObject[] revealObjects;

    [Tooltip("Letters")]
    public TextMeshProUGUI a;
    public TextMeshProUGUI b;
    public TextMeshProUGUI c;
    public TextMeshProUGUI d;
    public TextMeshProUGUI e;
    public TextMeshProUGUI f;
    public TextMeshProUGUI g;
    public TextMeshProUGUI h;
    public TextMeshProUGUI i;
    public TextMeshProUGUI j;
    public TextMeshProUGUI k;
    public TextMeshProUGUI l;
    public TextMeshProUGUI m;
    public TextMeshProUGUI n;
    public TextMeshProUGUI o;
    public TextMeshProUGUI p;
    public TextMeshProUGUI q;
    public TextMeshProUGUI r;
    public TextMeshProUGUI s;
    public TextMeshProUGUI t;
    public TextMeshProUGUI u;
    public TextMeshProUGUI v;
    public TextMeshProUGUI w;
    public TextMeshProUGUI x;
    public TextMeshProUGUI y;
    public TextMeshProUGUI z;

    [Tooltip("Inputs")]
    public TMP_InputField[] inputs;

    [Tooltip("Letter Objects")]
    public GameObject[] letterObjects;

    [Tooltip("Cipher")]
    public TextMeshProUGUI cipherText;

    [Tooltip("Other")]
    public GameObject freqBut;
    public GameObject subBut;
    public GameObject freqWid;
    public GameObject subWid;
    public RevealContinueButton but;

    private string orgCipherText;
    private bool solved = false;
    private int correct = 0;
    private string[] alphabet = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "Q", "K", "L", "M", "N", "O", "P", "R", "S", "T", "U", "W", "V", "X", "Y", "Z" };

    public void ShowPuzzle() {
        orgCipherText = cipherText.text;
        for (int i = 0; i < revealObjects.Length; i++) {
            revealObjects[i].SetActive(true);
        }

        for (int i = 0; i < revealAnims.Length; i++) {
            revealAnims[i].DORestart();
        }

        InitializeSubs();
    }

    public void StartSubstitue() {
        StartCoroutine(Substitute());
        StartCoroutine(CheckSolution());
    }

    private IEnumerator Substitute() {
        while (!solved) {
            string temp = "";
            for (int ii = 0; ii < orgCipherText.Length; ii++) {
                if (IsLetter(orgCipherText[ii])) {
                    string toSub = orgCipherText[ii].ToString();
                    switch (toSub) {
                        case "A":
                            temp += a.text.ToUpper();
                            break;
                        case "a":
                            temp += a.text.ToLower();
                            break;
                        case "B":
                            temp += b.text.ToUpper();
                            break;
                        case "b":
                            temp += b.text.ToLower();
                            break;
                        case "C":
                            temp += c.text.ToUpper();
                            break;
                        case "c":
                            temp += c.text.ToLower();
                            break;
                        case "D":
                            temp += d.text.ToUpper();
                            break;
                        case "d":
                            temp += d.text.ToLower();
                            break;
                        case "E":
                            temp += e.text.ToUpper();
                            break;
                        case "e":
                            temp += e.text.ToLower();
                            break;
                        case "F":
                            temp += f.text.ToUpper();
                            break;
                        case "f":
                            temp += f.text.ToLower();
                            break;
                        case "G":
                            temp += g.text.ToUpper();
                            break;
                        case "g":
                            temp += g.text.ToLower();
                            break;
                        case "H":
                            temp += h.text.ToUpper();
                            break;
                        case "h":
                            temp += h.text.ToLower();
                            break;
                        case "I":
                            temp += i.text.ToUpper();
                            break;
                        case "i":
                            temp += i.text.ToLower();
                            break;
                        case "J":
                            temp += j.text.ToUpper();
                            break;
                        case "j":
                            temp += j.text.ToLower();
                            break;
                        case "K":
                            temp += k.text.ToUpper();
                            break;
                        case "k":
                            temp += k.text.ToLower();
                            break;
                        case "L":
                            temp += l.text.ToUpper();
                            break;
                        case "l":
                            temp += l.text.ToLower();
                            break;
                        case "M":
                            temp += m.text.ToUpper();
                            break;
                        case "m":
                            temp += m.text.ToLower();
                            break;
                        case "N":
                            temp += n.text.ToUpper();
                            break;
                        case "n":
                            temp += n.text.ToLower();
                            break;
                        case "O":
                            temp += o.text.ToUpper();
                            break;
                        case "o":
                            temp += o.text.ToLower();
                            break;
                        case "P":
                            temp += p.text.ToUpper();
                            break;
                        case "p":
                            temp += p.text.ToLower();
                            break;
                        case "Q":
                            temp += q.text.ToUpper();
                            break;
                        case "q":
                            temp += q.text.ToLower();
                            break;
                        case "R":
                            temp += r.text.ToUpper();
                            break;
                        case "r":
                            temp += r.text.ToLower();
                            break;
                        case "S":
                            temp += s.text.ToUpper();
                            break;
                        case "s":
                            temp += s.text.ToLower();
                            break;
                        case "T":
                            temp += t.text.ToUpper();
                            break;
                        case "t":
                            temp += t.text.ToLower();
                            break;
                        case "U":
                            temp += u.text.ToUpper();
                            break;
                        case "u":
                            temp += u.text.ToLower();
                            break;
                        case "V":
                            temp += v.text.ToUpper();
                            break;
                        case "v":
                            temp += v.text.ToLower();
                            break;
                        case "W":
                            temp += w.text.ToUpper();
                            break;
                        case "w":
                            temp += w.text.ToLower();
                            break;
                        case "X":
                            temp += x.text.ToUpper();
                            break;
                        case "x":
                            temp += x.text.ToLower();
                            break;
                        case "Y":
                            temp += y.text.ToUpper();
                            break;
                        case "y":
                            temp += y.text.ToLower();
                            break;
                        case "Z":
                            temp += z.text.ToUpper();
                            break;
                        case "z":
                            temp += z.text.ToLower();
                            break;
                    }

                } else {
                    temp += orgCipherText[ii];
                }
            }
            cipherText.text = temp;
            if (correct == 26) {
                solved = true;
                Solved();
            }
            yield return new WaitForSeconds(0.5f);
        }

    }

    private bool IsLetter(char toCheck) {
        string temp = toCheck.ToString();
        return temp.Equals("a", StringComparison.OrdinalIgnoreCase) ||
               temp.Equals("b", StringComparison.OrdinalIgnoreCase) ||
               temp.Equals("c", StringComparison.OrdinalIgnoreCase) ||
               temp.Equals("d", StringComparison.OrdinalIgnoreCase) ||
               temp.Equals("e", StringComparison.OrdinalIgnoreCase) ||
               temp.Equals("f", StringComparison.OrdinalIgnoreCase) ||
               temp.Equals("g", StringComparison.OrdinalIgnoreCase) ||
               temp.Equals("h", StringComparison.OrdinalIgnoreCase) ||
               temp.Equals("i", StringComparison.OrdinalIgnoreCase) ||
               temp.Equals("j", StringComparison.OrdinalIgnoreCase) ||
               temp.Equals("k", StringComparison.OrdinalIgnoreCase) ||
               temp.Equals("l", StringComparison.OrdinalIgnoreCase) ||
               temp.Equals("m", StringComparison.OrdinalIgnoreCase) ||
               temp.Equals("n", StringComparison.OrdinalIgnoreCase) ||
               temp.Equals("o", StringComparison.OrdinalIgnoreCase) ||
               temp.Equals("p", StringComparison.OrdinalIgnoreCase) ||
               temp.Equals("q", StringComparison.OrdinalIgnoreCase) ||
               temp.Equals("r", StringComparison.OrdinalIgnoreCase) ||
               temp.Equals("s", StringComparison.OrdinalIgnoreCase) ||
               temp.Equals("t", StringComparison.OrdinalIgnoreCase) ||
               temp.Equals("u", StringComparison.OrdinalIgnoreCase) ||
               temp.Equals("v", StringComparison.OrdinalIgnoreCase) ||
               temp.Equals("w", StringComparison.OrdinalIgnoreCase) ||
               temp.Equals("x", StringComparison.OrdinalIgnoreCase) ||
               temp.Equals("y", StringComparison.OrdinalIgnoreCase) ||
               temp.Equals("z", StringComparison.OrdinalIgnoreCase);
    }

    public void InitializeSubs() {
        for (int i = 0; i < inputs.Length; i++) {
            inputs[i].text = alphabet[i];
        }
    }
    private IEnumerator CheckSolution() {
        while (!solved) {
            int tempCorrect = 0;
            for(int i = 0; i < letterObjects.Length; i++) {
                switch (letterObjects[i].name) {
                    case "A":
                        if (letterObjects[i].transform.Find("Input").GetComponent<TMP_InputField>().text.Equals("F", StringComparison.OrdinalIgnoreCase)) {
                            letterObjects[i].transform.Find("Input").GetComponent<TMP_InputField>().interactable = false;
                            letterObjects[i].transform.Find("Input").GetComponent<Image>().enabled = false;
                            letterObjects[i].transform.Find("Input").Find("Text Area").Find("Text").GetComponent<TextMeshProUGUI>().color = Color.green;
                            tempCorrect += 1;
                        }
                        break;
                    case "B":
                        if (letterObjects[i].transform.Find("Input").GetComponent<TMP_InputField>().text.Equals("G", StringComparison.OrdinalIgnoreCase)) {
                            letterObjects[i].transform.Find("Input").GetComponent<TMP_InputField>().interactable = false;
                            letterObjects[i].transform.Find("Input").GetComponent<Image>().enabled = false;
                            letterObjects[i].transform.Find("Input").Find("Text Area").Find("Text").GetComponent<TextMeshProUGUI>().color = Color.green;
                            tempCorrect += 1;
                        }
                        break;
                    case "C":
                        if (letterObjects[i].transform.Find("Input").GetComponent<TMP_InputField>().text.Equals("N", StringComparison.OrdinalIgnoreCase)) {
                            letterObjects[i].transform.Find("Input").GetComponent<TMP_InputField>().interactable = false;
                            letterObjects[i].transform.Find("Input").GetComponent<Image>().enabled = false;
                            letterObjects[i].transform.Find("Input").Find("Text Area").Find("Text").GetComponent<TextMeshProUGUI>().color = Color.green;
                            tempCorrect += 1;
                        }
                        break;
                    case "D":
                        if (letterObjects[i].transform.Find("Input").GetComponent<TMP_InputField>().text.Equals("O", StringComparison.OrdinalIgnoreCase)) {
                            letterObjects[i].transform.Find("Input").GetComponent<TMP_InputField>().interactable = false;
                            letterObjects[i].transform.Find("Input").GetComponent<Image>().enabled = false;
                            letterObjects[i].transform.Find("Input").Find("Text Area").Find("Text").GetComponent<TextMeshProUGUI>().color = Color.green;
                            tempCorrect += 1;
                        }
                        break;
                    case "E":
                        if (letterObjects[i].transform.Find("Input").GetComponent<TMP_InputField>().text.Equals("P", StringComparison.OrdinalIgnoreCase)) {
                            letterObjects[i].transform.Find("Input").GetComponent<TMP_InputField>().interactable = false;
                            letterObjects[i].transform.Find("Input").GetComponent<Image>().enabled = false;
                            letterObjects[i].transform.Find("Input").Find("Text Area").Find("Text").GetComponent<TextMeshProUGUI>().color = Color.green;
                            tempCorrect += 1;
                        }
                        break;
                    case "F":
                        if (letterObjects[i].transform.Find("Input").GetComponent<TMP_InputField>().text.Equals("Q", StringComparison.OrdinalIgnoreCase)) {
                            letterObjects[i].transform.Find("Input").GetComponent<TMP_InputField>().interactable = false;
                            letterObjects[i].transform.Find("Input").GetComponent<Image>().enabled = false;
                            letterObjects[i].transform.Find("Input").Find("Text Area").Find("Text").GetComponent<TextMeshProUGUI>().color = Color.green;
                            tempCorrect += 1;
                        }
                        break;
                    case "G":
                        if (letterObjects[i].transform.Find("Input").GetComponent<TMP_InputField>().text.Equals("R", StringComparison.OrdinalIgnoreCase)) {
                            letterObjects[i].transform.Find("Input").GetComponent<TMP_InputField>().interactable = false;
                            letterObjects[i].transform.Find("Input").GetComponent<Image>().enabled = false;
                            letterObjects[i].transform.Find("Input").Find("Text Area").Find("Text").GetComponent<TextMeshProUGUI>().color = Color.green;
                            tempCorrect += 1;
                        }
                        break;
                    case "H":
                        if (letterObjects[i].transform.Find("Input").GetComponent<TMP_InputField>().text.Equals("S", StringComparison.OrdinalIgnoreCase)) {
                            letterObjects[i].transform.Find("Input").GetComponent<TMP_InputField>().interactable = false;
                            letterObjects[i].transform.Find("Input").GetComponent<Image>().enabled = false;
                            letterObjects[i].transform.Find("Input").Find("Text Area").Find("Text").GetComponent<TextMeshProUGUI>().color = Color.green;
                            tempCorrect += 1;
                        }
                        break;
                    case "I":
                        if (letterObjects[i].transform.Find("Input").GetComponent<TMP_InputField>().text.Equals("T", StringComparison.OrdinalIgnoreCase)) {
                            letterObjects[i].transform.Find("Input").GetComponent<TMP_InputField>().interactable = false;
                            letterObjects[i].transform.Find("Input").GetComponent<Image>().enabled = false;
                            letterObjects[i].transform.Find("Input").Find("Text Area").Find("Text").GetComponent<TextMeshProUGUI>().color = Color.green;
                            tempCorrect += 1;
                        }
                        break;
                    case "J":
                        if (letterObjects[i].transform.Find("Input").GetComponent<TMP_InputField>().text.Equals("U", StringComparison.OrdinalIgnoreCase)) {
                            letterObjects[i].transform.Find("Input").GetComponent<TMP_InputField>().interactable = false;
                            letterObjects[i].transform.Find("Input").GetComponent<Image>().enabled = false;
                            letterObjects[i].transform.Find("Input").Find("Text Area").Find("Text").GetComponent<TextMeshProUGUI>().color = Color.green;
                            tempCorrect += 1;
                        }
                        break;
                    case "K":
                        if (letterObjects[i].transform.Find("Input").GetComponent<TMP_InputField>().text.Equals("V", StringComparison.OrdinalIgnoreCase)) {
                            letterObjects[i].transform.Find("Input").GetComponent<TMP_InputField>().interactable = false;
                            letterObjects[i].transform.Find("Input").GetComponent<Image>().enabled = false;
                            letterObjects[i].transform.Find("Input").Find("Text Area").Find("Text").GetComponent<TextMeshProUGUI>().color = Color.green;
                            tempCorrect += 1;
                        }
                        break;
                    case "L":
                        if (letterObjects[i].transform.Find("Input").GetComponent<TMP_InputField>().text.Equals("W", StringComparison.OrdinalIgnoreCase)) {
                            letterObjects[i].transform.Find("Input").GetComponent<TMP_InputField>().interactable = false;
                            letterObjects[i].transform.Find("Input").GetComponent<Image>().enabled = false;
                            letterObjects[i].transform.Find("Input").Find("Text Area").Find("Text").GetComponent<TextMeshProUGUI>().color = Color.green;
                            tempCorrect += 1;
                        }
                        break;
                    case "M":
                        if (letterObjects[i].transform.Find("Input").GetComponent<TMP_InputField>().text.Equals("A", StringComparison.OrdinalIgnoreCase)) {
                            letterObjects[i].transform.Find("Input").GetComponent<TMP_InputField>().interactable = false;
                            letterObjects[i].transform.Find("Input").GetComponent<Image>().enabled = false;
                            letterObjects[i].transform.Find("Input").Find("Text Area").Find("Text").GetComponent<TextMeshProUGUI>().color = Color.green;
                            tempCorrect += 1;
                        }
                        break;
                    case "N":
                        if (letterObjects[i].transform.Find("Input").GetComponent<TMP_InputField>().text.Equals("D", StringComparison.OrdinalIgnoreCase)) {
                            letterObjects[i].transform.Find("Input").GetComponent<TMP_InputField>().interactable = false;
                            letterObjects[i].transform.Find("Input").GetComponent<Image>().enabled = false;
                            letterObjects[i].transform.Find("Input").Find("Text Area").Find("Text").GetComponent<TextMeshProUGUI>().color = Color.green;
                            tempCorrect += 1;
                        }
                        break;
                    case "O":
                        if (letterObjects[i].transform.Find("Input").GetComponent<TMP_InputField>().text.Equals("E", StringComparison.OrdinalIgnoreCase)) {
                            letterObjects[i].transform.Find("Input").GetComponent<TMP_InputField>().interactable = false;
                            letterObjects[i].transform.Find("Input").GetComponent<Image>().enabled = false;
                            letterObjects[i].transform.Find("Input").Find("Text Area").Find("Text").GetComponent<TextMeshProUGUI>().color = Color.green;
                            tempCorrect += 1;
                        }
                        break;
                    case "P":
                        if (letterObjects[i].transform.Find("Input").GetComponent<TMP_InputField>().text.Equals("H", StringComparison.OrdinalIgnoreCase)) {
                            letterObjects[i].transform.Find("Input").GetComponent<TMP_InputField>().interactable = false;
                            letterObjects[i].transform.Find("Input").GetComponent<Image>().enabled = false;
                            letterObjects[i].transform.Find("Input").Find("Text Area").Find("Text").GetComponent<TextMeshProUGUI>().color = Color.green;
                            tempCorrect += 1;
                        }
                        break;
                    case "Q":
                        if (letterObjects[i].transform.Find("Input").GetComponent<TMP_InputField>().text.Equals("I", StringComparison.OrdinalIgnoreCase)) {
                            letterObjects[i].transform.Find("Input").GetComponent<TMP_InputField>().interactable = false;
                            letterObjects[i].transform.Find("Input").GetComponent<Image>().enabled = false;
                            letterObjects[i].transform.Find("Input").Find("Text Area").Find("Text").GetComponent<TextMeshProUGUI>().color = Color.green;
                            tempCorrect += 1;
                        }
                        break;
                    case "R":
                        if (letterObjects[i].transform.Find("Input").GetComponent<TMP_InputField>().text.Equals("J", StringComparison.OrdinalIgnoreCase)) {
                            letterObjects[i].transform.Find("Input").GetComponent<TMP_InputField>().interactable = false;
                            letterObjects[i].transform.Find("Input").GetComponent<Image>().enabled = false;
                            letterObjects[i].transform.Find("Input").Find("Text Area").Find("Text").GetComponent<TextMeshProUGUI>().color = Color.green;
                            tempCorrect += 1;
                        }
                        break;
                    case "S":
                        if (letterObjects[i].transform.Find("Input").GetComponent<TMP_InputField>().text.Equals("K", StringComparison.OrdinalIgnoreCase)) {
                            letterObjects[i].transform.Find("Input").GetComponent<TMP_InputField>().interactable = false;
                            letterObjects[i].transform.Find("Input").GetComponent<Image>().enabled = false;
                            letterObjects[i].transform.Find("Input").Find("Text Area").Find("Text").GetComponent<TextMeshProUGUI>().color = Color.green;
                            tempCorrect += 1;
                        }
                        break;
                    case "T":
                        if (letterObjects[i].transform.Find("Input").GetComponent<TMP_InputField>().text.Equals("L", StringComparison.OrdinalIgnoreCase)) {
                            letterObjects[i].transform.Find("Input").GetComponent<TMP_InputField>().interactable = false;
                            letterObjects[i].transform.Find("Input").GetComponent<Image>().enabled = false;
                            letterObjects[i].transform.Find("Input").Find("Text Area").Find("Text").GetComponent<TextMeshProUGUI>().color = Color.green;
                            tempCorrect += 1;
                        }
                        break;
                    case "U":
                        if (letterObjects[i].transform.Find("Input").GetComponent<TMP_InputField>().text.Equals("M", StringComparison.OrdinalIgnoreCase)) {
                            letterObjects[i].transform.Find("Input").GetComponent<TMP_InputField>().interactable = false;
                            letterObjects[i].transform.Find("Input").GetComponent<Image>().enabled = false;
                            letterObjects[i].transform.Find("Input").Find("Text Area").Find("Text").GetComponent<TextMeshProUGUI>().color = Color.green;
                            tempCorrect += 1;
                        }
                        break;
                    case "V":
                        if (letterObjects[i].transform.Find("Input").GetComponent<TMP_InputField>().text.Equals("X", StringComparison.OrdinalIgnoreCase)) {
                            letterObjects[i].transform.Find("Input").GetComponent<TMP_InputField>().interactable = false;
                            letterObjects[i].transform.Find("Input").GetComponent<Image>().enabled = false;
                            letterObjects[i].transform.Find("Input").Find("Text Area").Find("Text").GetComponent<TextMeshProUGUI>().color = Color.green;
                            tempCorrect += 1;
                        }
                        break;
                    case "W":
                        if (letterObjects[i].transform.Find("Input").GetComponent<TMP_InputField>().text.Equals("Y", StringComparison.OrdinalIgnoreCase)) {
                            letterObjects[i].transform.Find("Input").GetComponent<TMP_InputField>().interactable = false;
                            letterObjects[i].transform.Find("Input").GetComponent<Image>().enabled = false;
                            letterObjects[i].transform.Find("Input").Find("Text Area").Find("Text").GetComponent<TextMeshProUGUI>().color = Color.green;
                            tempCorrect += 1;
                        }
                        break;
                    case "X":
                        if (letterObjects[i].transform.Find("Input").GetComponent<TMP_InputField>().text.Equals("Z", StringComparison.OrdinalIgnoreCase)) {
                            letterObjects[i].transform.Find("Input").GetComponent<TMP_InputField>().interactable = false;
                            letterObjects[i].transform.Find("Input").GetComponent<Image>().enabled = false;
                            letterObjects[i].transform.Find("Input").Find("Text Area").Find("Text").GetComponent<TextMeshProUGUI>().color = Color.green;
                            tempCorrect += 1;
                        }
                        break;
                    case "Y":
                        if (letterObjects[i].transform.Find("Input").GetComponent<TMP_InputField>().text.Equals("B", StringComparison.OrdinalIgnoreCase)) {
                            letterObjects[i].transform.Find("Input").GetComponent<TMP_InputField>().interactable = false;
                            letterObjects[i].transform.Find("Input").GetComponent<Image>().enabled = false;
                            letterObjects[i].transform.Find("Input").Find("Text Area").Find("Text").GetComponent<TextMeshProUGUI>().color = Color.green;
                            tempCorrect += 1;
                        }
                        break;
                    case "Z":
                        if (letterObjects[i].transform.Find("Input").GetComponent<TMP_InputField>().text.Equals("C", StringComparison.OrdinalIgnoreCase)) {
                            letterObjects[i].transform.Find("Input").GetComponent<TMP_InputField>().interactable = false;
                            letterObjects[i].transform.Find("Input").GetComponent<Image>().enabled = false;
                            letterObjects[i].transform.Find("Input").Find("Text Area").Find("Text").GetComponent<TextMeshProUGUI>().color = Color.green;
                            tempCorrect += 1;
                        }
                        break;

                }
            }
            correct = tempCorrect;
            yield return new WaitForSeconds(0.5f);
        }
        
    }

    private void Solved() {
        cipherText.text = "<color=green>" + cipherText.text;
        freqBut.SetActive(false);
        freqWid.SetActive(false);
        subBut.SetActive(false);
        subWid.SetActive(false);
        but.StartReveal();
    }
}
