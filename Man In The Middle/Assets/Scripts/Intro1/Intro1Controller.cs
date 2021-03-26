using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Febucci.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

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

    [Header("Section Control Objects")]
    public Image[] sectionImages;
    public Image[] sectionFrames;

    [Header("Part Control Objects")]
    public Button leftArrow;
    public Button rightArrow;
    public TextMeshProUGUI currentPartText;
    public TextMeshProUGUI maxPartText;

    [Header("Skip Window")]
    public GameObject skipPartWindow;
    public GameObject skipSectionWindow;
    public GameObject skipWindowDarkening;

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

    private int chapterNo = 1;
    private int maxSection = 4;
    private int[] maxPartSection = new int[] { 1, 3, 2, 3 };

    private int currentSection;
    private int currentPart;
    private int sectionClicked = 0;

    public void Awake() {
        CheckSaveSections();
    }

    public void Start() {
        if (ES3.Load("chapter" + chapterNo + "LastSection", 1) == 1) {
            if (ES3.Load("chapter" + chapterNo + "LastPart", 1) == 1) {
                ShowSection1Part1();
            }
        } else if (ES3.Load("chapter" + chapterNo + "LastSection", 1) == 2) {
            if (ES3.Load("chapter" + chapterNo + "LastPart", 1) == 1) {
                ShowSection2Part1();
            } else if (ES3.Load("chapter" + chapterNo + "LastPart", 1) == 2) {
                ShowSection2Part2();
            } else if (ES3.Load("chapter" + chapterNo + "LastPart", 1) == 3) {
                ShowSection2Part3();
            }
        } else if (ES3.Load("chapter" + chapterNo + "LastSection", 1) == 3) {
            if (ES3.Load("chapter" + chapterNo + "LastPart", 1) == 1) {
                ShowSection3Part1();
            } else if (ES3.Load("chapter" + chapterNo + "LastPart", 1) == 2) {
                ShowSection3Part2();
            }
        } else if (ES3.Load("chapter" + chapterNo + "LastSection", 1) == 4) {
            if (ES3.Load("chapter" + chapterNo + "LastPart", 1) == 1) {
                ShowSection4Part1();
            } else if (ES3.Load("chapter" + chapterNo + "LastPart", 1) == 2) {
                ShowSection4Part2();
            } else if (ES3.Load("chapter" + chapterNo + "LastPart", 1) == 3) {
                ShowSection4Part3();
            }
        }
    }

    private void CheckSaveSections() {
        for (int i = 0; i < maxSection; i++) {
            if (i == 0 ) {
                ES3.Save("chapter" + chapterNo + "Section" + (i + 1) + "Unlocked", true);
            }

            if (ES3.Load("chapter" + chapterNo + "Section" + (i + 1) + "Unlocked", false)) {
                sectionImages[i].color = new Color32(255, 143, 0, 255);
                if (ES3.Load("chapter" + chapterNo + "Section" + (i + 1) + "Completed", false)) {
                    sectionImages[i].color = Color.green;
                }
            }
        }
    }

    public void PressLeftPartArow() {
        if (currentSection == 1) {
            if (currentPart == 1) {
                ClickHomeButton();
            }
        } else if (currentSection == 2) {
            if (currentPart == 1) {
                ShowSection1Part1();
            } else if (currentPart == 2) {
                ShowSection2Part1();
            } else if (currentPart == 3) {
                ShowSection2Part2();
            }

        } else if (currentSection == 3) {
            if (currentPart == 1) {
                ShowSection2Part3();
            } else if (currentPart == 2) {
                ShowSection3Part1();
            }

        } else if (currentSection == 4) {
            if (currentPart == 1) {
                ShowSection3Part2();
            } else if (currentPart == 2) {
                ShowSection4Part1();
            } else if (currentPart == 3) {
                ShowSection4Part2();
            }
        }
    }

    public void PressRightPartArrow() {
        if (!ES3.Load("chapter" + chapterNo + "Section" + currentSection + "Part" + currentPart, false)) {
            skipPartWindow.SetActive(true);
            skipWindowDarkening.SetActive(true);
            return;
        }

        ES3.Save("chapter" + chapterNo + "Section" + currentSection + "Part" + currentPart, true);

        if (currentPart == maxPartSection[currentSection - 1]) {
            ES3.Save("chapter" + chapterNo + "Section" + currentSection + "Completed", true);
            ES3.Save("chapter" + chapterNo + "Section" + (currentSection + 1) + "Unlocked", true);
        }

        if (currentSection == maxSection && currentPart == maxPartSection[currentSection - 1]) {
            ES3.Save("introChapter" + chapterNo + "Completed", true);
            ES3.Save("chapter" + (chapterNo + 1) + "Section1Unlocked", true);
            ES3.Save("introChapter" + (chapterNo + 1) + "Unlocked", true);
        }

        if (currentSection == 1) {
            if (currentPart == 1) {
                ShowSection2Part1();
            }
        } else if (currentSection == 2) {
            if (currentPart == 1) {
                ShowSection2Part2();
            } else if (currentPart == 2) {
                ShowSection2Part3();
            } else if (currentPart == 3) {
                ShowSection3Part1();
            }
        } else if (currentSection == 3) {
            if (currentPart == 1) {
                ShowSection3Part2();
            } else if (currentPart == 2) {
                ShowSection4Part1();
            }
        } else if (currentSection == 4) {
            if (currentPart == 1) {
                ShowSection4Part2();
            } else if (currentPart == 2) {
                ShowSection4Part3();
            } else if (currentPart == 3) {
                ClickHomeButton();
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
        hintsControl.SetCurrentPuzzle("CaesarPuzzle");

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
        hintsControl.SetCurrentPuzzle("CaesarPuzzleRotations");

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
        hintsControl.SetCurrentPuzzle("CaesarPuzzleFrequencies");

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
        ES3.Save("chapter" + chapterNo + "LastSection", currentSection);

        if (n == 1) {
            HideSection1();
        } else if (n == 2) {
            HideSection2();
        } else if (n == 3) {
            HideSection3();
        } else if (n == 4) {
            HideSection4();
        }

        sectionFrames[n - 1].gameObject.SetActive(true);
        sections[n - 1].SetActive(true);
    }

    private void HideAllSections() {
        for (int i = 0; i < sections.Length; i++) {
            sections[i].SetActive(false);
            sectionFrames[i].gameObject.SetActive(false);
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
        ES3.Save("chapter" + chapterNo + "LastPart", currentPart);

        if (ES3.Load("chapter" + chapterNo + "Section" + currentSection + "Part" + currentPart, false)) {
            rightArrow.gameObject.GetComponent<Image>().color = Color.white;
        } else {
            rightArrow.gameObject.GetComponent<Image>().color = Color.red;
        }

        CheckSaveSections();
    }

    public void ClickSection1() {
        if (!ES3.Load("chapter" + chapterNo + "Section1Unlocked", false)) {
            skipSectionWindow.SetActive(true);
            skipWindowDarkening.SetActive(true);
            sectionClicked = 1;
            return;
        }
        ShowSection1Part1();
    }

    public void ClickSection2() {
        if (!ES3.Load("chapter" + chapterNo + "Section2Unlocked", false)) {
            skipSectionWindow.SetActive(true);
            skipWindowDarkening.SetActive(true);
            sectionClicked = 2;
            return;
        }
        ShowSection2Part1();
    }

    public void ClickSection3() {
        if (!ES3.Load("chapter" + chapterNo + "Section3Unlocked", false)) {
            skipSectionWindow.SetActive(true);
            skipWindowDarkening.SetActive(true);
            sectionClicked = 3;
            return;
        }
        ShowSection3Part1();
    }

    public void ClickSection4() {
        if (!ES3.Load("chapter" + chapterNo + "Section4Unlocked", false)) {
            skipSectionWindow.SetActive(true);
            skipWindowDarkening.SetActive(true);
            sectionClicked = 4;
            return;
        }
        ShowSection4Part1();
    }

    public void ClickHomeButton() {
        SceneManager.LoadScene("IntroCryptoMain");
    }

    public void ClickContinue() {
        ES3.Save("chapter" + chapterNo + "Section" + currentSection + "Part" + currentPart, true);
        PressRightPartArrow();
    }

    public void ClickYesSkipPartWindow() {
        ES3.Save("chapter" + chapterNo + "Section" + currentSection + "Part" + currentPart, true);
        skipPartWindow.SetActive(false);
        skipWindowDarkening.SetActive(false);
        PressRightPartArrow();
    }

    public void ClickYesSkipSectionWindow() {
        ES3.Save("chapter" + chapterNo + "Section" + sectionClicked + "Unlocked", true);
        for (int i = 1; i < sectionClicked; i++) {
            ES3.Save("chapter" + chapterNo + "Section" + i + "Unlocked", true);
            ES3.Save("chapter" + chapterNo + "Section" + i + "Completed", true);
            for (int j = 1; j <= maxPartSection[i - 1]; j++) {
                ES3.Save("chapter" + chapterNo + "Section" + i + "Part" + j, true);
            }
        } 

        skipSectionWindow.SetActive(false);
        skipWindowDarkening.SetActive(false);
        
        if (sectionClicked == 1) {
            ShowSection1Part1();
        } else if (sectionClicked == 2) {
            ShowSection2Part1();
        } else if (sectionClicked == 3) {
            ShowSection3Part1();
        } else if (sectionClicked == 4) {
            ShowSection4Part1();
        }
    }
}
