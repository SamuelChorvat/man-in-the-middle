using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EBCDemoControl : MonoBehaviour {
    public DOTweenAnimation questAnim;
    public DOTweenAnimation arrowText;
    public DOTweenAnimation rightAnim;

    public Image arrowLine;

    public GameObject arrowHead;

    public GameObject question;
    public TMP_InputField animal;
    public GameObject oldLeft;
    public GameObject newLeft;

    public RevealContinueButton but;

    private bool arrowHeadRevealed = false;

    private bool solved = false;

    public void StartDemo() {
        this.gameObject.SetActive(true);
        questAnim.DORestart();
    }

    public void ContinueShow() {
        StartCoroutine(ShowArrowLine());
    }

    private IEnumerator ShowArrowLine() {
        arrowLine.fillAmount = 0;
        while (arrowLine.fillAmount < 1f) {
            arrowLine.fillAmount += 0.01f;
            if (!arrowHeadRevealed && arrowLine.fillAmount > 0.87) {
                arrowHead.SetActive(true);
                arrowHeadRevealed = true;
                arrowText.DORestart();
            }
            yield return new WaitForSeconds(0.005f);
        }
        rightAnim.DORestart();
        StartCoroutine(CheckSolution());
    }

    private IEnumerator CheckSolution() {
        while (!solved) {
            if (animal.text.Equals("panda", StringComparison.OrdinalIgnoreCase) ||
                animal.text.Equals("bear", StringComparison.OrdinalIgnoreCase) ||
                animal.text.Equals("panda bear", StringComparison.OrdinalIgnoreCase)) {
                solved = true;
                question.SetActive(false);
                oldLeft.SetActive(false);
                newLeft.SetActive(true);
                but.StartReveal();
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
}
