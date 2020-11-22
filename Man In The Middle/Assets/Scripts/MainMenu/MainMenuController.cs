using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public GameObject canvas;
    public GameObject logo;
    public GameObject title;
    public GameObject introSec;
    public GameObject attackSec;
    public GameObject keyHoleIm;

    public Text introText;
    public Text attackText;


    private bool titleRevealed = false;
    private bool attacksRevealed = false;
    private bool attackTextRevealed = false;
    

    private void Awake() {
        introText.text = "abc";
        attackText.text = "abc";
        introSec.SetActive(false);
        attackSec.SetActive(false);
        logo.GetComponent<RectTransform>().localScale = new Vector3(0, 0, 0);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (title.GetComponent<Text>().text.Equals("MAN IN THE MIDDLE") && !titleRevealed) {
            title.GetComponent<Text>().text = "<color=red>MAN</color> IN THE MIDDLE";
            title.GetComponent<DOTweenAnimation>().DOPlayById("2");
            titleRevealed = true;
        }

        if (introText.text.Equals("INTRO TO CRYPTOGRAPHY") && !attacksRevealed) {
            ShowAttack();
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
}
