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

    private int step = 0;
    
    public void ShowStep() {
        if (step == 0) {
            aliceText.DOPlay();
            StartCoroutine(ShowAliceArrow());
            step += 1;
        } else if (step == 1) {
            blockImage.DOPlay();
            blockText.DOPlay();
            attackerImage.DOPlay();
            step += 1;
        } else if (step == 2) {
            StartCoroutine(ShowAttackerArrow());
            attackerText1.DOPlay();
            step += 1;
        } else if (step == 3) {
            stepBut.SetActive(false);
            attackerText2.DOPlay();
            step += 1;
;           continueBut.StartReveal();
        }
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
