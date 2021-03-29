using DG.Tweening;
using Febucci.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Protocols1Controller : MonoBehaviour
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
    public Button leftArrow;
    public Button rightArrow;
    public TextMeshProUGUI currentPartText;
    public TextMeshProUGUI maxPartText;

    [Header("Skip Window")]
    public GameObject skipPartWindow;
    public GameObject skipSectionWindow;
    public GameObject skipWindowDarkening;

    [Header("General")]
    public GameObject protocolAttackFramework;

    [Header("Section 1 Part 1")]
    public GameObject s1p1protocolsTitle;
    public GameObject s1p1protocolsText;
    public ProtocolsIntroControl s1p1protocolsIntroControl;
    public GameObject s1p1protocolsIntro;

    [Header("Section 1 Part 2")]
    public GameObject s1p2simpleAttackTitle;
    public GameObject s1p2protocolAttack1Text;

    [Header("Section 1 Part 3")]
    public GameObject s1p3nonceTitle;
    public GameObject s1p3nonceText;

    [Header("Section 1 Part 4")]
    public GameObject s1p4protocolAttack2Text;

    [Header("Section 1 Part 5")]
    public GameObject s1p5protocolFixTitle;
    public GameObject s1p5protocolFixText;
    public GameObject s1p5protocolFixSteps;

    [Header("Section 2 Part 1")]
    public GameObject s2p1keyEstablishmentTitle;
    public GameObject s2p1keyEstablishmentText;

    [Header("Section 2 Part 2")]
    public GameObject s2p2needhamTitle;
    public GameObject s2p2needhamVulnerableText1;
    public GameObject s2p2needhamVulnerable;

    [Header("Section 2 Part 3")]
    public GameObject s2p3protocolAttack3Text;

    [Header("Section 2 Part 4")]
    public GameObject s2p4needhamFixText;
    public GameObject s2p4needhamFix;

    [Header("Section 3 Part 1")]
    public GameObject s3p1forwardSecrecyTitle;
    public GameObject s3p1forwardSecrecyText;
    public GameObject s3p1forwardSecrecy;

    [Header("Section 3 Part 2")]
    public GameObject s3p2forwardSecrecyExplanationText;

    [Header("Section 3 Part 3")]
    public GameObject s3p3stationToStationTitle;
    public GameObject s3p3stationToStation;

    [Header("Section 3 Part 4")]
    public GameObject s3p4stationVulnerabilityText;
    public GameObject s3p4stationVulnerabilityProtocol;

    [Header("Section 3 Part 5")]
    public GameObject s3p5protocolAttack4Text;

    [Header("Section 4 Part 1")]
    public GameObject s4p1certificateTitle;
    public GameObject s4p1certificatesText;

    [Header("Section 4 Part 2")]
    public GameObject s4p2certificatesText1;
    public GameObject s4p2certificatesProtocol;

    [Header("Section 4 Part 3")]
    public GameObject s4p3protocolAttack5Text;

    [Header("Section 4 Part 4")]
    public GameObject s4p4protocolGoalsTitle;
    public GameObject s4p4protocolGoalsText;

    [Header("Section 5 Part 1")]
    public GameObject s5p1protocolAttacksTitle;
    public GameObject s5p1protocol6Text;
    public GameObject s5p1protocol6;

    [Header("Section 5 Part 2")]
    public GameObject s5p2protocolAttack6Text;

    [Header("Section 5 Part 3")]
    public GameObject s5p3protocol7Text;
    public GameObject s5p3protocol7;

    [Header("Section 5 Part 4")]
    public GameObject s5p4protocolAttack7Text;

    [Header("Section 5 Part 5")]
    public GameObject s5p5protocol8Text;
    public GameObject s5p5protocol8;

    [Header("Section 5 Part 6")]
    public GameObject s5p6protocolAttack8Text;

    private int maxSection = 5;
    private int[] maxPartSection = new int[] { 5, 4, 5, 4, 6 };

    private int currentSection;
    private int currentPart;
    private int sectionClicked = 0;

    public void Awake() {
        CheckSaveSections();
    }

    void Start() {
        if (ES3.Load("protocolsLastSection", 1) == 1) {
            if (ES3.Load("protocolsLastPart", 1) == 1) {
                ShowSection1Part1();
            } else if (ES3.Load("protocolsLastPart", 1) == 2) {
                ShowSection1Part2();
            } else if (ES3.Load("protocolsLastPart", 1) == 3) {
                ShowSection1Part3();
            } else if (ES3.Load("protocolsLastPart", 1) == 4) {
                ShowSection1Part4();
            } else if (ES3.Load("protocolsLastPart", 1) == 5) {
                ShowSection1Part5();
            }
        } else if (ES3.Load("protocolsLastSection", 1) == 2) {
            if (ES3.Load("protocolsLastPart", 1) == 1) {
                ShowSection2Part1();
            } else if (ES3.Load("protocolsLastPart", 1) == 2) {
                ShowSection2Part2();
            } else if (ES3.Load("protocolsLastPart", 1) == 3) {
                ShowSection2Part3();
            } else if (ES3.Load("protocolsLastPart", 1) == 4) {
                ShowSection2Part4();
            }
        } else if (ES3.Load("protocolsLastSection", 1) == 3) {
            if (ES3.Load("protocolsLastPart", 1) == 1) {
                ShowSection3Part1();
            } else if (ES3.Load("protocolsLastPart", 1) == 2) {
                ShowSection3Part2();
            } else if (ES3.Load("protocolsLastPart", 1) == 3) {
                ShowSection3Part3();
            } else if (ES3.Load("protocolsLastPart", 1) == 4) {
                ShowSection3Part4();
            } else if (ES3.Load("protocolsLastPart", 1) == 5) {
                ShowSection3Part5();
            }
        } else if (ES3.Load("protocolsLastSection", 1) == 4) {
            if (ES3.Load("protocolsLastPart", 1) == 1) {
                ShowSection4Part1();
            } else if (ES3.Load("protocolsLastPart", 1) == 2) {
                ShowSection4Part2();
            } else if (ES3.Load("protocolsLastPart", 1) == 3) {
                ShowSection4Part3();
            } else if (ES3.Load("protocolsLastPart", 1) == 4) {
                ShowSection4Part4();
            }
        } else if (ES3.Load("protocolsLastSection", 1) == 5) {
            if (ES3.Load("protocolsLastPart", 1) == 1) {
                ShowSection5Part1();
            } else if (ES3.Load("protocolsLastPart", 1) == 2) {
                ShowSection5Part2();
            } else if (ES3.Load("protocolsLastPart", 1) == 3) {
                ShowSection5Part3();
            } else if (ES3.Load("protocolsLastPart", 1) == 4) {
                ShowSection5Part4();
            } else if (ES3.Load("protocolsLastPart", 1) == 5) {
                ShowSection5Part5();
            } else if (ES3.Load("protocolsLastPart", 1) == 6) {
                ShowSection5Part6();
            }
        }
    }

    private void CheckSaveSections() {
        for (int i = 0; i < maxSection; i++) {
            if (i == 0) {
                ES3.Save("protocolsSection" + (i + 1) + "Unlocked", true);
            }

            if (ES3.Load("protocolsSection" + (i + 1) + "Unlocked", false)) {
                sectionImages[i].color = new Color32(255, 143, 0, 255);
                if (ES3.Load("protocolsSection" + (i + 1) + "Completed", false)) {
                    sectionImages[i].color = Color.green;
                }
            }
        }
    }

    public void PressLeftPartArow() {
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
            } 
        } else if (currentSection == 2) {
            if (currentPart == 1) {
                ShowSection1Part5();
            } else if (currentPart == 2) {
                ShowSection2Part1();
            } else if (currentPart == 3) {
                ShowSection2Part2();
            } else if (currentPart == 4) {
                ShowSection2Part3();
            } 
        } else if (currentSection == 3) {
            if (currentPart == 1) {
                ShowSection2Part4();
            } else if (currentPart == 2) {
                ShowSection3Part1();
            } else if (currentPart == 3) {
                ShowSection3Part2();
            } else if (currentPart == 4) {
                ShowSection3Part3();
            } else if (currentPart == 5) {
                ShowSection3Part4();
            }
        } else if (currentSection == 4) {
            if (currentPart == 1) {
                ShowSection3Part5();
            } else if (currentPart == 2) {
                ShowSection4Part1();
            } else if (currentPart == 3) {
                ShowSection4Part2();
            } else if (currentPart == 4) {
                ShowSection4Part3();
            } 
        } else if (currentSection == 5) {
            if (currentPart == 1) {
                ShowSection4Part4();
            } else if (currentPart == 2) {
                ShowSection5Part1();
            } else if (currentPart == 3) {
                ShowSection5Part2();
            } else if (currentPart == 4) {
                ShowSection5Part3();
            } else if (currentPart == 5) {
                ShowSection5Part4();
            } else if (currentPart == 6) {
                ShowSection5Part5();
            }
        }
    }

    public void PressRightPartArow() {
        if (!ES3.Load("protocolsSection" + currentSection + "Part" + currentPart, false)) {
            skipPartWindow.SetActive(true);
            skipWindowDarkening.SetActive(true);
            return;
        }

        ES3.Save("protocolsSection" + currentSection + "Part" + currentPart, true);

        if (currentPart == maxPartSection[currentSection - 1]) {
            ES3.Save("protocolsSection" + currentSection + "Completed", true);
            ES3.Save("protocolsSection" + (currentSection + 1) + "Unlocked", true);
        }

        if (currentSection == maxSection && currentPart == maxPartSection[currentSection - 1]) {
            ES3.Save("protocolsCompleted", true);
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
                ShowSection2Part1();
            }

        } else if (currentSection == 2) {
            if (currentPart == 1) {
                ShowSection2Part2();
            } else if (currentPart == 2) {
                ShowSection2Part3();
            } else if (currentPart == 3) {
                ShowSection2Part4();
            } else if (currentPart == 4) {
                ShowSection3Part1();
            }

        } else if (currentSection == 3) {
            if (currentPart == 1) {
                ShowSection3Part2();
            } else if (currentPart == 2) {
                ShowSection3Part3();
            } else if (currentPart == 3) {
                ShowSection3Part4();
            } else if (currentPart == 4) {
                ShowSection3Part5();
            } else if (currentPart == 5) {
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
                ShowSection5Part6();
            } else if (currentPart == 6) {
                ClickHomeButton();
            }
        }
    }

    public void ShowSection1Part1() {
        SetCurrentSection(1);
        SetCurrentPart(1);

        s1p1protocolsIntro.SetActive(true);
        s1p1protocolsIntroControl.ResetIntro();
        s1p1protocolsTitle.SetActive(true);
        s1p1protocolsText.SetActive(true);
        s1p1protocolsText.GetComponent<TextAnimatorPlayer>().ShowText(s1p1protocolsText.GetComponent<TextMeshProUGUI>().text);
    }

    public void ShowSection1Part2() {
        SetCurrentSection(1);
        SetCurrentPart(2);
        hintsControl.SetCurrentPuzzle("ProtocolAttack1");

        s1p2simpleAttackTitle.SetActive(true);
        protocolAttackFramework.SetActive(true);
        s1p2protocolAttack1Text.SetActive(true);
        s1p2protocolAttack1Text.GetComponent<TextAnimatorPlayer>().ShowText(s1p2protocolAttack1Text.GetComponent<TextMeshProUGUI>().text);
    }

    public void ShowSection1Part3() {
        SetCurrentSection(1);
        SetCurrentPart(3);

        s1p3nonceTitle.SetActive(true);
        s1p3nonceText.SetActive(true);
        s1p3nonceText.GetComponent<TextAnimatorPlayer>().ShowText(s1p3nonceText.GetComponent<TextMeshProUGUI>().text);
    }

    public void ShowSection1Part4() {
        SetCurrentSection(1);
        SetCurrentPart(4);
        hintsControl.SetCurrentPuzzle("ProtocolAttack2");

        s1p3nonceTitle.SetActive(true);
        protocolAttackFramework.SetActive(true);
        s1p4protocolAttack2Text.SetActive(true);
        s1p4protocolAttack2Text.GetComponent<TextAnimatorPlayer>().ShowText(s1p4protocolAttack2Text.GetComponent<TextMeshProUGUI>().text);
    }

    public void ShowSection1Part5() {
        SetCurrentSection(1);
        SetCurrentPart(5);

        s1p5protocolFixTitle.SetActive(true);
        s1p5protocolFixSteps.SetActive(true);
        s1p5protocolFixSteps.transform.localScale = new Vector3(0, 0, 0);
        s1p5protocolFixText.SetActive(true);
        s1p5protocolFixText.GetComponent<TextAnimatorPlayer>().ShowText(s1p5protocolFixText.GetComponent<TextMeshProUGUI>().text);
    }

    public void ShowSection2Part1() {
        SetCurrentSection(2);
        SetCurrentPart(1);

        s2p1keyEstablishmentTitle.SetActive(true);
        s2p1keyEstablishmentText.SetActive(true);
        s2p1keyEstablishmentText.GetComponent<TextAnimatorPlayer>().ShowText(s2p1keyEstablishmentText.GetComponent<TextMeshProUGUI>().text);
    }

    public void ShowSection2Part2() {
        SetCurrentSection(2);
        SetCurrentPart(2);

        s2p2needhamTitle.SetActive(true);
        s2p2needhamVulnerable.SetActive(true);
        s2p2needhamVulnerable.transform.localScale = new Vector3(0, 0, 0);
        s2p2needhamVulnerableText1.SetActive(true);
        s2p2needhamVulnerableText1.GetComponent<TextAnimatorPlayer>().ShowText(s2p2needhamVulnerableText1.GetComponent<TextMeshProUGUI>().text);
    }

    public void ShowSection2Part3() {
        SetCurrentSection(2);
        SetCurrentPart(3);
        hintsControl.SetCurrentPuzzle("ProtocolAttack3");

        s2p2needhamTitle.SetActive(true);
        protocolAttackFramework.SetActive(true);
        s2p3protocolAttack3Text.SetActive(true);
        s2p3protocolAttack3Text.GetComponent<TextAnimatorPlayer>().ShowText(s2p3protocolAttack3Text.GetComponent<TextMeshProUGUI>().text);
    }

    public void ShowSection2Part4() {
        SetCurrentSection(2);
        SetCurrentPart(4);

        s2p2needhamTitle.SetActive(true);
        s2p4needhamFix.SetActive(true);
        s2p4needhamFix.transform.localScale = new Vector3(0, 0, 0);
        s2p4needhamFixText.SetActive(true);
        s2p4needhamFixText.GetComponent<TextAnimatorPlayer>().ShowText(s2p4needhamFixText.GetComponent<TextMeshProUGUI>().text);
    }

    public void ShowSection3Part1() {
        SetCurrentSection(3);
        SetCurrentPart(1);

        s3p1forwardSecrecyTitle.SetActive(true);
        s3p1forwardSecrecyText.SetActive(true);
        s3p1forwardSecrecy.SetActive(true);
        s3p1forwardSecrecy.transform.localScale = new Vector3(0, 0, 0);
        s3p1forwardSecrecyText.GetComponent<TextAnimatorPlayer>().ShowText(s3p1forwardSecrecyText.GetComponent<TextMeshProUGUI>().text);
    }

    public void ShowSection3Part2() {
        SetCurrentSection(3);
        SetCurrentPart(2);

        s3p1forwardSecrecyTitle.SetActive(true);
        s3p2forwardSecrecyExplanationText.SetActive(true);
        s3p2forwardSecrecyExplanationText.GetComponent<TextAnimatorPlayer>().ShowText(s3p2forwardSecrecyExplanationText.GetComponent<TextMeshProUGUI>().text);
    }

    public void ShowSection3Part3() {
        SetCurrentSection(3);
        SetCurrentPart(3);

        s3p3stationToStationTitle.SetActive(true);
        s3p3stationToStation.transform.localScale = new Vector3(0, 0, 0);
        s3p3stationToStation.SetActive(true);
        s3p3stationToStation.GetComponent<DOTweenAnimation>().DORestart();
    }

    public void ShowSection3Part4() {
        SetCurrentSection(3);
        SetCurrentPart(4);

        s3p3stationToStationTitle.SetActive(true);
        s3p4stationVulnerabilityText.SetActive(true);
        s3p4stationVulnerabilityText.GetComponent<TextAnimatorPlayer>().ShowText(s3p4stationVulnerabilityText.GetComponent<TextMeshProUGUI>().text);
        s3p4stationVulnerabilityProtocol.SetActive(true);
        s3p4stationVulnerabilityProtocol.transform.localScale = new Vector3(0, 0, 0);
    }

    public void ShowSection3Part5() {
        SetCurrentSection(3);
        SetCurrentPart(5);
        hintsControl.SetCurrentPuzzle("ProtocolAttack4");

        s3p3stationToStationTitle.SetActive(true);
        protocolAttackFramework.SetActive(true);
        s3p5protocolAttack4Text.SetActive(true);
        s3p5protocolAttack4Text.GetComponent<TextAnimatorPlayer>().ShowText(s3p5protocolAttack4Text.GetComponent<TextMeshProUGUI>().text);
    }

    public void ShowSection4Part1() {
        SetCurrentSection(4);
        SetCurrentPart(1);

        s4p1certificateTitle.SetActive(true);
        s4p1certificatesText.SetActive(true);
        s4p1certificatesText.GetComponent<TextAnimatorPlayer>().ShowText(s4p1certificatesText.GetComponent<TextMeshProUGUI>().text);
    }

    public void ShowSection4Part2() {
        SetCurrentSection(4);
        SetCurrentPart(2);

        s4p1certificateTitle.SetActive(true);
        s4p2certificatesText1.SetActive(true);
        s4p2certificatesText1.GetComponent<TextAnimatorPlayer>().ShowText(s4p2certificatesText1.GetComponent<TextMeshProUGUI>().text);
        s4p2certificatesProtocol.SetActive(true);
        s4p2certificatesProtocol.transform.localScale = new Vector3(0, 0, 0);
    }

    public void ShowSection4Part3() {
        SetCurrentSection(4);
        SetCurrentPart(3);
        hintsControl.SetCurrentPuzzle("ProtocolAttack5");

        s4p1certificateTitle.SetActive(true);
        protocolAttackFramework.SetActive(true);
        s4p3protocolAttack5Text.SetActive(true);
        s4p3protocolAttack5Text.GetComponent<TextAnimatorPlayer>().ShowText(s4p3protocolAttack5Text.GetComponent<TextMeshProUGUI>().text);
    }

    public void ShowSection4Part4() {
        SetCurrentSection(4);
        SetCurrentPart(4);

        s4p4protocolGoalsTitle.SetActive(true);
        s4p4protocolGoalsText.SetActive(true);
        s4p4protocolGoalsText.GetComponent<TextAnimatorPlayer>().ShowText(s4p4protocolGoalsText.GetComponent<TextMeshProUGUI>().text);
    }

    public void ShowSection5Part1() {
        SetCurrentSection(5);
        SetCurrentPart(1);

        s5p1protocolAttacksTitle.SetActive(true);
        s5p1protocol6Text.SetActive(true);
        s5p1protocol6Text.GetComponent<TextAnimatorPlayer>().ShowText(s5p1protocol6Text.GetComponent<TextMeshProUGUI>().text);
        s5p1protocol6.SetActive(true);
        s5p1protocol6.transform.localScale = new Vector3(0, 0, 0);
    }

    public void ShowSection5Part2() {
        SetCurrentSection(5);
        SetCurrentPart(2);
        hintsControl.SetCurrentPuzzle("ProtocolAttack6");

        s5p1protocolAttacksTitle.SetActive(true);
        protocolAttackFramework.SetActive(true);
        s5p2protocolAttack6Text.SetActive(true);
        s5p2protocolAttack6Text.GetComponent<TextAnimatorPlayer>().ShowText(s5p2protocolAttack6Text.GetComponent<TextMeshProUGUI>().text);
    }

    public void ShowSection5Part3() {
        SetCurrentSection(5);
        SetCurrentPart(3);

        s5p1protocolAttacksTitle.SetActive(true);
        s5p3protocol7Text.SetActive(true);
        s5p3protocol7Text.GetComponent<TextAnimatorPlayer>().ShowText(s5p3protocol7Text.GetComponent<TextMeshProUGUI>().text);
        s5p3protocol7.SetActive(true);
        s5p3protocol7.transform.localScale = new Vector3(0, 0, 0);
    }

    public void ShowSection5Part4() {
        SetCurrentSection(5);
        SetCurrentPart(4);
        hintsControl.SetCurrentPuzzle("ProtocolAttack7");

        s5p1protocolAttacksTitle.SetActive(true);
        protocolAttackFramework.SetActive(true);
        s5p4protocolAttack7Text.SetActive(true);
        s5p4protocolAttack7Text.GetComponent<TextAnimatorPlayer>().ShowText(s5p4protocolAttack7Text.GetComponent<TextMeshProUGUI>().text);
    }

    public void ShowSection5Part5() {
        SetCurrentSection(5);
        SetCurrentPart(5);

        s5p1protocolAttacksTitle.SetActive(true);
        s5p5protocol8Text.SetActive(true);
        s5p5protocol8Text.GetComponent<TextAnimatorPlayer>().ShowText(s5p5protocol8Text.GetComponent<TextMeshProUGUI>().text);
        s5p5protocol8.SetActive(true);
        s5p5protocol8.transform.localScale = new Vector3(0, 0, 0);
    }

    public void ShowSection5Part6() {
        SetCurrentSection(5);
        SetCurrentPart(6);
        hintsControl.SetCurrentPuzzle("ProtocolAttack8");

        s5p1protocolAttacksTitle.SetActive(true);
        protocolAttackFramework.SetActive(true);
        s5p6protocolAttack8Text.SetActive(true);
        s5p6protocolAttack8Text.GetComponent<TextAnimatorPlayer>().ShowText(s5p6protocolAttack8Text.GetComponent<TextMeshProUGUI>().text);
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
        protocolAttackFramework.transform.localScale = new Vector3(0, 0, 0);
        protocolAttackFramework.SetActive(false);
        ES3.Save("protocolsLastPart", currentPart);

        if (ES3.Load("protocolsSection" + currentSection + "Part" + currentPart, false)) {
            rightArrow.gameObject.GetComponent<Image>().color = Color.white;
        } else {
            rightArrow.gameObject.GetComponent<Image>().color = Color.red;
        }

        CheckSaveSections();
    }

    private void SetCurrentSection(int n) {
        hintButton.SetActive(false);
        HideAllSections();
        leftArrow.interactable = true;
        rightArrow.interactable = true;
        maxPartText.text = maxPartSection[n - 1].ToString();
        currentSection = n;
        protocolAttackFramework.transform.localScale = new Vector3(0, 0, 0);
        protocolAttackFramework.SetActive(false);
        ES3.Save("protocolsLastSection", currentSection);

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

    public void ClickSection1() {
        if (!ES3.Load("protocolsSection1Unlocked", false)) {
            skipSectionWindow.SetActive(true);
            skipWindowDarkening.SetActive(true);
            sectionClicked = 1;
            return;
        }
        ShowSection1Part1();
    }

    public void ClickSection2() {
        if (!ES3.Load("protocolsSection2Unlocked", false)) {
            skipSectionWindow.SetActive(true);
            skipWindowDarkening.SetActive(true);
            sectionClicked = 2;
            return;
        }
        ShowSection2Part1();
    }

    public void ClickSection3() {
        if (!ES3.Load("protocolsSection3Unlocked", false)) {
            skipSectionWindow.SetActive(true);
            skipWindowDarkening.SetActive(true);
            sectionClicked = 3;
            return;
        }
        ShowSection3Part1();
    }

    public void ClickSection4() {
        if (!ES3.Load("protocolsSection4Unlocked", false)) {
            skipSectionWindow.SetActive(true);
            skipWindowDarkening.SetActive(true);
            sectionClicked = 4;
            return;
        }
        ShowSection4Part1();
    }

    public void ClickSection5() {
        if (!ES3.Load("protocolsSection5Unlocked", false)) {
            skipSectionWindow.SetActive(true);
            skipWindowDarkening.SetActive(true);
            sectionClicked = 5;
            return;
        }
        ShowSection5Part1();
    }

    public void ClickHomeButton() {
        SceneManager.LoadScene("MainMenu");
    }

    public void ClickContinue() {
        ES3.Save("protocolsSection" + currentSection + "Part" + currentPart, true);
        PressRightPartArow();
    }

    public void ClickYesSkipPartWindow() {
        ES3.Save("protocolsSection" + currentSection + "Part" + currentPart, true);
        skipPartWindow.SetActive(false);
        skipWindowDarkening.SetActive(false);
        PressRightPartArow();
    }

    public void ClickYesSkipSectionWindow() {
        ES3.Save("protocolsSection" + sectionClicked + "Unlocked", true);
        for (int i = 1; i < sectionClicked; i++) {
            ES3.Save("protocolsSection" + i + "Unlocked", true);
            ES3.Save("protocolsSection" + i + "Completed", true);
            for (int j = 1; j <= maxPartSection[i - 1]; j++) {
                ES3.Save("protocolsSection" + i + "Part" + j, true);
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
