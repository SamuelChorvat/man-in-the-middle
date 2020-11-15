using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class DESBruteforce : MonoBehaviour {
    public int cost;
    public int step;
    public float loopTime;
    public string finalFormat;

    public GameObject moneyObj;
    public TextMeshProUGUI costText;
    public Image fillImage;
    public TextMeshProUGUI fillText;
    public DESBruteforceControl cont;

    private int currentCost = 0;

    public void StartBruteForce() {
        StartCoroutine(BruteForce());
    }

    private IEnumerator BruteForce() {
        yield return new WaitForSeconds(0.2f);
        fillText.text = "Decrypting";
        //fillImage.fillAmount = 0;
        moneyObj.SetActive(true);
        while (cost != currentCost) {
            currentCost += step;
            fillImage.fillAmount += (float) step / cost;
            costText.text = currentCost.ToString();
            yield return new WaitForSeconds(loopTime);
        }
        fillImage.fillAmount = 1;
        fillImage.color = Color.green;
        fillText.text = "Decrypted";
        costText.text = finalFormat;
        cont.ForcedDes();
    }
}
