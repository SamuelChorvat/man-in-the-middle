using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro1Controller : MonoBehaviour
{
    [Header("Sections")]
    public GameObject[] sections;

    [Header("Section objects")]
    public GameObject[] s1objects;
    public GameObject[] s2objects;
    public GameObject[] s3objects;
    public GameObject[] s4objects;

    [Header("Section 1 Part 1")]
    public GameObject s1p1cipherTitle;
    public GameObject s1p1cipherText;

    [Header("Section 2 Part 1")]
    public GameObject s2p1caesarTitle;
    public GameObject s2p1caesarText;

    [Header("Section 2 Part 2")]
    public GameObject s2p2caesarIntroPuzzleTextAnimated;
    public GameObject s2p2caesarIntroPuzzle;

    [Header("Section 2 Part 2")]
    public GameObject s2p3caesarIntroProblemsText;

    [Header("Section 3 Part 1")]
    public GameObject s3p1caesarTitle;
    public GameObject s3p1caesarImprovementText;

    [Header("Section 3 Part 2")]
    public GameObject s3p2caesarImprovementPuzzleTextAnimated;

    [Header("Section 4 Part 1")]
    public GameObject s4p1caesarTitle;
    public GameObject s4p1caesarImprovementText;

    [Header("Section 4 Part 2")]
    public GameObject s4p2caesarProblemText;

    [Header("Section 4 Part 3")]
    public GameObject s4p3caesarPuzzleText;
    public GameObject s4p3frequencyAnalysisDemo;


    public void Start() {
        ShowSection4Part2();
    }

    public void ShowSection1Part1() {
        PrepareShow(1);
        s1p1cipherTitle.SetActive(true);
        s1p1cipherText.SetActive(true);
    }

    public void ShowSection2Part1() {
        PrepareShow(2);
        s2p1caesarTitle.SetActive(true);
        s2p1caesarText.SetActive(true);
    }

    public void ShowSection2Part2() {
        PrepareShow(2);
        s2p1caesarTitle.SetActive(true);
        s2p2caesarIntroPuzzleTextAnimated.SetActive(true);
        s2p2caesarIntroPuzzle.SetActive(true);
    }

    public void ShowSection2Part3() {
        PrepareShow(2);
        s2p1caesarTitle.SetActive(true);
        s2p3caesarIntroProblemsText.SetActive(true);
    }
    
    public void ShowSection3Part1() {
        PrepareShow(3);
        s3p1caesarTitle.SetActive(true);
        s3p1caesarImprovementText.SetActive(true);
    }

    public void ShowSection3Part2() {
        PrepareShow(3);
        s3p1caesarTitle.SetActive(true);
        s3p2caesarImprovementPuzzleTextAnimated.SetActive(true);
    }

    public void ShowSection4Part1() {
        PrepareShow(4);
        s4p1caesarTitle.SetActive(true);
        s4p1caesarImprovementText.SetActive(true);
    }

    public void ShowSection4Part2() {
        PrepareShow(4);
        s4p1caesarTitle.SetActive(true);
        s4p2caesarProblemText.SetActive(true);
    }

    public void ShowSection4Part3() {
        PrepareShow(4);
        s4p1caesarTitle.SetActive(true);
        s4p3caesarPuzzleText.SetActive(true);
        s4p3frequencyAnalysisDemo.SetActive(true);
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
