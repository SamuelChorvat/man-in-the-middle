using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleReveal : MonoBehaviour
{
    private Text toFlash;

    public float delay;
    public GameObject titleBackground;
    public DOTweenAnimation anim;

    private bool red = false;

    void Awake()
    {
        toFlash = GetComponent<Text>();
        delay = 0.25f;
    }

    private void Start() {
        StartFlashing();
    }

    private IEnumerator TextFlash() {
        while (!red) {
            if (toFlash.text.Equals("MAN IN THE MIDDLE")) {
                toFlash.text = "<COLOR=RED>MAN</COLOR> IN THE MIDDLE";
                red = true;
                titleBackground.SetActive(true);
                anim.DOPlay();
            } else if (toFlash.text.Equals("<COLOR=RED>MAN</COLOR> IN THE MIDDLE")) {
                toFlash.text = "MAN IN THE MIDDLE";
            }

            yield return new WaitForSeconds(delay);
        }
    }

    public void StartFlashing() {
        StartCoroutine(TextFlash());
    }
}
