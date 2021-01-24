using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro4Controller : MonoBehaviour
{

    [Header("Sections")]
    public GameObject[] sections;

    [Header("Section objects")]
    public GameObject[] s1objects;
    public GameObject[] s2objects;
    public GameObject[] s3objects;
    public GameObject[] s4objects;
    public GameObject[] s5objects;

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

    [Header("Section 5 Part 5")]
    public GameObject s5p5authenticatedTitle;
    public GameObject s5p5authenticatedText;

    void Start()
    {
        ShowSection5Part5();
    }

    public void ShowSection1Part1() {
        PrepareShow(1);
        s1p1keyProblemTitle.SetActive(true);
        s1p1keyProblemText.SetActive(true);
    }

    public void ShowSection1Part2() {
        PrepareShow(1);
        s1p2publicKeyEncryptionTitle.SetActive(true);
        s1p2publicKeyEncryptionText.SetActive(true);
    }

    public void ShowSection1Part3() {
        PrepareShow(1);
        s1p3diffieHellmanTitle.SetActive(true);
        s1p3diffieHellmanText.SetActive(true);
    }

    public void ShowSection1Part4() {
        PrepareShow(1);
        s1p3diffieHellmanTitle.SetActive(true);
        s1p4diffieHellmanText.SetActive(true);
    }

    public void ShowSection1Part5() {
        PrepareShow(1);
        s1p3diffieHellmanTitle.SetActive(true);
        s1p5diffieHellmanText.SetActive(true);
    }

    public void ShowSection1Part6() {
        PrepareShow(1);
        s1p3diffieHellmanTitle.SetActive(true);
        s1p6diffieHellmanDemo.SetActive(true);
    }

    public void ShowSection2Part1() {
        PrepareShow(2);
        s2p1elgamalTitle.SetActive(true);
        s2p1elgamalText.SetActive(true);  
    }

    public void ShowSection2Part2() {
        PrepareShow(2);
        s2p2rsaTitle.SetActive(true);
        s2p2rsaText.SetActive(true);
    }

    public void ShowSection2Part3() {
        PrepareShow(2);
        s2p3pkcTitle.SetActive(true);
        s2p3pkcText.SetActive(true);
    }

    public void ShowSection3Part1() {
        PrepareShow(3);
        s3p1signaturesTitle.SetActive(true);
        s3p1signaturesText.SetActive(true);
    }

    public void ShowSection3Part2() {
        PrepareShow(3);
        s3p1signaturesTitle.SetActive(true);
        s3p2signaturesTrickText.SetActive(true);
        s3p2signaturesTrickDemo.SetActive(true);
    }

    public void ShowSection3Part3() {
        PrepareShow(3);
        s3p3certificatesTitle.SetActive(true);
        s3p3certificatesText.SetActive(true);
    }

    public void ShowSection4Part1() {
        PrepareShow(4);
        s4p1hashesTitle.SetActive(true);
        s4p1hashesText.SetActive(true);
    }

    public void ShowSection4Part2() {
        PrepareShow(4);
        s4p1hashesTitle.SetActive(true);
        s4p2hashesDemoText.SetActive(true);
    }

    public void ShowSection4Part3() {
        PrepareShow(4);
        s4p3usesHashesTitle.SetActive(true);
        s4p3usesHashesText.SetActive(true);
    }

    public void ShowSection4Part4() {
        PrepareShow(4);
        s4p4hashesAttacksTitle.SetActive(true);
        s4p4hashesAttacksText.SetActive(true);
    }

    public void ShowSection4Part5() {
        PrepareShow(4);
        s4p5birthdayTitle.SetActive(true);
        s4p5birthdayText.SetActive(true);
    }

    public void ShowSection4Part6() {
        PrepareShow(4);
        s4p6hashesTypesTitle.SetActive(true);
        s4p6hashesTypesText.SetActive(true);
    }

    public void ShowSection5Part1() {
        PrepareShow(5);
        s5p1macTitle.SetActive(true);
        s5p1macText.SetActive(true);
    }

    public void ShowSection5Part2() {
        PrepareShow(5);
        s5p2alteringTitle.SetActive(true);
        s5p2alteringText.SetActive(true);
    }

    public void ShowSection5Part3() {
        PrepareShow(5);
        s5p3knownTitle.SetActive(true);
        s5p3knownText.SetActive(true);
    }

    public void ShowSection5Part4() {
        PrepareShow(5);
        s5p3knownTitle.SetActive(true);
        s5p4knownAttackDemoText.SetActive(true);
        s5p4knownAttackDemo.SetActive(true);
    }

    public void ShowSection5Part5() {
        PrepareShow(5);
        s5p5authenticatedTitle.SetActive(true);
        s5p5authenticatedText.SetActive(true);
    }

    private void PrepareShow(int n) {
        HideAllSections();

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


}
