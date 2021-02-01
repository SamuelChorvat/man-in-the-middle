using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using Febucci.UI;

public class ProtocolsIntroControl : MonoBehaviour
{
    [Header("Part 1")]
    public GameObject alice1;
    public GameObject bob1;
    public GameObject arrowLine1;
    public GameObject arrowHead1;
    public GameObject message1;  

    [Header("Part 2")]
    public GameObject protocolsTextPart2;
    public GameObject alice2;
    public GameObject bob2;
    public GameObject carol2;
    public GameObject arrowLine2;
    public GameObject arrowHead2;
    public GameObject message2;

    [Header("Part 3")]
    public GameObject protocolsTextPart3;

    [Header("Part 3.1")]
    public GameObject alice31;
    public GameObject bob31;
    public GameObject carol31;
    public GameObject arrowLine31;
    public GameObject arrowHead31;
    public GameObject message31;

    [Header("Part 3.2")]
    public GameObject alice32;
    public GameObject bob32;
    public GameObject carol32;
    public GameObject arrowLine32;
    public GameObject arrowHead32;
    public GameObject message32;


    public void ResetIntro() {
        StopAllCoroutines();

        //Part 1
        alice1.transform.localScale = new Vector3(0, 0, 0);
        bob1.transform.localScale = new Vector3(0, 0, 0);
        message1.transform.localScale = new Vector3(0, 0, 0);
        arrowHead1.SetActive(false);
        arrowLine1.GetComponent<Image>().fillAmount = 0;

        //Part 2
        protocolsTextPart2.SetActive(false);
        alice2.transform.localScale = new Vector3(0, 0, 0);
        bob2.transform.localScale = new Vector3(0, 0, 0);
        carol2.transform.localScale = new Vector3(0, 0, 0);
        message2.transform.localScale = new Vector3(0, 0, 0);
        arrowHead2.SetActive(false);
        arrowLine2.GetComponent<Image>().fillAmount = 0;

        //Part 3
        protocolsTextPart3.SetActive(false);

        alice31.transform.localScale = new Vector3(0, 0, 0);
        bob31.transform.localScale = new Vector3(0, 0, 0);
        carol31.transform.localScale = new Vector3(0, 0, 0);
        message31.transform.localScale = new Vector3(0, 0, 0);
        arrowHead31.SetActive(false);
        arrowLine31.GetComponent<Image>().fillAmount = 0;

        alice32.transform.localScale = new Vector3(0, 0, 0);
        bob32.transform.localScale = new Vector3(0, 0, 0);
        carol32.transform.localScale = new Vector3(0, 0, 0);
        message32.transform.localScale = new Vector3(0, 0, 0);
        arrowHead32.SetActive(false);
        arrowLine32.GetComponent<Image>().fillAmount = 0;
    }

    public void ShowPart1() {
        alice1.GetComponent<DOTweenAnimation>().DORestart();
        bob1.GetComponent<DOTweenAnimation>().DORestart();
    }

    public void ShowPart1Helper() {
        StartCoroutine(ShowArrowLine(arrowLine1, arrowHead1));
        message1.GetComponent<DOTweenAnimation>().DORestart();
    }

    public void ShowPart2() {
        protocolsTextPart2.SetActive(true);
        protocolsTextPart2.GetComponent<TextAnimatorPlayer>().ShowText(protocolsTextPart2.GetComponent<TextMeshProUGUI>().text);
    }

    public void ShowPart2Helper1() {
        alice2.GetComponent<DOTweenAnimation>().DORestart();
        bob2.GetComponent<DOTweenAnimation>().DORestart();
        carol2.GetComponent<DOTweenAnimation>().DORestart();
    }

    public void ShowPart2Helper2() {
        StartCoroutine(ShowArrowLine(arrowLine2, arrowHead2));
        message2.GetComponent<DOTweenAnimation>().DORestart();
    }

    public void ShowPart3() {
        protocolsTextPart3.SetActive(true);
        protocolsTextPart3.GetComponent<TextAnimatorPlayer>().ShowText(protocolsTextPart3.GetComponent<TextMeshProUGUI>().text);
    }

    public void ShowPart3Helper1() {
        alice31.GetComponent<DOTweenAnimation>().DORestart();
        bob31.GetComponent<DOTweenAnimation>().DORestart();
        carol31.GetComponent<DOTweenAnimation>().DORestart();
    }

    public void ShowPart3Helper2() {
        StartCoroutine(ShowArrowLine(arrowLine31, arrowHead31));
        message31.GetComponent<DOTweenAnimation>().DORestart();
    }

    public void ShowPart3Helper3() {
        alice32.GetComponent<DOTweenAnimation>().DORestart();
        bob32.GetComponent<DOTweenAnimation>().DORestart();
        carol32.GetComponent<DOTweenAnimation>().DORestart();
    }

    public void ShowPart3Helper4() {
        StartCoroutine(ShowArrowLine(arrowLine32, arrowHead32));
        message32.GetComponent<DOTweenAnimation>().DORestart();
    }

    private IEnumerator ShowArrowLine(GameObject arrowLine, GameObject arrowHead) {
        bool arrowHeadRevealed = false;

        arrowLine.GetComponent<Image>().fillAmount = 0;
        while (!arrowHeadRevealed) {
            arrowLine.GetComponent<Image>().fillAmount += 0.02f;
            if (!arrowHeadRevealed && arrowLine.GetComponent<Image>().fillAmount > 0.96f) {
                arrowHead.SetActive(true);
                arrowHeadRevealed = true;
            }
            yield return new WaitForSeconds(0.005f);
        }
    }
}
