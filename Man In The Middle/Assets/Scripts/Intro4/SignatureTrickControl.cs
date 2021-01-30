using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.VersionControl;
using UnityEngine;

public class SignatureTrickControl : MonoBehaviour
{
    public GameObject signButton;
    public GameObject messageRSA;

    public RevealContinueButton but;

    public void InitializeSign() {
        signButton.GetComponent<RectTransform>().localScale = new Vector3(0, 0, 0);
        messageRSA.GetComponent<RectTransform>().localScale = new Vector3(0, 0, 0);
        signButton.SetActive(false);
        messageRSA.SetActive(false);
        messageRSA.GetComponent<TextMeshProUGUI>().text = "OWd8n/qSfBtNEkfzSG3hsemAj05EdJ0p41O3M2wfYhYw5CZ8NAm+rnkwGiBdZqnC2yBXLXCsfW9PMnsdCfQLoNYoR9oGmaqsa7gSNY1w31SISJq85q/WVu2Ce0ffKKJ1IDPXMrtVo4j0eu3/hvCOFA2MXqXxO/13uIjxO1fELhs=";
    }

    public void ShowMessage() {
        InitializeSign();
        messageRSA.SetActive(true);
        messageRSA.GetComponent<DOTweenAnimation>().DORestart();
    }

    public void ShowSignButton() {
        signButton.SetActive(true);
        signButton.GetComponent<DOTweenAnimation>().DORestart();
    }

    public void OnSignClick() {
        signButton.SetActive(false);
        messageRSA.GetComponent<TextMeshProUGUI>().text = "<color=red>As this can be used to trick people into decrypting</color>";
        but.StartReveal();
    }
}
