using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FrequenciesWindowController : MonoBehaviour
{
    public GameObject frequenciesButton;
    public GameObject substituteButton;

    public GameObject window;
    public GameObject englishFrequencies;
    public GameObject cipherFrequencies;

    public LetterFrequencyBar[] englishBars;
    public LetterFrequencyBar[] cipherBars;

    public Button englishButton;
    public Button cipherButton;

    public void ClickEnglish() {
        cipherFrequencies.SetActive(false);
        englishFrequencies.SetActive(true);
        englishButton.interactable = false;
        cipherButton.interactable = true;

        for (int i = 0; i < englishBars.Length; i++) {
            englishBars[i].Display();
        }
    }

    public void ClickCipher() {
        englishFrequencies.SetActive(false);
        cipherFrequencies.SetActive(true);
        cipherButton.interactable = false;
        englishButton.interactable = true;
        
        for (int i = 0; i < cipherBars.Length; i++) {
            cipherBars[i].Display();
        }
    }

    public void CloseWindow() {
        window.SetActive(false);
        frequenciesButton.SetActive(true);
        substituteButton.SetActive(true);
    }

    public void OpenWindow() {
        frequenciesButton.SetActive(false);
        substituteButton.SetActive(false);
        window.SetActive(true);

        if (englishButton.interactable) {
            ClickCipher();
        } else {
            ClickEnglish();
        }
    }
}
