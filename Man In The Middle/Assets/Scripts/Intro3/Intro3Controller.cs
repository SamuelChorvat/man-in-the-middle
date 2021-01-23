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

    // Start is called before the first frame update
    void Start()
    {
        ShowSection1Part2();
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
