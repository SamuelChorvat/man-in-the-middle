using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro3Controller : MonoBehaviour
{
    [Header("Sections")]
    public GameObject[] sections;

    [Header("Section objects")]
    public GameObject[] s1objects;
    public GameObject[] s2objects;
    public GameObject[] s3objects;
    public GameObject[] s4objects;

    [Header("Section 1 Part 1")]
    public GameObject s1p1blockTitle;
    public GameObject s1p1blockText;

    [Header("Section 1 Part 2")]
    public GameObject s1p2blockExampleTitle;
    public GameObject s1p2blockExampleText;

    [Header("Section 2 Part 1")]
    public GameObject s2p1desBruteforceTitle;
    public GameObject s2p1desBruteforceText;

    [Header("Section 3 Part 1")]
    public GameObject s3p1blockCipherModesTitle;
    public GameObject s3p1blockCipherModesText;

    [Header("Section 3 Part 2")]
    public GameObject s3p2ecbTitle;
    public GameObject s3p2ecbText;

    [Header("Section 3 Part 3")]
    public GameObject s3p3cbcTitle;
    public GameObject s3p3cbcText;

    [Header("Section 4 Part 1")]
    public GameObject s4p1cbcIssueTitle;
    public GameObject s4p1cbcIssueText;

    [Header("Section 4 Part 2")]
    public GameObject s4p2consoleAttackTitle;
    public GameObject s4p2consoleAttackText;

    [Header("Section 4 Part 3")]
    public GameObject s4p3ctrTitle;
    public GameObject s4p3ctrText;


    // Start is called before the first frame update
    void Start()
    {
        ShowSection4Part3();
    }

    public void ShowSection1Part1() {
        PrepareShow(1);
        s1p1blockTitle.SetActive(true);
        s1p1blockText.SetActive(true);
    }

    public void ShowSection1Part2() {
        PrepareShow(1);
        s1p2blockExampleTitle.SetActive(true);
        s1p2blockExampleText.SetActive(true);
    }

    public void ShowSection2Part1() {
        PrepareShow(2);
        s2p1desBruteforceTitle.SetActive(true);
        s2p1desBruteforceText.SetActive(true);
    }

    public void ShowSection3Part1() {
        PrepareShow(3);
        s3p1blockCipherModesTitle.SetActive(true);
        s3p1blockCipherModesText.SetActive(true);
    }

    public void ShowSection3Part2() {
        PrepareShow(3);
        s3p2ecbTitle.SetActive(true);
        s3p2ecbText.SetActive(true);
    }

    public void ShowSection3Part3() {
        PrepareShow(3);
        s3p3cbcTitle.SetActive(true);
        s3p3cbcText.SetActive(true);
    }

    public void ShowSection4Part1() {
        PrepareShow(4);
        s4p1cbcIssueTitle.SetActive(true);
        s4p1cbcIssueText.SetActive(true);
    }

    public void ShowSection4Part2() {
        PrepareShow(4);
        s4p2consoleAttackTitle.SetActive(true);
        s4p2consoleAttackText.SetActive(true);
    }

    public void ShowSection4Part3() {
        PrepareShow(4);
        s4p3ctrTitle.SetActive(true);
        s4p3ctrText.SetActive(true);
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

}
