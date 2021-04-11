using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RevealContinueButton : MonoBehaviour
{
    public float delay = 0.001f;
    public GameObject textrev;

    private bool revealing = false;
    private bool disapearing = false;

    public void StartReveal() {
        if (!revealing && !disapearing) {
            revealing = true;
            this.GetComponent<Image>().fillAmount = 0f;
            this.gameObject.SetActive(true);
            StartCoroutine(Reveal());
        }
    }

    public void ResetButton() {
        revealing = false;
        disapearing = false;
        textrev.SetActive(false);
        this.GetComponent<Image>().fillAmount = 0f;
        this.gameObject.SetActive(false);
    }

    private IEnumerator Reveal() {
        this.GetComponent<Image>().fillOrigin = (int)Image.OriginHorizontal.Left;
        while (this.GetComponent<Image>().fillAmount < 1) {
            this.GetComponent<Image>().fillAmount += 0.05f;
            yield return new WaitForSeconds(delay);
        }
        textrev.SetActive(true);
        revealing = false;
    }

    public void StartDissapear() {
        if (!disapearing && !revealing) {
            disapearing = true;
            StartCoroutine(Disapear());
        }
    }

    private IEnumerator Disapear() {
        this.GetComponent<Image>().fillOrigin = (int)Image.OriginHorizontal.Right;
        while (this.GetComponent<Image>().fillAmount > 0) {
            this.GetComponent<Image>().fillAmount -= 0.05f;
            yield return new WaitForSeconds(delay);
        }
        this.GetComponent<Image>().fillAmount = 0f;
        textrev.SetActive(false);
        this.gameObject.SetActive(false);
        disapearing = false;
    }
}
