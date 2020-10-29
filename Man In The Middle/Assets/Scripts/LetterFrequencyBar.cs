using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LetterFrequencyBar : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(ShowFrequencyBar());
    }

    private IEnumerator ShowFrequencyBar() {
        this.GetComponent<Image>().fillOrigin = (int)Image.OriginVertical.Bottom;
        float fillAmount = this.GetComponent<Image>().fillAmount;
        this.GetComponent<Image>().fillAmount = 0f;
        

        int finalPercentage = GetPercentage();
        float maxPercentage = GetMaxPercentage();
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

    private int GetPercentage() {
        string percentageString = this.transform.Find("PercentageText").GetComponent<TextMeshProUGUI>().text;
        percentageString = percentageString.Trim('%');
        return (int) ((float.Parse(percentageString))*100);
    }

    private float GetMaxPercentage() {
        string percentageString = this.transform.Find("PercentageText").GetComponent<TextMeshProUGUI>().text;
        percentageString = percentageString.Trim('%');
        return float.Parse(percentageString);
    }

    private float GetFillAmount() {
        string percentageString = this.transform.Find("PercentageText").GetComponent<TextMeshProUGUI>().text;
        percentageString = percentageString.Trim('%');

        if (float.Parse(percentageString) > 12f) {
            return 1f;
        } else {
            return (float.Parse(percentageString) / 100) * 8;
        }

    }
}
