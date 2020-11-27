using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class FrequencyLetter : MonoBehaviour
{
    public string letter;
    public FrequencyAnalysisController freq;

    private bool solved = false;

    // Update is called once per frame
    void Update() {
        if (this.gameObject.GetComponent<TMP_InputField>().text.Equals(letter, StringComparison.OrdinalIgnoreCase) && !solved) {
            this.gameObject.GetComponent<TMP_InputField>().interactable = false;
            this.gameObject.GetComponent<Image>().enabled = false;
            this.gameObject.transform.Find("Text Area").Find("Text").GetComponent<TextMeshProUGUI>().color = Color.green;
            solved = true;
            freq.IncreaseCorrect();
        }
    }
}
