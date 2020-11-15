﻿using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DESBruteforceControl : MonoBehaviour
{
    public GameObject demo;
    public GameObject[] bruteObj;
    public DOTweenAnimation[] bruteAnim;
    public RevealContinueButton[] butAnim;
    public RevealContinueButton but;

    private int forced = 0;

    public void ShowBruteForce() {
        demo.SetActive(true);
        for (int i = 0; i < bruteObj.Length; i++) {
            bruteObj[i].SetActive(true);
            bruteAnim[i].DORestart();
        }

        StartCoroutine(ShowButtons());
    }

    private IEnumerator ShowButtons() {
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < bruteObj.Length; i++) {
            butAnim[i].StartReveal();
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void ForcedDes() {
        forced += 1;
        if (forced > 4) {
            but.StartReveal();
        }
    }
}
