using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KnownDemoControl : MonoBehaviour
{
    public RevealContinueButton continueBut;
    public GameObject stepBut;

    //Step 1
    public Image aliceArrow;
    public DOTweenAnimation aliceText;

    //Step 2
    public DOTweenAnimation blockImage;
    public DOTweenAnimation blockText;
    public DOTweenAnimation attackerImage;

    //Step 3
    public Image attackerArrow;
    public DOTweenAnimation attackerText1;
       
    //Step 4
    public DOTweenAnimation attackerText2;

    //Reset
    public GameObject knownDemo;
    public GameObject attackerRes;
    public GameObject blockImageRes;
    public GameObject blockTextRes;
    public GameObject aliceTextRes;
    public GameObject attackerText1Res;
    public GameObject attackerText2Res;


    public int step = 0;
    
    public void ShowStep() {
        if (step == 0) {
            aliceText.DORestart();
            StartCoroutine(ShowAliceArrow());
            step += 1;
        } else if (step == 1) {
            blockImage.DORestart();
            blockText.DORestart();
            attackerImage.DORestart();
            step += 1;
        } else if (step == 2) {
            StartCoroutine(ShowAttackerArrow());
            attackerText1.DORestart();
            step += 1;
        } else if (step == 3) {
            stepBut.SetActive(false);
            attackerText2.DORestart();
            step += 1;
;           continueBut.StartReveal();
        }
    }

    public void ResetDemo() {
        StopAllCoroutines();
        step = 0;
        stepBut.SetActive(true);
        knownDemo.transform.localScale = new Vector3(0, 0, 0);
        attackerRes.transform.localScale = new Vector3(0, 0, 0);
        blockImageRes.transform.localScale = new Vector3(0, 0, 0);
        blockTextRes.transform.localScale = new Vector3(0, 0, 0);
        aliceTextRes.transform.localScale = new Vector3(0, 0, 0);
        attackerText1Res.transform.localScale = new Vector3(0, 0, 0);
        attackerText2Res.transform.localScale = new Vector3(0, 0, 0);

        aliceArrow.fillAmount = 0f;
        attackerArrow.fillAmount = 0f;
    }

    private IEnumerator ShowAliceArrow() {
        while (aliceArrow.fillAmount < 1) {
            aliceArrow.fillAmount += 0.05f;
            yield return new WaitForSeconds(0.01f);
        }
    }

    private IEnumerator ShowAttackerArrow() {
        while (attackerArrow.fillAmount < 1) {
            attackerArrow.fillAmount += 0.05f;
            yield return new WaitForSeconds(0.01f);
        }
    }
}
