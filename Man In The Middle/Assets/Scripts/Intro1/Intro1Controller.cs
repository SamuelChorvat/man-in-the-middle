using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Febucci.UI;
using DG.Tweening;

public class Intro1Controller : MonoBehaviour
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
    public GameObject s1p1cipherTitle;
    public GameObject s1p1cipherText;

    [Header("Section 2 Part 1")]
    public GameObject s2p1caesarTitle;
    public GameObject s2p1caesarText;

    [Header("Section 2 Part 2")]
    public GameObject s2p2caesarIntroPuzzleTextAnimated;
    public GameObject s2p2caesarIntroPuzzle;
    public IntroCaesarPuzzle s2p2caesarIntroPuzzleScript;

    [Header("Section 2 Part 3")]
    public GameObject s2p3caesarIntroProblemsText;

    [Header("Section 3 Part 1")]
    public GameObject s3p1caesarTitle;
    public GameObject s3p1caesarImprovementText;

    [Header("Section 3 Part 2")]
    public GameObject s3p2caesarImprovementPuzzleTextAnimated;
    public RotationsCaesarCipher s3p2caesarImprovementPuzzleScript;

    [Header("Section 4 Part 1")]
    public GameObject s4p1caesarTitle;
    public GameObject s4p1caesarImprovementText;

    [Header("Section 4 Part 2")]
    public GameObject s4p2caesarProblemText;

    [Header("Section 4 Part 3")]
    public GameObject s4p3caesarPuzzleText;
    public GameObject s4p3frequencyAnalysisDemo;
    public FrequencyAnalysisController s4p3frequencyAnalysisDemoScript;

    private int maxSection = 4;
    private int[] maxPartSection = new int[] { 1, 3, 2, 3 };

    private int currentSection;
    private int currentPart;

    public void Start() {
        ShowSection1Part1();
    }

    public void PressLeftPartArow() {
        if (currentSection == 1) {
            //nothing, only one part
        } else if (currentSection == 2) {
            if (currentPart == 1) {
                //nothing
            } else if (currentPart == 2) {
                ShowSection2Part1();
            } else if (currentPart == 3) {
                ShowSection2Part2();
            }

        } else if (currentSection == 3) {
            if (currentPart == 1) {
                //nothing
            } else if (currentPart == 2) {
                ShowSection3Part1();
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
            //nothing, only one part
        } else if (currentSection == 2) {
            if (currentPart == 1) {
                ShowSection2Part2();
            } else if (currentPart == 2) {
                ShowSection2Part3();
            } else if (currentPart == 3) {
                //nothing
            }
        } else if (currentSection == 3) {
            if (currentPart == 1) {
                ShowSection3Part2();
            } else if (currentPart == 2) {
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

        s1p1cipherTitle.SetActive(true);
        s1p1cipherText.SetActive(true);
        s1p1cipherText.GetComponent<TextAnimatorPlayer>().ShowText(s1p1cipherText.GetComponent<TextMeshProUGUI>().text);
    }

    public void ShowSection2Part1() {
        SetCurrentSection(2);
        SetCurrentPart(1);

        s2p1caesarTitle.SetActive(true);
        s2p1caesarText.SetActive(true);
        s2p1caesarText.GetComponent<TextAnimatorPlayer>().ShowText(s2p1caesarText.GetComponent<TextMeshProUGUI>().text);
    }

    public void ShowSection2Part2() {
        SetCurrentSection(2);
        SetCurrentPart(2);

        s2p1caesarTitle.SetActive(true);
        s2p2caesarIntroPuzzleTextAnimated.SetActive(true);
        s2p2caesarIntroPuzzleTextAnimated.GetComponent<TextAnimatorPlayer>().ShowText(s2p2caesarIntroPuzzleTextAnimated.GetComponent<TextMeshProUGUI>().text);
        s2p2caesarIntroPuzzle.SetActive(true);
        s2p2caesarIntroPuzzleScript.ResetPuzzle();
    }

    public void ShowSection2Part3() {
        SetCurrentSection(2);
        SetCurrentPart(3);

        s2p1caesarTitle.SetActive(true);
        s2p3caesarIntroProblemsText.SetActive(true);
        s2p3caesarIntroProblemsText.GetComponent<TextAnimatorPlayer>().ShowText(s2p3caesarIntroProblemsText.GetComponent<TextMeshProUGUI>().text);
    }
    
    public void ShowSection3Part1() {
        SetCurrentSection(3);
        SetCurrentPart(1);

        s3p1caesarTitle.SetActive(true);
        s3p1caesarImprovementText.SetActive(true);
        s3p1caesarImprovementText.GetComponent<TextAnimatorPlayer>().ShowText(s3p1caesarImprovementText.GetComponent<TextMeshProUGUI>().text);
    }

    public void ShowSection3Part2() {
        SetCurrentSection(3);
        SetCurrentPart(2);

        s3p1caesarTitle.SetActive(true);
        s3p2caesarImprovementPuzzleTextAnimated.SetActive(true);
        s3p2caesarImprovementPuzzleTextAnimated.GetComponent<TextAnimatorPlayer>().ShowText(s3p2caesarImprovementPuzzleTextAnimated.GetComponent<TextMeshProUGUI>().text);
        s3p2caesarImprovementPuzzleScript.ResetPuzzle();
    }

    public void ShowSection4Part1() {
        SetCurrentSection(4);
        SetCurrentPart(1);

        s4p1caesarTitle.SetActive(true);
        s4p1caesarImprovementText.SetActive(true);
        s4p1caesarImprovementText.GetComponent<TextAnimatorPlayer>().ShowText(s4p1caesarImprovementText.GetComponent<TextMeshProUGUI>().text);
    }

    public void ShowSection4Part2() {
        SetCurrentSection(4);
        SetCurrentPart(2);

        s4p1caesarTitle.SetActive(true);
        s4p2caesarProblemText.SetActive(true);
        s4p2caesarProblemText.GetComponent<TextAnimatorPlayer>().ShowText(s4p2caesarProblemText.GetComponent<TextMeshProUGUI>().text);
    }

    public void ShowSection4Part3() {
        SetCurrentSection(4);
        SetCurrentPart(3);

        s4p1caesarTitle.SetActive(true);
        s4p3caesarPuzzleText.SetActive(true);
        s4p3caesarPuzzleText.GetComponent<TextAnimatorPlayer>().ShowText(s4p3caesarPuzzleText.GetComponent<TextMeshProUGUI>().text);
        s4p3frequencyAnalysisDemoScript.ResetPuzzle();
        s4p3frequencyAnalysisDemo.SetActive(true); 
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
