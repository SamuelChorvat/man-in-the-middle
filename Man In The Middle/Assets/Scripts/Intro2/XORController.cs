using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class XORController : MonoBehaviour
{
    public DOTweenAnimation[] showPuzzleAnims;
    public RevealContinueButton but;

    public GameObject puzzleObject;

    private int correct = 0;

    
    public void ShowPuzzle() {
        puzzleObject.SetActive(true);
        for (int i = 0; i < showPuzzleAnims.Length; i++) {
            showPuzzleAnims[i].DORestart();
        }
    }

    public void addCorrect() {
        correct += 1;

        if (correct == 8) {
            but.StartReveal();
        }
    }
}
