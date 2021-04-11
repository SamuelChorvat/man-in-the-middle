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

    public GameObject leftImage;
    public GameObject rightImage;
    public GameObject questionObj;
    public GameObject arrowTextObj;

    private bool arrowHeadRevealed = false;

    private bool solved = false;

    public void StartDemo() {
        this.gameObject.SetActive(true);
        questAnim.DORestart();
    }

    public void ResetDemo() {
        StopAllCoroutines();
        arrowHeadRevealed = false;
        solved = false;
        arrowHead.SetActive(false);
        arrowLine.fillAmount = 0f;
        question.SetActive(true);
        oldLeft.SetActive(true);
        newLeft.SetActive(false);
        animal.text = "";

        leftImage.GetComponent<RectTransform>().localScale = new Vector3(0, 0, 0);
        rightImage.GetComponent<RectTransform>().localScale = new Vector3(0, 0, 0);
        questionObj.GetComponent<RectTransform>().localScale = new Vector3(0, 0, 0);
        arrowTextObj.GetComponent<RectTransform>().localScale = new Vector3(0, 0, 0);
    }

    public void ContinueShow() {
        StartCoroutine(ShowArrowLine());
    }

    private IEnumerator ShowArrowLine() {
        arrowLine.fillAmount = 0;
        while (arrowLine.fillAmount < 1f) {
            arrowLine.fillAmount += 0.05f;
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
                animal.text.Equals("panda bear", StringComparison.OrdinalIgnoreCase) ||
                animal.text.Equals("koala", StringComparison.OrdinalIgnoreCase) ||
                animal.text.Equals("koala bear", StringComparison.OrdinalIgnoreCase)) {
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
