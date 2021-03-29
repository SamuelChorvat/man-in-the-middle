using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroCryptoController : MonoBehaviour
{
    public ChapterButton chapter1Script;
    public ChapterButton chapter2Script;
    public ChapterButton chapter3Script;
    public ChapterButton chapter4Script;

    public void ClickBackButton() {
        SceneManager.LoadScene("MainMenu");
    }

    public void Awake() {
        chapter1Script.SetUnlocked(false);
        chapter2Script.SetUnlocked(false);
        chapter3Script.SetUnlocked(false);
        chapter4Script.SetUnlocked(false);

        if (ES3.Load("introChapter1Unlocked", true)) {
            chapter1Script.SetUnlocked(true);
        }

        if (ES3.Load("introChapter1Completed", false)) {
            chapter1Script.SetCompleted();
        }

        if (ES3.Load("introChapter2Unlocked", false)) {
            chapter2Script.SetUnlocked(true);
        }

        if (ES3.Load("introChapter2Completed", false)) {
            chapter2Script.SetCompleted();
        }

        if (ES3.Load("introChapter3Unlocked", false)) {
            chapter3Script.SetUnlocked(true);
        }

        if (ES3.Load("introChapter3Completed", false)) {
            chapter3Script.SetCompleted();
        }

        if (ES3.Load("introChapter4Unlocked", false)) {
            chapter4Script.SetUnlocked(true);
        }

        if (ES3.Load("introChapter4Completed", false)) {
            chapter4Script.SetCompleted();
        }
    }

    public void ClickGoChapter1() {
        if (ES3.Load("introChapter1Unlocked", true)) {
            SceneManager.LoadScene("Intro1");
        }
    }

    public void ClickGoChapter2() {
        if (ES3.Load("introChapter2Unlocked", false)) {
            SceneManager.LoadScene("Intro2");
        }
    }

    public void ClickGoChapter3() {
        if (ES3.Load("introChapter3Unlocked", false)) {
            SceneManager.LoadScene("Intro3");
        }
    }

    public void ClickGoChapter4() {
        if (ES3.Load("introChapter3Unlocked", false)) {
            SceneManager.LoadScene("Intro4");
        }
    }
}
