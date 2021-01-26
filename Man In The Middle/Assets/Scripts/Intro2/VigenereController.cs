using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VigenereController : MonoBehaviour
{
    public DOTweenAnimation[] showPuzzleAnims;
    public RevealContinueButton but;

    public GameObject puzzleObject;
    public GameObject vigenereButton;

    public GameObject tableWindow;
    public DOTweenAnimation tableWindowAnim;

    public VigenereLetter[] letters;

    private int correct = 0;

    
    public void ShowPuzzle() {
        puzzleObject.SetActive(true);
        for (int i = 0; i < showPuzzleAnims.Length; i++) {
            showPuzzleAnims[i].DORestart();
        }
    }

    public void ResetPuzzle() {
        StopAllCoroutines();
        correct = 0;
        CloseTableWindow();
        for (int i = 0; i < letters.Length; i++) {
            letters[i].ResetLetter();
        }
        puzzleObject.SetActive(false);
        vigenereButton.SetActive(true);
    }

    public void OpenTableWindow() {
        tableWindow.SetActive(true);
        tableWindowAnim.DORestart();
    }

    public void CloseTableWindow() {
        tableWindow.SetActive(false);
    }

    public void addCorrect() {
        correct += 1;

        if (correct == 8) {
            vigenereButton.SetActive(false);
            but.StartReveal();
        }
    }
}
