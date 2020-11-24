using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameConsoleAttack : MonoBehaviour
{
    public GameObject consoleAttackObj;
    public GameObject copyButObj;
    public GameObject pasteButObj;
    public GameObject turnButObj;
    public GameObject explanationtext;

    public GameObject gameDataImage;

    public TextMeshProUGUI userDataText;

    public DOTweenAnimation hddAnim;
    public DOTweenAnimation copyButAnim;
    public DOTweenAnimation pasteButAnim;
    public DOTweenAnimation turnButAnim;

    public void ShowAttack() {
        consoleAttackObj.SetActive(true);
        userDataText.text = "USER DATA";
        hddAnim.DORestart();
    }

    public void ShowCopy() {
        copyButObj.SetActive(true);
        copyButAnim.DORestart();
    }

    public void CopyClick() {
        copyButObj.SetActive(false);
        pasteButObj.SetActive(true);
        pasteButAnim.DORestart();
    }

    public void PasteClick() {
        pasteButObj.SetActive(false);
        userDataText.text = "GAME DATA";
        gameDataImage.SetActive(true);
        turnButObj.SetActive(true);
        turnButAnim.DORestart();
    }

    public void TurnClick() {
        turnButObj.SetActive(false);
        StartCoroutine(Decrypt());
    }

    public IEnumerator Decrypt() {
        gameDataImage.GetComponent<Image>().fillAmount = 1f;
        while (gameDataImage.GetComponent<Image>().fillAmount > 0) {
            gameDataImage.GetComponent<Image>().fillAmount -= 0.01f;
            yield return new WaitForSeconds(0.01f);
        }
        explanationtext.SetActive(true);
        explanationtext.GetComponent<DOTweenAnimation>().DORestart();
    }
}
