using Febucci.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Protocols1Controller : MonoBehaviour
{
    [Header("Continue Button")]
    public RevealContinueButton continueButton;

    [Header("Sections")]
    public GameObject[] sections;

    [Header("Section objects")]
    public GameObject[] s1objects;
    public GameObject[] s2objects;
    public GameObject[] s3objects;
    public GameObject[] s4objects;
    public GameObject[] s5objects;

    [Header("Part Control Objects")]
    public Button leftArrow;
    public Button rightArrow;
    public TextMeshProUGUI currentPartText;
    public TextMeshProUGUI maxPartText;

    private int[] maxPartSection = new int[] { 5, 4, 5, 4, 6};

    private int currentSection;
    private int currentPart;

    [Header("General")]
    public GameObject protocolAttackFramework;

    [Header("Section 1 Part 1")]
    public GameObject s1p1protocolsTitle;
    public GameObject s1p1protocolsText;
    public ProtocolsIntroControl s1p1protocolsIntroControl;
    public GameObject s1p1protocolsIntro;

    void Start() {
        ShowSection1Part1();
    }

    public void PressLeftPartArow() {
        if (currentSection == 1) {
            if (currentPart == 1) {
                //nothing
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
                //nothing
            } else if (currentPart == 2) {
                ShowSection2Part1();
            } else if (currentPart == 3) {
                ShowSection2Part2();
            } else if (currentPart == 4) {
                ShowSection2Part3();
            } 
        } else if (currentSection == 3) {
            if (currentPart == 1) {
                //nothing
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
                //nothing
            } else if (currentPart == 2) {
                ShowSection4Part1();
            } else if (currentPart == 3) {
                ShowSection4Part2();
            } else if (currentPart == 4) {
                ShowSection4Part3();
            } 
        } else if (currentSection == 5) {
            if (currentPart == 1) {
                //nothing
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
        if (currentSection == 1) {
            if (currentPart == 1) {
                ShowSection1Part2();
            } else if (currentPart == 2) {
                ShowSection1Part3();
            } else if (currentPart == 3) {
                ShowSection1Part4();
            } else if (currentPart == 4) {
                ShowSection1Part5();
            } 

        } else if (currentSection == 2) {
            if (currentPart == 1) {
                ShowSection2Part2();
            } else if (currentPart == 2) {
                ShowSection2Part3();
            } else if (currentPart == 3) {
                ShowSection2Part4();
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
            } 

        } else if (currentSection == 4) {
            if (currentPart == 1) {
                ShowSection4Part2();
            } else if (currentPart == 2) {
                ShowSection4Part3();
            } else if (currentPart == 3) {
                ShowSection4Part4();
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
    }

    public void ShowSection1Part3() {
        SetCurrentSection(1);
        SetCurrentPart(3);

    }

    public void ShowSection1Part4() {
        SetCurrentSection(1);
        SetCurrentPart(4);

    }

    public void ShowSection1Part5() {
        SetCurrentSection(1);
        SetCurrentPart(5);

    }

    public void ShowSection2Part1() {
        SetCurrentSection(2);
        SetCurrentPart(1);

    }

    public void ShowSection2Part2() {
        SetCurrentSection(2);
        SetCurrentPart(2);
    }

    public void ShowSection2Part3() {
        SetCurrentSection(2);
        SetCurrentPart(3);

    }

    public void ShowSection2Part4() {
        SetCurrentSection(2);
        SetCurrentPart(4);

    }

    public void ShowSection3Part1() {
        SetCurrentSection(3);
        SetCurrentPart(1);

    }

    public void ShowSection3Part2() {
        SetCurrentSection(3);
        SetCurrentPart(2);

    }

    public void ShowSection3Part3() {
        SetCurrentSection(3);
        SetCurrentPart(3);
    }

    public void ShowSection3Part4() {
        SetCurrentSection(3);
        SetCurrentPart(4);

    }

    public void ShowSection3Part5() {
        SetCurrentSection(3);
        SetCurrentPart(5);

    }

    public void ShowSection4Part1() {
        SetCurrentSection(4);
        SetCurrentPart(1);

    }

    public void ShowSection4Part2() {
        SetCurrentSection(4);
        SetCurrentPart(2);
    }

    public void ShowSection4Part3() {
        SetCurrentSection(4);
        SetCurrentPart(3);

    }

    public void ShowSection4Part4() {
        SetCurrentSection(4);
        SetCurrentPart(4);

    }

    public void ShowSection5Part1() {
        SetCurrentSection(5);
        SetCurrentPart(1);

    }

    public void ShowSection5Part2() {
        SetCurrentSection(5);
        SetCurrentPart(2);
    }

    public void ShowSection5Part3() {
        SetCurrentSection(5);
        SetCurrentPart(3);
    }

    public void ShowSection5Part4() {
        SetCurrentSection(5);
        SetCurrentPart(4);
    }

    public void ShowSection5Part5() {
        SetCurrentSection(5);
        SetCurrentPart(5);
    }

    public void ShowSection5Part6() {
        SetCurrentSection(5);
        SetCurrentPart(6);
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

    private void HideSection5() {
        for (int i = 0; i < s5objects.Length; i++) {
            s5objects[i].SetActive(false);
        }
    }

    public void SetCurrentPart(int cPart) {
        continueButton.ResetButton();
        currentPart = cPart;
        currentPartText.text = currentPart.ToString();
        protocolAttackFramework.transform.localScale = new Vector3(0, 0, 0);

        if (currentPart == 1) {
            leftArrow.interactable = false;
        }

        if (currentPart == maxPartSection[currentSection - 1]) {
            rightArrow.interactable = false;
        }
    }

    private void SetCurrentSection(int n) {
        HideAllSections();
        leftArrow.interactable = true;
        rightArrow.interactable = true;
        maxPartText.text = maxPartSection[n - 1].ToString();
        currentSection = n;
        protocolAttackFramework.transform.localScale = new Vector3(0, 0, 0);

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

        sections[n - 1].SetActive(true);
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

    public void ClickSection5() {
        ShowSection5Part1();
    }
}
