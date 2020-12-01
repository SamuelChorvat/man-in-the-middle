using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiffieHellmanControl : MonoBehaviour
{
    public GameObject aliceName;
    public GameObject bobName;

    public GameObject[] stepAlice;
    public GameObject[] stepText;
    public GameObject[] stepBob;

    public GameObject[] stepButtons;

    public Image aliceArrow;
    public Image bobArrow;
    public GameObject aliceArrowHead;
    public GameObject bobArrowHead;

    public void Start() {
        StartDHDemo();
    }

    private void InitializeDemo() {
        aliceName.GetComponent<RectTransform>().localScale = new Vector3(0, 0, 0);
        bobName.GetComponent<RectTransform>().localScale = new Vector3(0, 0, 0);
        aliceName.SetActive(false);
        bobName.SetActive(false);

        for(int i = 0; i < stepButtons.Length; i++) {
            stepAlice[i].GetComponent<RectTransform>().localScale = new Vector3(0, 0, 0);
            stepText[i].GetComponent<RectTransform>().localScale = new Vector3(0, 0, 0);
            stepBob[i].GetComponent<RectTransform>().localScale = new Vector3(0, 0, 0);
            stepAlice[i].SetActive(false);
            stepText[i].SetActive(false);
            stepBob[i].SetActive(false);

            stepButtons[i].GetComponent<RectTransform>().localScale = new Vector3(0, 0, 0);
            stepButtons[i].SetActive(false);
        }

        aliceArrow.fillAmount = 0f;
        aliceArrowHead.SetActive(false);
        bobArrow.fillAmount = 0f;
        bobArrowHead.SetActive(false);
    }

    public void StartDHDemo() {
        InitializeDemo();
        aliceName.SetActive(true);
        bobName.SetActive(true);
        aliceName.GetComponent<DOTweenAnimation>().DOPlay();
        bobName.GetComponent<DOTweenAnimation>().DOPlay();
    }

    public void RevealStepButton(string n) {
        stepButtons[Int32.Parse(n)].SetActive(true);
        stepButtons[Int32.Parse(n)].GetComponent<DOTweenAnimation>().DOPlay();
    }

    public void HideStepButton(string n) {
        stepButtons[Int32.Parse(n)].SetActive(false);
    }

    public void ClickStep(string n) {
        HideStepButton(n);
        stepAlice[Int32.Parse(n)].SetActive(true);
        stepText[Int32.Parse(n)].SetActive(true);
        stepBob[Int32.Parse(n)].SetActive(true);
        if (Int32.Parse(n) == 3) {
            stepText[3].GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            StartCoroutine(AliceArrowShow());
            StartCoroutine(BobArrowShow());
        } else {
            stepAlice[Int32.Parse(n)].GetComponent<DOTweenAnimation>().DOPlay();
            stepText[Int32.Parse(n)].GetComponent<DOTweenAnimation>().DOPlay();
            stepBob[Int32.Parse(n)].GetComponent<DOTweenAnimation>().DOPlay();
        }
    }

    private IEnumerator AliceArrowShow() {
        while (aliceArrow.fillAmount < 1) {
            aliceArrow.fillAmount += 0.05f;
            yield return new WaitForSeconds(0.025f);
        }
        aliceArrowHead.SetActive(true);
        stepBob[3].GetComponent<DOTweenAnimation>().DOPlay();
    }

    private IEnumerator BobArrowShow() {
        while (bobArrow.fillAmount < 1) {
            bobArrow.fillAmount += 0.05f;
            yield return new WaitForSeconds(0.025f);
        }
        bobArrowHead.SetActive(true);
        stepAlice[3].GetComponent<DOTweenAnimation>().DOPlay();
    }
}
