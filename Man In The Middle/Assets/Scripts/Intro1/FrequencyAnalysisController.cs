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
    public FrequenciesWindowController freqCont;
    public SubstituteWindowController subCont;

    [Tooltip("Freq Letters")]
    public FrequencyLetter[] freqLetters;

    private string orgCipherText;
    private bool solved = false;
    private int correct = 0;
    private string[] alphabet = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "Q", "K", "L", "M", "N", "O", "P", "R", "S", "T", "U", "W", "V", "X", "Y", "Z" };

    private bool orgSet = false;

    public void ShowPuzzle() {
        if (!orgSet) {
            orgCipherText = cipherText.text;
            orgSet = true;
        }
        
        for (int i = 0; i < revealObjects.Length; i++) {
            revealObjects[i].SetActive(true);
        }

        for (int i = 0; i < revealAnims.Length; i++) {
            revealAnims[i].DORestart();
        }

        InitializeSubs();
    }

    public void ResetPuzzle() {
        StopAllCoroutines();
        if (orgSet) {
            cipherText.text = orgCipherText;
        }
        solved = false;
        correct = 0;
        alphabet = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "Q", "K", "L", "M", "N", "O", "P", "R", "S", "T", "U", "W", "V", "X", "Y", "Z" };
        freqCont.CloseWindow();
        subCont.CloseWindow();
        freqBut.SetActive(true);
        subBut.SetActive(true);
        InitializeSubs();

        for (int i = 0; i < revealObjects.Length; i++) {
            revealObjects[i].SetActive(false);
        }

        for (int i = 0; i < freqLetters.Length; i++) {
            freqLetters[i].ResetLetter();
        }
    }

    public void StartSubstitue() {
        StartCoroutine(Substitute());
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

    private void SubstituteLast() {
        if (solved) {
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

    public void IncreaseCorrect() {
        this.correct += 1;
    }

    private void Solved() {
        SubstituteLast();
        cipherText.text = "<color=green>" + cipherText.text;
        freqBut.SetActive(false);
        freqWid.SetActive(false);
        subBut.SetActive(false);
        subWid.SetActive(false);
        but.StartReveal();
    }
}
