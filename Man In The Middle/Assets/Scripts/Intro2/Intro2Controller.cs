using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Intro2Controller : MonoBehaviour
{
    [Header("Continue Button")]
    public RevealContinueButton continueButton;

    [Header("Sections")]
    public GameObject[] sections;

    [Header("Section objects")]
    public GameObject[] s1objects;
    public GameObject[] s2objects;
    public GameObject[] s3objects;

    [Header("Part Control Objects")]
    public Button leftArrow;
    public Button rightArrow;
    public TextMeshProUGUI currentPartText;
    public TextMeshProUGUI maxPartText;

    [Header("Section 1 Part 1")]
    public GameObject s1p1padsTitle;
    public GameObject s1p1vignereCipherText;

    [Header("Section 1 Part 2")]
    public GameObject s1p2vignerePuzzleText;
    public GameObject s1p2vignerePuzzle;

    [Header("Section 2 Part 1")]
    public GameObject s2p1moduloTitle;
    public GameObject s2p1moduloText;

    [Header("Section 2 Part 2")]
    public GameObject s2p2moduloPuzzleText;
    public GameObject s2p2moduloPuzzle;

    [Header("Section 3 Part 1")]
    public GameObject s3p1xorTitle;
    public GameObject s3p1xorText;

    [Header("Section 3 Part 2")]
    public GameObject s3p2xorPuzzleText;

    private int maxSection = 3;
    private int[] maxPartSection = new int[] { 2, 2, 2 };

    private int currentSection;
    private int currentPart;

    void Start()
    {
        ShowSection3Part2();
    }

    public void ShowSection1Part1() {
        SetCurrentSection(1);
        s1p1padsTitle.SetActive(true);
        s1p1vignereCipherText.SetActive(true);
    }

    public void ShowSection1Part2() {
        SetCurrentSection(1);
        s1p1padsTitle.SetActive(true);
        s1p2vignerePuzzleText.SetActive(true);
        s1p2vignerePuzzle.SetActive(true);
    }

    public void ShowSection2Part1() {
        SetCurrentSection(2);
        s2p1moduloTitle.SetActive(true);
        s2p1moduloText.SetActive(true);
    }

    public void ShowSection2Part2() {
        SetCurrentSection(2);
        s2p1moduloTitle.SetActive(true);
        s2p2moduloPuzzleText.SetActive(true);
        s2p2moduloPuzzle.SetActive(true);
    }

    public void ShowSection3Part1() {
        SetCurrentSection(3);
        s3p1xorTitle.SetActive(true);
        s3p1xorText.SetActive(true);
    }

    public void ShowSection3Part2() {
        SetCurrentSection(3);
        s3p1xorTitle.SetActive(true);
        s3p2xorPuzzleText.SetActive(true);
    }

    private void SetCurrentSection(int n) {
        HideAllSections();
        leftArrow.interactable = true;
        rightArrow.interactable = true;
        maxPartText.text = maxPartSection[n - 1].ToString();
        currentSection = n;

        if (n == 1) {
            HideSection1();
        } else if (n == 2) {
            HideSection2();
        } else if (n == 3) {
            HideSection3();
        } 

        sections[n - 1].SetActive(true);
    }

    private void HideAllSections() {
        for (int i = 0; i < sections.Length; i++) {
            sections[i].SetActive(false);
        }
    }

    private void HideSection1() {
        for (int i = 0; i < s1objects.Length; i++) {
            s1objects[i].SetActive(false);
        }
    }

    private void HideSection2() {
        for (int i = 0; i < s2objects.Length; i++) {
            s2objects[i].SetActive(false);
        }
    }

    private void HideSection3() {
        for (int i = 0; i < s3objects.Length; i++) {
            s3objects[i].SetActive(false);
        }
    }

    public void SetCurrentPart(int cPart) {
        continueButton.ResetButton();
        currentPart = cPart;
        currentPartText.text = currentPart.ToString();

        if (currentPart == 1) {
            leftArrow.interactable = false;
        }

        if (currentPart == maxPartSection[currentSection - 1]) {
            rightArrow.interactable = false;
        }
    }
}
