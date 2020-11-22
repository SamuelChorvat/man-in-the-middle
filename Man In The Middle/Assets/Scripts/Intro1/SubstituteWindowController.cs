using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubstituteWindowController : MonoBehaviour
{
    public GameObject frequenciesButton;
    public GameObject substituteButton;

    public GameObject window;

    public DOTweenAnimation subAnim;

    public void CloseWindow() {
        window.SetActive(false);
        window.transform.localScale = new Vector3(0, 0, 0);
        frequenciesButton.SetActive(true);
        substituteButton.SetActive(true);
    }

    public void OpenWindow() {
        frequenciesButton.SetActive(false);
        substituteButton.SetActive(false);
        window.SetActive(true);
        subAnim.DORestart();
    }
}
