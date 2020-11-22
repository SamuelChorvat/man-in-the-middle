using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LetterFrequencyBar : MonoBehaviour
{
    public float maxFill;
    public int intPercentage;

    public void Display() {
        StartCoroutine(ShowFrequencyBar());
    }

    private IEnumerator ShowFrequencyBar() {
        this.GetComponent<Image>().fillOrigin = (int)Image.OriginVertical.Bottom;
        float fillAmount = maxFill;
        this.GetComponent<Image>().fillAmount = 0f;
        

        int finalPercentage = intPercentage;
        float maxPercentage = (float)intPercentage/100;
        this.transform.Find("PercentageText").GetComponent<TextMeshProUGUI>().text = "0.00%";

        while (this.GetComponent<Image>().fillAmount < fillAmount) {
            this.GetComponent<Image>().fillAmount += 0.01f;
            
            int intPercentage = (int) (finalPercentage * (this.GetComponent<Image>().fillAmount / fillAmount));
            float percentage = (float)intPercentage / 100;
            if (percentage > maxPercentage) {
                this.transform.Find("PercentageText").GetComponent<TextMeshProUGUI>().text = maxPercentage.ToString() + "%";
            } else {
                this.transform.Find("PercentageText").GetComponent<TextMeshProUGUI>().text = percentage.ToString() + "%";
            }
            
            yield return new WaitForSeconds(0.01f);
        }
    }
}
