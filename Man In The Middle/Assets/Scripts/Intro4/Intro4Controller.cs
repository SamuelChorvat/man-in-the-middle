﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Febucci.UI;
using UnityEngine.SceneManagement;

public class Intro4Controller : MonoBehaviour
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
    public GameObject[] s5objects;

    [Header("Section Control Objects")]
    public Image[] sectionImages;
    public Image[] sectionFrames;

    [Header("Part Control Objects")]
    public GameObject partControl;
    public GameObject altPartControl;
    public Button leftArrow;
    public Button rightArrow;
    public Button altLeftArrow;
    public Button altRightArrow;
    public TextMeshProUGUI currentPartText;
    public TextMeshProUGUI maxPartText;
    public TextMeshProUGUI altCurrentPartText;
    public TextMeshProUGUI altMaxPartText;

    [Header("Skip Window")]
    public GameObject skipPartWindow;
    public GameObject skipSectionWindow;
    public GameObject skipWindowDarkening;

    [Header("Section 1 Part 1")]
    public GameObject s1p1keyProblemTitle;
    public GameObject s1p1keyProblemText;

    [Header("Section 1 Part 2")]
    public GameObject s1p2publicKeyEncryptionTitle;
    public GameObject s1p2publicKeyEncryptionText;

    [Header("Section 1 Part 3")]
    public GameObject s1p3diffieHellmanTitle;
    public GameObject s1p3diffieHellmanText;

    [Header("Section 1 Part 4")]
    public GameObject s1p4diffieHellmanText;

    [Header("Section 1 Part 5")]
    public GameObject s1p5diffieHellmanText;

    [Header("Section 1 Part 6")]
    public GameObject s1p6diffieHellmanDemo;
    public DiffieHellmanControl s1p6diffieHellmanDemoScript;

    [Header("Section 2 Part 1")]
    public GameObject s2p1elgamalTitle;
    public GameObject s2p1elgamalText;

    [Header("Section 2 Part 2")]
    public GameObject s2p2rsaTitle;
    public GameObject s2p2rsaText;

    [Header("Section 2 Part 3")]
    public GameObject s2p3pkcTitle;
    public GameObject s2p3pkcText;

    [Header("Section 3 Part 1")]
    public GameObject s3p1signaturesTitle;
    public GameObject s3p1signaturesText;

    [Header("Section 3 Part 2")]
    public GameObject s3p2signaturesTrickText;
    public GameObject s3p2signaturesTrickDemo;
    public SignatureTrickControl s3p2signaturesTrickDemoScript;

    [Header("Section 3 Part 3")]
    public GameObject s3p3certificatesTitle;
    public GameObject s3p3certificatesText;

    [Header("Section 4 Part 1")]
    public GameObject s4p1hashesTitle;
    public GameObject s4p1hashesText;

    [Header("Section 4 Part 2")]
    public GameObject s4p2hashesDemoText;

    [Header("Section 4 Part 3")]
    public GameObject s4p3usesHashesTitle;
    public GameObject s4p3usesHashesText;

    [Header("Section 4 Part 4")]
    public GameObject s4p4hashesAttacksTitle;
    public GameObject s4p4hashesAttacksText;

    [Header("Section 4 Part 5")]
    public GameObject s4p5birthdayTitle;
    public GameObject s4p5birthdayText;

    [Header("Section 4 Part 6")]
    public GameObject s4p6hashesTypesTitle;
    public GameObject s4p6hashesTypesText;

    [Header("Section 5 Part 1")]
    public GameObject s5p1macTitle;
    public GameObject s5p1macText;

    [Header("Section 5 Part 2")]
    public GameObject s5p2alteringTitle;
    public GameObject s5p2alteringText;

    [Header("Section 5 Part 3")]
    public GameObject s5p3knownTitle;
    public GameObject s5p3knownText;

    [Header("Section 5 Part 4")]
    public GameObject s5p4knownAttackDemoText;
    public GameObject s5p4knownAttackDemo;
    public KnownDemoControl s5p4knownAttackDemoScript;

    [Header("Section 5 Part 5")]
    public GameObject s5p5authenticatedTitle;
    public GameObject s5p5authenticatedText;

    private int chapterNo = 4;
    private int maxSection = 5;
    private int[] maxPartSection = new int[] { 6, 3, 3, 6, 5 };

    private int currentSection;
    private int currentPart;
    private int sectionClicked = 0;

    public void Awake() {
        CheckSaveSections();
    }

    void Start() {
        if (ES3.Load("chapter" + chapterNo + "LastSection", 1) == 1) {
            if (ES3.Load("chapter" + chapterNo + "LastPart", 1) == 1) {
                ShowSection1Part1();
            } else if (ES3.Load("chapter" + chapterNo + "LastPart", 1) == 2) {
                ShowSection1Part2();
            } else if (ES3.Load("chapter" + chapterNo + "LastPart", 1) == 3) {
                ShowSection1Part3();
            } else if (ES3.Load("chapter" + chapterNo + "LastPart", 1) == 4) {
                ShowSection1Part4();
            } else if (ES3.Load("chapter" + chapterNo + "LastPart", 1) == 5) {
                ShowSection1Part5();
            } else if (ES3.Load("chapter" + chapterNo + "LastPart", 1) == 6) {
                ShowSection1Part6();
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
            } else if (ES3.Load("chapter" + chapterNo + "LastPart", 1) == 3) {
                ShowSection3Part3();
            }
        } else if (ES3.Load("chapter" + chapterNo + "LastSection", 1) == 4) {
            if (ES3.Load("chapter" + chapterNo + "LastPart", 1) == 1) {
                ShowSection4Part1();
            } else if (ES3.Load("chapter" + chapterNo + "LastPart", 1) == 2) {
                ShowSection4Part2();
            } else if (ES3.Load("chapter" + chapterNo + "LastPart", 1) == 3) {
                ShowSection4Part3();
            } else if (ES3.Load("chapter" + chapterNo + "LastPart", 1) == 4) {
                ShowSection4Part4();
            } else if (ES3.Load("chapter" + chapterNo + "LastPart", 1) == 5) {
                ShowSection4Part5();
            } else if (ES3.Load("chapter" + chapterNo + "LastPart", 1) == 6) {
                ShowSection4Part6();
            }
        } else if (ES3.Load("chapter" + chapterNo + "LastSection", 1) == 5) {
            if (ES3.Load("chapter" + chapterNo + "LastPart", 1) == 1) {
                ShowSection5Part1();
            } else if (ES3.Load("chapter" + chapterNo + "LastPart", 1) == 2) {
                ShowSection5Part2();
            } else if (ES3.Load("chapter" + chapterNo + "LastPart", 1) == 3) {
                ShowSection5Part3();
            } else if (ES3.Load("chapter" + chapterNo + "LastPart", 1) == 4) {
                ShowSection5Part4();
            } else if (ES3.Load("chapter" + chapterNo + "LastPart", 1) == 5) {
                ShowSection5Part5();
            } 
        }
    }

    private void CheckSaveSections() {
        for (int i = 0; i < maxSection; i++) {
            if (i == 0) {
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

    public void PressLeftPartArrow() {
        if (currentSection == 1) {
            if (currentPart == 1) {
                ClickHomeButton();
            } else if (currentPart == 2) {
                ShowSection1Part1();
            } else if (currentPart == 3) {
                ShowSection1Part2();
            } else if (currentPart == 4) {
                ShowSection1Part3();
            } else if (currentPart == 5) {
                ShowSection1Part4();
            } else if (currentPart == 6) {
                ShowSection1Part5();
            }
        } else if (currentSection == 2) {
            if (currentPart == 1) {
                ShowSection1Part6();
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
            } else if (currentPart == 3) {
                ShowSection3Part2();
            } 

        } else if (currentSection == 4) {
            if (currentPart == 1) {
                ShowSection3Part3();
            } else if (currentPart == 2) {
                ShowSection4Part1();
            } else if (currentPart == 3) {
                ShowSection4Part2();
            } else if (currentPart == 4) {
                ShowSection4Part3();
            } else if (currentPart == 5) {
                ShowSection4Part4();
            } else if (currentPart == 6) {
                ShowSection4Part5();
            }
        } else if (currentSection == 5) {
            if (currentPart == 1) {
                ShowSection4Part6();
            } else if (currentPart == 2) {
                ShowSection5Part1();
            } else if (currentPart == 3) {
                ShowSection5Part2();
            } else if (currentPart == 4) {
                ShowSection5Part3();
            } else if (currentPart == 5) {
                ShowSection5Part4();
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
            ES3.Save("protocolAttacksUnlocked", true);
        }

        if (currentSection == 1) {
            if (currentPart == 1) {
                ShowSection1Part2();
            } else if (currentPart == 2) {
                ShowSection1Part3();
            } else if (currentPart == 3) {
                ShowSection1Part4();
            } else if (currentPart == 4) {
                ShowSection1Part5();
            } else if (currentPart == 5) {
                ShowSection1Part6();
            } else if (currentPart == 6) {
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
                ShowSection3Part3();
            } else if (currentPart == 3) {
                ShowSection4Part1();
            }

        } else if (currentSection == 4) {
            if (currentPart == 1) {
                ShowSection4Part2();
            } else if (currentPart == 2) {
                ShowSection4Part3();
            } else if (currentPart == 3) {
                ShowSection4Part4();
            } else if (currentPart == 4) {
                ShowSection4Part5();
            } else if (currentPart == 5) {
                ShowSection4Part6();
            } else if (currentPart == 6) {
                ShowSection5Part1();
            }
        } else if (currentSection == 5) {
            if (currentPart == 1) {
                ShowSection5Part2();
            } else if (currentPart == 2) {
                ShowSection5Part3();
            } else if (currentPart == 3) {
                ShowSection5Part4();
            } else if (currentPart == 4) {
                ShowSection5Part5();
            } else if (currentPart == 5) {
                ClickHomeButton();
            }
        }
    }

    public void ShowSection1Part1() {
        SetCurrentSection(1);
        SetCurrentPart(1);

        s1p1keyProblemTitle.SetActive(true);
        s1p1keyProblemText.SetActive(true);
        s1p1keyProblemText.GetComponent<TextAnimatorPlayer>().ShowText(s1p1keyProblemText.GetComponent<TextMeshProUGUI>().text);
    }

    public void ShowSection1Part2() {
        SetCurrentSection(1);
        SetCurrentPart(2);

        s1p2publicKeyEncryptionTitle.SetActive(true);
        s1p2publicKeyEncryptionText.SetActive(true);
        s1p2publicKeyEncryptionText.GetComponent<TextAnimatorPlayer>().ShowText(s1p2publicKeyEncryptionText.GetComponent<TextMeshProUGUI>().text);
    }

    public void ShowSection1Part3() {
        SetCurrentSection(1);
        SetCurrentPart(3);

        s1p3diffieHellmanTitle.SetActive(true);
        s1p3diffieHellmanText.SetActive(true);
        s1p3diffieHellmanText.GetComponent<TextAnimatorPlayer>().ShowText(s1p3diffieHellmanText.GetComponent<TextMeshProUGUI>().text);
    }

    public void ShowSection1Part4() {
        SetCurrentSection(1);
        SetCurrentPart(4);

        s1p3diffieHellmanTitle.SetActive(true);
        s1p4diffieHellmanText.SetActive(true);
        s1p4diffieHellmanText.GetComponent<TextAnimatorPlayer>().ShowText(s1p4diffieHellmanText.GetComponent<TextMeshProUGUI>().text);
    }

    public void ShowSection1Part5() {
        SetCurrentSection(1);
        SetCurrentPart(5);

        s1p3diffieHellmanTitle.SetActive(true);
        s1p5diffieHellmanText.SetActive(true);
        s1p5diffieHellmanText.GetComponent<TextAnimatorPlayer>().ShowText(s1p5diffieHellmanText.GetComponent<TextMeshProUGUI>().text);
    }

    public void ShowSection1Part6() {
        SetCurrentSection(1);
        SetCurrentPart(6);
        partControl.SetActive(false);
        altPartControl.SetActive(true);
        hintsControl.SetCurrentPuzzle("DiffieHellman");

        s1p3diffieHellmanTitle.SetActive(true);
        s1p6diffieHellmanDemo.SetActive(true);
        s1p6diffieHellmanDemoScript.StartDHDemo();
    }

    public void ShowSection2Part1() {
        SetCurrentSection(2);
        SetCurrentPart(1);

        s2p1elgamalTitle.SetActive(true);
        s2p1elgamalText.SetActive(true);
        s2p1elgamalText.GetComponent<TextAnimatorPlayer>().ShowText(s2p1elgamalText.GetComponent<TextMeshProUGUI>().text);
    }

    public void ShowSection2Part2() {
        SetCurrentSection(2);
        SetCurrentPart(2);

        s2p2rsaTitle.SetActive(true);
        s2p2rsaText.SetActive(true);
        s2p2rsaText.GetComponent<TextAnimatorPlayer>().ShowText(s2p2rsaText.GetComponent<TextMeshProUGUI>().text);
    }

    public void ShowSection2Part3() {
        SetCurrentSection(2);
        SetCurrentPart(3);

        s2p3pkcTitle.SetActive(true);
        s2p3pkcText.SetActive(true);
        s2p3pkcText.GetComponent<TextAnimatorPlayer>().ShowText(s2p3pkcText.GetComponent<TextMeshProUGUI>().text);
    }

    public void ShowSection3Part1() {
        SetCurrentSection(3);
        SetCurrentPart(1);

        s3p1signaturesTitle.SetActive(true);
        s3p1signaturesText.SetActive(true);
        s3p1signaturesText.GetComponent<TextAnimatorPlayer>().ShowText(s3p1signaturesText.GetComponent<TextMeshProUGUI>().text);
    }

    public void ShowSection3Part2() {
        SetCurrentSection(3);
        SetCurrentPart(2);

        s3p1signaturesTitle.SetActive(true);
        s3p2signaturesTrickText.SetActive(true);
        s3p2signaturesTrickText.GetComponent<TextAnimatorPlayer>().ShowText(s3p2signaturesTrickText.GetComponent<TextMeshProUGUI>().text);
        s3p2signaturesTrickDemo.SetActive(true);
        s3p2signaturesTrickDemoScript.InitializeSign();
    }

    public void ShowSection3Part3() {
        SetCurrentSection(3);
        SetCurrentPart(3);

        s3p3certificatesTitle.SetActive(true);
        s3p3certificatesText.SetActive(true);
        s3p3certificatesText.GetComponent<TextAnimatorPlayer>().ShowText(s3p3certificatesText.GetComponent<TextMeshProUGUI>().text);
    }

    public void ShowSection4Part1() {
        SetCurrentSection(4);
        SetCurrentPart(1);

        s4p1hashesTitle.SetActive(true);
        s4p1hashesText.SetActive(true);
        s4p1hashesText.GetComponent<TextAnimatorPlayer>().ShowText(s4p1hashesText.GetComponent<TextMeshProUGUI>().text);
    }

    public void ShowSection4Part2() {
        SetCurrentSection(4);
        SetCurrentPart(2);
        hintsControl.SetCurrentPuzzle("DiffieHellman");

        s4p1hashesTitle.SetActive(true);
        s4p2hashesDemoText.SetActive(true);
        s4p2hashesDemoText.GetComponent<TextAnimatorPlayer>().ShowText(s4p2hashesDemoText.GetComponent<TextMeshProUGUI>().text);
    }

    public void ShowSection4Part3() {
        SetCurrentSection(4);
        SetCurrentPart(3);

        s4p3usesHashesTitle.SetActive(true);
        s4p3usesHashesText.SetActive(true);
        s4p3usesHashesText.GetComponent<TextAnimatorPlayer>().ShowText(s4p3usesHashesText.GetComponent<TextMeshProUGUI>().text);
    }

    public void ShowSection4Part4() {
        SetCurrentSection(4);
        SetCurrentPart(4);

        s4p4hashesAttacksTitle.SetActive(true);
        s4p4hashesAttacksText.SetActive(true);
        s4p4hashesAttacksText.GetComponent<TextAnimatorPlayer>().ShowText(s4p4hashesAttacksText.GetComponent<TextMeshProUGUI>().text);
    }

    public void ShowSection4Part5() {
        SetCurrentSection(4);
        SetCurrentPart(5);
        hintsControl.SetCurrentPuzzle("Birthday");

        s4p5birthdayTitle.SetActive(true);
        s4p5birthdayText.SetActive(true);
        s4p5birthdayText.GetComponent<TextAnimatorPlayer>().ShowText(s4p5birthdayText.GetComponent<TextMeshProUGUI>().text);
    }

    public void ShowSection4Part6() {
        SetCurrentSection(4);
        SetCurrentPart(6);

        s4p6hashesTypesTitle.SetActive(true);
        s4p6hashesTypesText.SetActive(true);
        s4p6hashesTypesText.GetComponent<TextAnimatorPlayer>().ShowText(s4p6hashesTypesText.GetComponent<TextMeshProUGUI>().text);
    }

    public void ShowSection5Part1() {
        SetCurrentSection(5);
        SetCurrentPart(1);

        s5p1macTitle.SetActive(true);
        s5p1macText.SetActive(true);
        s5p1macText.GetComponent<TextAnimatorPlayer>().ShowText(s5p1macText.GetComponent<TextMeshProUGUI>().text);
    }

    public void ShowSection5Part2() {
        SetCurrentSection(5);
        SetCurrentPart(2);

        s5p2alteringTitle.SetActive(true);
        s5p2alteringText.SetActive(true);
        s5p2alteringText.GetComponent<TextAnimatorPlayer>().ShowText(s5p2alteringText.GetComponent<TextMeshProUGUI>().text);
    }

    public void ShowSection5Part3() {
        SetCurrentSection(5);
        SetCurrentPart(3);

        s5p3knownTitle.SetActive(true);
        s5p3knownText.SetActive(true);
        s5p3knownText.GetComponent<TextAnimatorPlayer>().ShowText(s5p3knownText.GetComponent<TextMeshProUGUI>().text);
    }

    public void ShowSection5Part4() {
        SetCurrentSection(5);
        SetCurrentPart(4);
        hintsControl.SetCurrentPuzzle("KnownText");

        s5p3knownTitle.SetActive(true);
        s5p4knownAttackDemoText.SetActive(true);
        s5p4knownAttackDemoText.GetComponent<TextAnimatorPlayer>().ShowText(s5p4knownAttackDemoText.GetComponent<TextMeshProUGUI>().text);
        s5p4knownAttackDemo.SetActive(true);
        s5p4knownAttackDemoScript.ResetDemo();
    }

    public void ShowSection5Part5() {
        SetCurrentSection(5);
        SetCurrentPart(5);

        s5p5authenticatedTitle.SetActive(true);
        s5p5authenticatedText.SetActive(true);
        s5p5authenticatedText.GetComponent<TextAnimatorPlayer>().ShowText(s5p5authenticatedText.GetComponent<TextMeshProUGUI>().text);
    }

    private void SetCurrentSection(int n) {
        hintButton.SetActive(false);
        HideAllSections();
        altPartControl.SetActive(false);
        partControl.SetActive(true);
        leftArrow.interactable = true;
        rightArrow.interactable = true;
        altLeftArrow.interactable = true;
        altRightArrow.interactable = true;
        maxPartText.text = maxPartSection[n - 1].ToString();
        altMaxPartText.text = maxPartSection[n - 1].ToString();
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
        } else if (n == 5) {
            HideSection5();
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

    private void HideSection5() {
        for (int i = 0; i < s5objects.Length; i++) {
            s5objects[i].SetActive(false);
        }
    }

    public void SetCurrentPart(int cPart) {
        hintButton.SetActive(false);
        continueButton.ResetButton();
        currentPart = cPart;
        currentPartText.text = currentPart.ToString();
        altCurrentPartText.text = currentPart.ToString();
        ES3.Save("chapter" + chapterNo + "LastPart", currentPart);

        if (ES3.Load("chapter" + chapterNo + "Section" + currentSection + "Part" + currentPart, false)) {
            rightArrow.gameObject.GetComponent<Image>().color = Color.white;
            altRightArrow.gameObject.GetComponent<Image>().color = Color.white;
        } else {
            rightArrow.gameObject.GetComponent<Image>().color = Color.red;
            altRightArrow.gameObject.GetComponent<Image>().color = Color.red;
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

    public void ClickSection5() {
        if (!ES3.Load("chapter" + chapterNo + "Section5Unlocked", false)) {
            skipSectionWindow.SetActive(true);
            skipWindowDarkening.SetActive(true);
            sectionClicked = 5;
            return;
        }
        ShowSection5Part1();
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
        } else if (sectionClicked == 5) {
            ShowSection5Part1();
        }
    }
}
