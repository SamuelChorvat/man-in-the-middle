using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using DG.Tweening;

public class ModuloNumber : MonoBehaviour
{
    public string number;
    private bool solved = false;
    public RevealContinueButton but;

    public GameObject next = null;
    public DOTweenAnimation nextAnim = null;
    
    void Update() {
        if (this.gameObject.GetComponent<TMP_InputField>().text.Equals(number, StringComparison.OrdinalIgnoreCase) && !solved) {
            this.gameObject.GetComponent<TMP_InputField>().interactable = false;
            this.gameObject.GetComponent<Image>().enabled = false;
            this.gameObject.transform.Find("Text Area").Find("Text").GetComponent<TextMeshProUGUI>().color = Color.green;
            solved = true;
            
            if (next == null || nextAnim == null) {
                but.StartReveal();
            } else {
                next.SetActive(true);
                nextAnim.DORestart();
            }

        }
    }

    public void ResetNumber() {
        StopAllCoroutines();
        this.gameObject.GetComponent<TMP_InputField>().text = "";
        solved = false;
        this.gameObject.GetComponent<TMP_InputField>().interactable = true;
        this.gameObject.GetComponent<Image>().enabled = true;
        this.gameObject.transform.Find("Text Area").Find("Text").GetComponent<TextMeshProUGUI>().color = Color.white;
    }
}
