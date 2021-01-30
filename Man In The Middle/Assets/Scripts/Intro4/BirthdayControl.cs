using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BirthdayControl : MonoBehaviour
{
    public GameObject birthdayDemo;
    public GameObject[] peopleIcon;
    public TextMeshProUGUI noOfPeople;
    public TextMeshProUGUI probability;
    public GameObject explanation;
    public RevealContinueButton but;
    public GameObject askButton;

    private readonly int maxPeople = 42;
    private int currentNo = 1;

    public void ShowDemo() {
        ResetDemo();
        birthdayDemo.SetActive(true);
        birthdayDemo.GetComponent<DOTweenAnimation>().DORestart();
    }

    public void ResetDemo() {
        currentNo = 1;
        askButton.SetActive(true);
        probability.text = "0%";
        noOfPeople.text = "0";
        for (int i = 0; i < peopleIcon.Length; i++) {
            peopleIcon[i].SetActive(false);
        }
        explanation.SetActive(false);
    }

    public void Ask() {
        if (currentNo <= maxPeople) {
            peopleIcon[currentNo - 1].SetActive(true);
            noOfPeople.text = currentNo.ToString();
            if (currentNo > 1) {
                int pairs = (currentNo * (currentNo - 1)) / 2;
                double bdayProb = (double) 364 / 365;
                double pb1 = Math.Pow(bdayProb, pairs);
                pb1 = 1 - pb1;
                int result = (int)(pb1 * 100);
                probability.text = result.ToString() + "%";
            }

            if (currentNo == 23) {
                explanation.SetActive(true);
                explanation.GetComponent<DOTweenAnimation>().DORestart();
                but.StartReveal();
            }

            currentNo += 1;
        }

        if (currentNo > maxPeople) {
            askButton.SetActive(false);
        }
    }

}
