using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject canvas;
    public GameObject logo;
    public GameObject title;
    public GameObject introSec;
    public GameObject attackSec;
    public GameObject keyHoleIm;
    public GameObject lockedWindow;
    public GameObject lockedWindowBg;

    public Text introText;
    public Text attackText;


    private bool titleRevealed = false;
    private bool attacksRevealed = false;
    private bool attackTextRevealed = false;
    private bool firstTime = true;
    

    private void Awake() {
        firstTime = ES3.Load("mainMenuFirstTime", true);

        if (firstTime) {
            introText.text = "abc";
            attackText.text = "abc";
            title.GetComponent<DOTweenAnimation>().DOPlayById("1");
            introSec.SetActive(false);
            attackSec.SetActive(false);
            logo.GetComponent<RectTransform>().localScale = new Vector3(0, 0, 0);
        } else {
            title.GetComponent<TextDecoder>().forceText = true;
            introSec.transform.Find("Text").GetComponent<TextDecoder>().forceText = true;
            StartCoroutine(introSec.transform.Find("Image").GetComponent<RemoveNoise>().Remove());
            title.GetComponent<Text>().text = "<color=red>MAN</color> IN THE MIDDLE";
            if (ES3.Load("protocolAttacksUnlocked", false)) {
                keyHoleIm.SetActive(false);
                attackSec.transform.Find("Text").GetComponent<TextDecoderInfinite>().forceText = true;
            }
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (title.GetComponent<Text>().text.Equals("MAN IN THE MIDDLE")) {
            title.GetComponent<Text>().text = "<color=red>MAN</color> IN THE MIDDLE";
            if(firstTime) {
                title.GetComponent<DOTweenAnimation>().DOPlayById("2");
            }
            titleRevealed = true;
        }

        if (introText.text.Equals("INTRO TO CRYPTOGRAPHY") && !attacksRevealed) {
            if(firstTime) {
                ShowAttack();
                ES3.Save("mainMenuFirstTime", false);
            }
            attacksRevealed = true;
        }

        if (attackText.text.Equals("PROTOCOL ATTACKS") && !attackTextRevealed) {
            attackText.text = "<color=red>PROTOCOL ATTACKS</color>";
            keyHoleIm.SetActive(false);
            attackTextRevealed = true;
        }
    }

    public void ShowIntro() {
        introSec.GetComponent<RectTransform>().localScale = new Vector3(0, 0, 0);
        introSec.SetActive(true);
        introSec.GetComponent<DOTweenAnimation>().DOPlay();
    }

    public void ShowAttack() {
        attackSec.GetComponent<RectTransform>().localScale = new Vector3(0, 0, 0);
        attackSec.SetActive(true);
        attackSec.GetComponent<DOTweenAnimation>().DOPlay();
    }

    public void ClickIntroCrypto() {
        SceneManager.LoadScene("IntroCryptoMain");
    }

    public void ClickProtocolAttack() {
        bool unlocked = ES3.Load("protocolAttacksUnlocked", false);

        if (unlocked) {
            SceneManager.LoadScene("Protocols1");
        } else {
            lockedWindow.SetActive(true);
            lockedWindowBg.SetActive(true);
        }
    }

    public void ClickSkipButton() {
        ES3.Save("protocolAttacksUnlocked", true);
        lockedWindow.SetActive(false);
        lockedWindowBg.SetActive(false);
        keyHoleIm.SetActive(false);
        attackSec.transform.Find("Text").GetComponent<TextDecoderInfinite>().forceText = true;
    }
}
