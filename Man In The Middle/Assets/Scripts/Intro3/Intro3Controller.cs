﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Febucci.UI;

public class Intro3Controller : MonoBehaviour
{
    [Header("Continue Button")]
    public RevealContinueButton continueButton;

    [Header("Hints")]
    public HintsController hintsControl;
    public GameObject hintButton;

    [Header("Sections")]
    public GameObject[] sections;

    [Header("Section objects")]
    public GameObject[] s1objects;
    public GameObject[] s2objects;
    public GameObject[] s3objects;
    public GameObject[] s4objects;

    [Header("Part Control Objects")]
    public Button leftArrow;
    public Button rightArrow;
    public TextMeshProUGUI currentPartText;
    public TextMeshProUGUI maxPartText;

    [Header("Section 1 Part 1")]
    public GameObject s1p1blockTitle;
    public GameObject s1p1blockText;

    [Header("Section 1 Part 2")]
    public GameObject s1p2blockExampleTitle;
    public GameObject s1p2blockExampleText;

    [Header("Section 2 Part 1")]
    public GameObject s2p1desBruteforceTitle;
    public GameObject s2p1desBruteforceText;
    public DESBruteforceControl s2p1desBruteforceScript;

    [Header("Section 3 Part 1")]
    public GameObject s3p1blockCipherModesTitle;
    public GameObject s3p1blockCipherModesText;

    [Header("Section 3 Part 2")]
    public GameObject s3p2ecbTitle;
    public GameObject s3p2ecbText;
    public EBCDemoControl s3p2ebcDemoScript;

    [Header("Section 3 Part 3")]
    public GameObject s3p3cbcTitle;
    public GameObject s3p3cbcText;

    [Header("Section 4 Part 1")]
    public GameObject s4p1cbcIssueTitle;
    public GameObject s4p1cbcIssueText;

    [Header("Section 4 Part 2")]
    public GameObject s4p2consoleAttackTitle;
    public GameObject s4p2consoleAttackText;
    public GameConsoleAttack s4p2consoleAttackScript;

    [Header("Section 4 Part 3")]
    public GameObject s4p3ctrTitle;
    public GameObject s4p3ctrText;

    private int maxSection = 4;
    private int[] maxPartSection = new int[] { 2, 1, 3, 3 };

    private int currentSection;
    private int currentPart;

    // Start is called before the first frame update
    void Start()
    {
        ShowSection1Part1();
    }

    public void PressLeftPartArow() {
        if (currentSection == 1) {
            if (currentPart == 1) {
                //nothing
            } else if (currentPart == 2) {
                ShowSection1Part1();
            }
        } else if (currentSection == 2) {
            //nothing, only one part
        } else if (currentSection == 3) {
            if (currentPart == 1) {
                //nothing
            } else if (currentPart == 2) {
                ShowSection3Part1();
            } else if (currentPart == 3) {
                ShowSection3Part2();
            }

        } else if (currentSection == 4) {
            if (currentPart == 1) {
                //nothing
            } else if (currentPart == 2) {
                ShowSection4Part1();
            } else if (currentPart == 3) {
                ShowSection4Part2();
            }
        }
    }

    public void PressRightPartArrow() {
        if (currentSection == 1) {
            if (currentPart == 1) {
                ShowSection1Part2();
            } else if (currentPart == 2) {
                //nothing
            } 
        } else if (currentSection == 2) {
            //nothing, only one part
        } else if (currentSection == 3) {
            if (currentPart == 1) {
                ShowSection3Part2();
            } else if (currentPart == 2) {
                ShowSection3Part3();
            } else if (currentPart == 3) {
                //nothing
            }
        } else if (currentSection == 4) {
            if (currentPart == 1) {
                ShowSection4Part2();
            } else if (currentPart == 2) {
                ShowSection4Part3();
            } else if (currentPart == 3) {
                //nothing
            }
        }
    }

    public void ShowSection1Part1() {
        SetCurrentSection(1);
        SetCurrentPart(1);

        s1p1blockTitle.SetActive(true);
        s1p1blockText.SetActive(true);
        s1p1blockText.GetComponent<TextAnimatorPlayer>().ShowText(s1p1blockText.GetComponent<TextMeshProUGUI>().text);
    }

    public void ShowSection1Part2() {
        SetCurrentSection(1);
        SetCurrentPart(2);

        s1p2blockExampleTitle.SetActive(true);
        s1p2blockExampleText.SetActive(true);
        s1p2blockExampleText.GetComponent<TextAnimatorPlayer>().ShowText(s1p2blockExampleText.GetComponent<TextMeshProUGUI>().text);
    }

    public void ShowSection2Part1() {
        SetCurrentSection(2);
        SetCurrentPart(1);
        hintsControl.SetCurrentPuzzle("DESBruteforce");

        s2p1desBruteforceTitle.SetActive(true);
        s2p1desBruteforceText.SetActive(true);
        s2p1desBruteforceText.GetComponent<TextAnimatorPlayer>().ShowText(s2p1desBruteforceText.GetComponent<TextMeshProUGUI>().text);
        s2p1desBruteforceScript.ResetDemo();
    }

    public void ShowSection3Part1() {
        SetCurrentSection(3);
        SetCurrentPart(1);

        s3p1blockCipherModesTitle.SetActive(true);
        s3p1blockCipherModesText.SetActive(true);
        s3p1blockCipherModesText.GetComponent<TextAnimatorPlayer>().ShowText(s3p1blockCipherModesText.GetComponent<TextMeshProUGUI>().text);
    }

    public void ShowSection3Part2() {
        SetCurrentSection(3);
        SetCurrentPart(2);
        hintsControl.SetCurrentPuzzle("ECBPicture");

        s3p2ecbTitle.SetActive(true);
        s3p2ecbText.SetActive(true);
        s3p2ecbText.GetComponent<TextAnimatorPlayer>().ShowText(s3p2ecbText.GetComponent<TextMeshProUGUI>().text);
        s3p2ebcDemoScript.ResetDemo();
    }

    public void ShowSection3Part3() {
        SetCurrentSection(3);
        SetCurrentPart(3);

        s3p3cbcTitle.SetActive(true);
        s3p3cbcText.SetActive(true);
        s3p3cbcText.GetComponent<TextAnimatorPlayer>().ShowText(s3p3cbcText.GetComponent<TextMeshProUGUI>().text);
    }

    public void ShowSection4Part1() {
        SetCurrentSection(4);
        SetCurrentPart(1);

        s4p1cbcIssueTitle.SetActive(true);
        s4p1cbcIssueText.SetActive(true);
        s4p1cbcIssueText.GetComponent<TextAnimatorPlayer>().ShowText(s4p1cbcIssueText.GetComponent<TextMeshProUGUI>().text);
    }

    public void ShowSection4Part2() {
        SetCurrentSection(4);
        SetCurrentPart(2);
        hintsControl.SetCurrentPuzzle("GameConsole");

        s4p2consoleAttackTitle.SetActive(true);
        s4p2consoleAttackText.SetActive(true);
        s4p2consoleAttackText.GetComponent<TextAnimatorPlayer>().ShowText(s4p2consoleAttackText.GetComponent<TextMeshProUGUI>().text);
        s4p2consoleAttackScript.ResetAttack();
        continueButton.ResetButton();
    }

    public void ShowSection4Part3() {
        SetCurrentSection(4);
        SetCurrentPart(3);

        s4p3ctrTitle.SetActive(true);
        s4p3ctrText.SetActive(true);
        s4p3ctrText.GetComponent<TextAnimatorPlayer>().ShowText(s4p3ctrText.GetComponent<TextMeshProUGUI>().text);
    }

    private void SetCurrentSection(int n) {
        hintButton.SetActive(false);
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
        } else if (n == 4) {
            HideSection4();
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

    private void HideSection4() {
        for (int i = 0; i < s4objects.Length; i++) {
            s4objects[i].SetActive(false);
        }
    }

    public void SetCurrentPart(int cPart) {
        hintButton.SetActive(false);
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

    public void ClickSection1() {
        ShowSection1Part1();
    }

    public void ClickSection2() {
        ShowSection2Part1();
    }

    public void ClickSection3() {
        ShowSection3Part1();
    }

    public void ClickSection4() {
        ShowSection4Part1();
    }
}
