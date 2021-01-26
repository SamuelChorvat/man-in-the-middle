using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using Febucci.UI;

public class IntroCaesarPuzzle : MonoBehaviour
{
    [Tooltip("Experience")]
    public GameObject experience_obj;
    [Tooltip("Is")]
    public GameObject is_obj;
    [Tooltip("The")]
    public GameObject the_obj;
    [Tooltip("Teacher")]
    public GameObject teacher_obj;
    [Tooltip("Of")]
    public GameObject of_obj;
    [Tooltip("All")]
    public GameObject all_obj;
    [Tooltip("Things")]
    public GameObject things_obj;
    [Tooltip("Text")]
    public TextMeshProUGUI text;
    [Tooltip("Reveal Continue Button")]
    public RevealContinueButton contBut;

    [Tooltip("Text Swap")]
    public GameObject oldText;
    public GameObject newText;

    private bool experienceSolved = false;
    private bool isSolved = false;
    private bool theSolved = false;
    private bool teacherSolved = false;
    private bool ofSolved = false;
    private bool allSolved = false;
    private bool thingsSolved = false;

    public void StartPuzzle() {
        SwapText();
        StartCoroutine(RevealExperienceBoxes());
    }

    public void ResetPuzzle() {
        StopAllCoroutines();
        SwapTextBack();
        HideAllBoxes();
        ResetBooleans();
        text.text = "Decrypt this Caesar cipher:\n\n<align=\"center\">Hashulhqfh lv wkh whdfkhu ri doo wklqjv";
    }

    public void SwapText() {
        oldText.SetActive(false);
        newText.SetActive(true);
    }

    public void SwapTextBack() {
        oldText.SetActive(true);
        newText.SetActive(false);
    }

    private IEnumerator RevealExperienceBoxes() {
        GameObject currentObj = experience_obj;
        String currentWord = "Experience";
        currentObj.SetActive(true);
        StartCoroutine(CheckExperienceBoxes());
        for (int i = 1; i < currentWord.Length + 1; i++) {
            currentObj.transform.Find(currentWord + "Line" + i).gameObject.SetActive(true);
            Image line = currentObj.transform.Find(currentWord + "Line" + i).GetComponent<Image>();
            line.fillOrigin = (int) Image.OriginHorizontal.Right;
            line.fillAmount = 0;
            while (line.fillAmount < 1) {
                line.fillAmount += 0.05f;
                yield return new WaitForSeconds(0.01f);
            }
            currentObj.transform.Find(currentWord + "Letter" + i).gameObject.SetActive(true);
        }
    }

    private void HideAllBoxes() {
        GameObject[] objects = new GameObject[] { experience_obj, is_obj, the_obj, teacher_obj, of_obj, all_obj, things_obj };
        String[] words = new String[] { "Experience", "Is", "The", "Teacher", "Of", "All", "Things" };
        for (int j = 0; j < words.Length; j++) {
            GameObject currentObj = objects[j];
            String currentWord = words[j];
            currentObj.SetActive(false);
            for (int i = 1; i < currentWord.Length + 1; i++) {
                currentObj.transform.Find(currentWord + "Line" + i).gameObject.SetActive(false);
                Image line = currentObj.transform.Find(currentWord + "Line" + i).GetComponent<Image>();
                line.fillAmount = 0;
                currentObj.transform.Find(currentWord + "Letter" + i).gameObject.SetActive(false);

                GameObject letterObject = currentObj.transform.Find(currentWord + "Letter" + i).gameObject;
                letterObject.GetComponent<TMP_InputField>().text = "";
                letterObject.GetComponent<Image>().color = Color.white;
            }
        }
        
    }

    private IEnumerator RevealIsBoxes() {
        GameObject currentObj = is_obj;
        String currentWord = "Is";
        currentObj.SetActive(true);
        StartCoroutine(CheckIsBoxes());
        for (int i = 1; i < currentWord.Length + 1; i++) {
            currentObj.transform.Find(currentWord + "Line" + i).gameObject.SetActive(true);
            Image line = currentObj.transform.Find(currentWord + "Line" + i).GetComponent<Image>();
            line.fillOrigin = (int)Image.OriginHorizontal.Right;
            line.fillAmount = 0;
            while (line.fillAmount < 1) {
                line.fillAmount += 0.05f;
                yield return new WaitForSeconds(0.01f);
            }
            currentObj.transform.Find(currentWord + "Letter" + i).gameObject.SetActive(true);
        }
    }

    private IEnumerator RevealTheBoxes() {
        GameObject currentObj = the_obj;
        String currentWord = "The";
        currentObj.SetActive(true);
        StartCoroutine(CheckTheBoxes());
        for (int i = 1; i < currentWord.Length + 1; i++) {
            currentObj.transform.Find(currentWord + "Line" + i).gameObject.SetActive(true);
            Image line = currentObj.transform.Find(currentWord + "Line" + i).GetComponent<Image>();
            line.fillOrigin = (int)Image.OriginHorizontal.Right;
            line.fillAmount = 0;
            while (line.fillAmount < 1) {
                line.fillAmount += 0.05f;
                yield return new WaitForSeconds(0.01f);
            }
            currentObj.transform.Find(currentWord + "Letter" + i).gameObject.SetActive(true);
        }
    }

    private IEnumerator RevealTeacherBoxes() {
        GameObject currentObj = teacher_obj;
        String currentWord = "Teacher";
        currentObj.SetActive(true);
        StartCoroutine(CheckTeacherBoxes());
        for (int i = 1; i < currentWord.Length + 1; i++) {
            currentObj.transform.Find(currentWord + "Line" + i).gameObject.SetActive(true);
            Image line = currentObj.transform.Find(currentWord + "Line" + i).GetComponent<Image>();
            line.fillOrigin = (int)Image.OriginHorizontal.Right;
            line.fillAmount = 0;
            while (line.fillAmount < 1) {
                line.fillAmount += 0.05f;
                yield return new WaitForSeconds(0.01f);
            }
            currentObj.transform.Find(currentWord + "Letter" + i).gameObject.SetActive(true);
        }
    }

    private IEnumerator RevealOfBoxes() {
        GameObject currentObj = of_obj;
        String currentWord = "Of";
        currentObj.SetActive(true);
        StartCoroutine(CheckOfBoxes());
        for (int i = 1; i < currentWord.Length + 1; i++) {
            currentObj.transform.Find(currentWord + "Line" + i).gameObject.SetActive(true);
            Image line = currentObj.transform.Find(currentWord + "Line" + i).GetComponent<Image>();
            line.fillOrigin = (int)Image.OriginHorizontal.Right;
            line.fillAmount = 0;
            while (line.fillAmount < 1) {
                line.fillAmount += 0.05f;
                yield return new WaitForSeconds(0.01f);
            }
            currentObj.transform.Find(currentWord + "Letter" + i).gameObject.SetActive(true);
        }
    }

    private IEnumerator RevealAllBoxes() {
        GameObject currentObj = all_obj;
        String currentWord = "All";
        currentObj.SetActive(true);
        StartCoroutine(CheckAllBoxes());
        for (int i = 1; i < currentWord.Length + 1; i++) {
            currentObj.transform.Find(currentWord + "Line" + i).gameObject.SetActive(true);
            Image line = currentObj.transform.Find(currentWord + "Line" + i).GetComponent<Image>();
            line.fillOrigin = (int)Image.OriginHorizontal.Right;
            line.fillAmount = 0;
            while (line.fillAmount < 1) {
                line.fillAmount += 0.05f;
                yield return new WaitForSeconds(0.01f);
            }
            currentObj.transform.Find(currentWord + "Letter" + i).gameObject.SetActive(true);
        }
    }

    private IEnumerator RevealThingsBoxes() {
        GameObject currentObj = things_obj;
        String currentWord = "Things";
        currentObj.SetActive(true);
        StartCoroutine(CheckThingsBoxes());
        for (int i = 1; i < currentWord.Length + 1; i++) {
            currentObj.transform.Find(currentWord + "Line" + i).gameObject.SetActive(true);
            Image line = currentObj.transform.Find(currentWord + "Line" + i).GetComponent<Image>();
            line.fillOrigin = (int)Image.OriginHorizontal.Right;
            line.fillAmount = 0;
            while (line.fillAmount < 1) {
                line.fillAmount += 0.05f;
                yield return new WaitForSeconds(0.01f);
            }
            currentObj.transform.Find(currentWord + "Letter" + i).gameObject.SetActive(true);
        }
    }

    private IEnumerator CheckExperienceBoxes() {
        GameObject currentObject = experience_obj;
        String currentWord = "Experience";
        while (!experienceSolved) {
            int correct = 0;
            for (int i = 1; i < currentWord.Length + 1; i++) {
                GameObject letterObject = currentObject.transform.Find(currentWord + "Letter" + i).gameObject;
                
                if ((i == 1 && letterObject.GetComponent<TMP_InputField>().text.Equals("e", StringComparison.OrdinalIgnoreCase)) ||
                    (i == 2 && letterObject.GetComponent<TMP_InputField>().text.Equals("x", StringComparison.OrdinalIgnoreCase)) ||
                    (i == 3 && letterObject.GetComponent<TMP_InputField>().text.Equals("p", StringComparison.OrdinalIgnoreCase)) ||
                    (i == 4 && letterObject.GetComponent<TMP_InputField>().text.Equals("e", StringComparison.OrdinalIgnoreCase)) ||
                    (i == 5 && letterObject.GetComponent<TMP_InputField>().text.Equals("r", StringComparison.OrdinalIgnoreCase)) ||
                    (i == 6 && letterObject.GetComponent<TMP_InputField>().text.Equals("i", StringComparison.OrdinalIgnoreCase)) ||
                    (i == 7 && letterObject.GetComponent<TMP_InputField>().text.Equals("e", StringComparison.OrdinalIgnoreCase)) ||
                    (i == 8 && letterObject.GetComponent<TMP_InputField>().text.Equals("n", StringComparison.OrdinalIgnoreCase)) ||
                    (i == 9 && letterObject.GetComponent<TMP_InputField>().text.Equals("c", StringComparison.OrdinalIgnoreCase)) ||
                    (i == 10 && letterObject.GetComponent<TMP_InputField>().text.Equals("e", StringComparison.OrdinalIgnoreCase))) {
                    letterObject.GetComponent<Image>().color = Color.green;
                    correct += 1;
                } else {
                    letterObject.GetComponent<Image>().color = Color.white;
                }
            }

            if (correct == currentWord.Length) {
                experienceSolved = true;
                currentObject.SetActive(false);
                text.text = "Decrypt this Caesar cipher :\n\n<align=\"center\"><color=green>Experience</color> lv wkh whdfkhu ri doo wklqjv";
                StartCoroutine(RevealIsBoxes());
            }

            yield return new WaitForSeconds(0.1f);
        }
    }

    private IEnumerator CheckIsBoxes() {
        GameObject currentObject = is_obj;
        String currentWord = "Is";
        while (!isSolved) {
            int correct = 0;
            for (int i = 1; i < currentWord.Length + 1; i++) {
                GameObject letterObject = currentObject.transform.Find(currentWord + "Letter" + i).gameObject;

                if ((i == 1 && letterObject.GetComponent<TMP_InputField>().text.Equals("i", StringComparison.OrdinalIgnoreCase)) ||
                    (i == 2 && letterObject.GetComponent<TMP_InputField>().text.Equals("s", StringComparison.OrdinalIgnoreCase)) ) {
                    letterObject.GetComponent<Image>().color = Color.green;
                    correct += 1;
                } else {
                    letterObject.GetComponent<Image>().color = Color.white;
                }
            }

            if (correct == currentWord.Length) {
                isSolved = true;
                currentObject.SetActive(false);
                text.text = "Decrypt this Caesar cipher :\n\n<align=\"center\"><color=green>Experience is</color> wkh whdfkhu ri doo wklqjv";
                StartCoroutine(RevealTheBoxes());
            }

            yield return new WaitForSeconds(0.1f);
        }
    }

    private IEnumerator CheckTheBoxes() {
        GameObject currentObject = the_obj;
        String currentWord = "The";
        while (!theSolved) {
            int correct = 0;
            for (int i = 1; i < currentWord.Length + 1; i++) {
                GameObject letterObject = currentObject.transform.Find(currentWord + "Letter" + i).gameObject;

                if ((i == 1 && letterObject.GetComponent<TMP_InputField>().text.Equals("t", StringComparison.OrdinalIgnoreCase)) ||
                    (i == 2 && letterObject.GetComponent<TMP_InputField>().text.Equals("h", StringComparison.OrdinalIgnoreCase)) ||
                    (i == 3 && letterObject.GetComponent<TMP_InputField>().text.Equals("e", StringComparison.OrdinalIgnoreCase)) ) {
                    letterObject.GetComponent<Image>().color = Color.green;
                    correct += 1;
                } else {
                    letterObject.GetComponent<Image>().color = Color.white;
                }
            }

            if (correct == currentWord.Length) {
                theSolved = true;
                currentObject.SetActive(false);
                text.text = "Decrypt this Caesar cipher :\n\n<align=\"center\"><color=green>Experience is the</color> whdfkhu ri doo wklqjv";
                StartCoroutine(RevealTeacherBoxes());
            }

            yield return new WaitForSeconds(0.1f);
        }
    }

    private IEnumerator CheckTeacherBoxes() {
        GameObject currentObject = teacher_obj;
        String currentWord = "Teacher";
        while (!teacherSolved) {
            int correct = 0;
            for (int i = 1; i < currentWord.Length + 1; i++) {
                GameObject letterObject = currentObject.transform.Find(currentWord + "Letter" + i).gameObject;

                if ((i == 1 && letterObject.GetComponent<TMP_InputField>().text.Equals("t", StringComparison.OrdinalIgnoreCase)) ||
                    (i == 2 && letterObject.GetComponent<TMP_InputField>().text.Equals("e", StringComparison.OrdinalIgnoreCase)) ||
                    (i == 3 && letterObject.GetComponent<TMP_InputField>().text.Equals("a", StringComparison.OrdinalIgnoreCase)) ||
                    (i == 4 && letterObject.GetComponent<TMP_InputField>().text.Equals("c", StringComparison.OrdinalIgnoreCase)) ||
                    (i == 5 && letterObject.GetComponent<TMP_InputField>().text.Equals("h", StringComparison.OrdinalIgnoreCase)) ||
                    (i == 6 && letterObject.GetComponent<TMP_InputField>().text.Equals("e", StringComparison.OrdinalIgnoreCase)) ||
                    (i == 7 && letterObject.GetComponent<TMP_InputField>().text.Equals("r", StringComparison.OrdinalIgnoreCase)) ) {
                    letterObject.GetComponent<Image>().color = Color.green;
                    correct += 1;
                } else {
                    letterObject.GetComponent<Image>().color = Color.white;
                }
            }

            if (correct == currentWord.Length) {
                teacherSolved = true;
                currentObject.SetActive(false);
                text.text = "Decrypt this Caesar cipher :\n\n<align=\"center\"><color=green>Experience is the teacher</color> ri doo wklqjv";
                StartCoroutine(RevealOfBoxes());
            }

            yield return new WaitForSeconds(0.1f);
        }
    }

    private IEnumerator CheckOfBoxes() {
        GameObject currentObject = of_obj;
        String currentWord = "Of";
        while (!ofSolved) {
            int correct = 0;
            for (int i = 1; i < currentWord.Length + 1; i++) {
                GameObject letterObject = currentObject.transform.Find(currentWord + "Letter" + i).gameObject;

                if ((i == 1 && letterObject.GetComponent<TMP_InputField>().text.Equals("o", StringComparison.OrdinalIgnoreCase)) ||
                    (i == 2 && letterObject.GetComponent<TMP_InputField>().text.Equals("f", StringComparison.OrdinalIgnoreCase)) ) {
                    letterObject.GetComponent<Image>().color = Color.green;
                    correct += 1;
                } else {
                    letterObject.GetComponent<Image>().color = Color.white;
                }
            }

            if (correct == currentWord.Length) {
                ofSolved = true;
                currentObject.SetActive(false);
                text.text = "Decrypt this Caesar cipher :\n\n<align=\"center\"><color=green>Experience is the teacher of</color> doo wklqjv";
                StartCoroutine(RevealAllBoxes());
            }

            yield return new WaitForSeconds(0.1f);
        }
    }

    private IEnumerator CheckAllBoxes() {
        GameObject currentObject = all_obj;
        String currentWord = "All";
        while (!allSolved) {
            int correct = 0;
            for (int i = 1; i < currentWord.Length + 1; i++) {
                GameObject letterObject = currentObject.transform.Find(currentWord + "Letter" + i).gameObject;

                if ((i == 1 && letterObject.GetComponent<TMP_InputField>().text.Equals("a", StringComparison.OrdinalIgnoreCase)) ||
                    (i == 2 && letterObject.GetComponent<TMP_InputField>().text.Equals("l", StringComparison.OrdinalIgnoreCase)) ||
                    (i == 3 && letterObject.GetComponent<TMP_InputField>().text.Equals("l", StringComparison.OrdinalIgnoreCase))) {
                    letterObject.GetComponent<Image>().color = Color.green;
                    correct += 1;
                } else {
                    letterObject.GetComponent<Image>().color = Color.white;
                }
            }

            if (correct == currentWord.Length) {
                allSolved = true;
                currentObject.SetActive(false);
                text.text = "Decrypt this Caesar cipher :\n\n<align=\"center\"><color=green>Experience is the teacher of all</color> wklqjv";
                StartCoroutine(RevealThingsBoxes());
            }

            yield return new WaitForSeconds(0.1f);
        }
    }

    private IEnumerator CheckThingsBoxes() {
        GameObject currentObject = things_obj;
        String currentWord = "Things";
        while (!thingsSolved) {
            int correct = 0;
            for (int i = 1; i < currentWord.Length + 1; i++) {
                GameObject letterObject = currentObject.transform.Find(currentWord + "Letter" + i).gameObject;

                if ((i == 1 && letterObject.GetComponent<TMP_InputField>().text.Equals("t", StringComparison.OrdinalIgnoreCase)) ||
                    (i == 2 && letterObject.GetComponent<TMP_InputField>().text.Equals("h", StringComparison.OrdinalIgnoreCase)) ||
                    (i == 3 && letterObject.GetComponent<TMP_InputField>().text.Equals("i", StringComparison.OrdinalIgnoreCase)) ||
                    (i == 4 && letterObject.GetComponent<TMP_InputField>().text.Equals("n", StringComparison.OrdinalIgnoreCase)) ||
                    (i == 5 && letterObject.GetComponent<TMP_InputField>().text.Equals("g", StringComparison.OrdinalIgnoreCase)) ||
                    (i == 6 && letterObject.GetComponent<TMP_InputField>().text.Equals("s", StringComparison.OrdinalIgnoreCase)) ) {
                    letterObject.GetComponent<Image>().color = Color.green;
                    correct += 1;
                } else {
                    letterObject.GetComponent<Image>().color = Color.white;
                }
            }

            if (correct == currentWord.Length) {
                thingsSolved = true;
                currentObject.SetActive(false);
                text.text = "Decrypt this Caesar cipher :\n\n<align=\"center\"><color=green>Experience is the teacher of all things</color>";
                contBut.StartReveal();
            }

            yield return new WaitForSeconds(0.1f);
        }
    }

    private void ResetBooleans() {
        experienceSolved = false;
        isSolved = false;
        theSolved = false;
        teacherSolved = false;
        ofSolved = false;
        allSolved = false;
        thingsSolved = false;
    }
}
