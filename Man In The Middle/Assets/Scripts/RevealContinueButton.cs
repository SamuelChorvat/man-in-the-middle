using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RevealContinueButton : MonoBehaviour
{
    public float delay = 0.001f;
    public GameObject textrev;

    public void Start() {
        //StartReveal();
    }

    public void StartReveal() {
        this.gameObject.SetActive(true);
        StartCoroutine(Reveal());
    }

    private IEnumerator Reveal() {
        this.GetComponent<Image>().fillOrigin = (int)Image.OriginHorizontal.Left;
        while (this.GetComponent<Image>().fillAmount < 1) {
            this.GetComponent<Image>().fillAmount += 0.01f;
            yield return new WaitForSeconds(delay);
        }
        textrev.SetActive(true);
    }

    public void StartDissapear() {
        StartCoroutine(Disapear());
    }

    private IEnumerator Disapear() {
        this.GetComponent<Image>().fillOrigin = (int)Image.OriginHorizontal.Right;
        while (this.GetComponent<Image>().fillAmount > 0) {
            this.GetComponent<Image>().fillAmount -= 0.01f;
            yield return new WaitForSeconds(delay);
        }
        textrev.SetActive(false);
        this.gameObject.SetActive(false);
    }
}
