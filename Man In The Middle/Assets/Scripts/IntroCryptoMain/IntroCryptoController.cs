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

    private bool chapter1Unlocked = false;
    private bool chapter1Completed = false;
    private bool chapter2Unlocked = false;
    private bool chapter2Completed = false;
    private bool chapter3Unlocked = false;
    private bool chapter3Completed = false;
    private bool chapter4Unlocked = false;
    private bool chapter4Completed = false;

    public void ClickBackButton() {
        SceneManager.LoadScene("MainMenu");
    }

    public void Awake() {
        chapter1Script.SetUnlocked(false);
        chapter2Script.SetUnlocked(false);
        chapter3Script.SetUnlocked(false);
        chapter4Script.SetUnlocked(false);
        chapter1Unlocked = ES3.Load("introChapter1Unlocked", true);
        chapter1Completed = ES3.Load("introChapter1Completed", false);
        chapter2Unlocked = ES3.Load("introChapter2Unlocked", false);
        chapter2Completed = ES3.Load("introChapter2Completed", false);
        chapter3Unlocked = ES3.Load("introChapter3Unlocked", false);
        chapter3Completed = ES3.Load("introChapter3Completed", false);
        chapter4Unlocked = ES3.Load("introChapter4Unlocked", false);
        chapter4Completed = ES3.Load("introChapter4Completed", false);

        if (chapter1Unlocked) {
            chapter1Script.SetUnlocked(true);

            if (chapter1Completed) {
                chapter1Script.SetCompleted();
            }
        }

        if (chapter2Unlocked) {
            chapter2Script.SetUnlocked(true);

            if (chapter2Completed) {
                chapter2Script.SetCompleted();
            }
        }

        if (chapter3Unlocked) {
            chapter3Script.SetUnlocked(true);

            if (chapter3Completed) {
                chapter3Script.SetCompleted();
            }
        }

        if (chapter4Unlocked) {
            chapter4Script.SetUnlocked(true);

            if (chapter4Completed) {
                chapter4Script.SetCompleted();
            }
        }
    }

    public void ClickGoChapter1() {
        if (chapter1Unlocked) {
            SceneManager.LoadScene("Intro1");
        }
    }

    public void ClickGoChapter2() {
        if (chapter2Unlocked) {
            SceneManager.LoadScene("Intro2");
        }
    }

    public void ClickGoChapter3() {
        if (chapter3Unlocked) {
            SceneManager.LoadScene("Intro3");
        }
    }

    public void ClickGoChapter4() {
        if (chapter4Unlocked) {
            SceneManager.LoadScene("Intro4");
        }
    }
}
