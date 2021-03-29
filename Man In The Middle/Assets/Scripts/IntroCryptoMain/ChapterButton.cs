using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChapterButton : MonoBehaviour {
    public GameObject arrow;
    public TextMeshProUGUI title;
    public Image line;
    public GameObject keyFragment;
    public GameObject extraInfo;
    public Image[] bulletPoints;
    public GameObject goButton;
    public GameObject goButtonText;
    public GameObject clipper;

    [SerializeField]
    private bool unlocked;
    [SerializeField]
    private int onClickRotate;

    private bool clicked = false;

    public void Awake() {
        arrow.GetComponent<RectTransform>().transform.eulerAngles = new Vector3(0, 0, -90);
        StartCoroutine(HideExtraInfo());
        clicked = false;
    }

    public void SetUnlocked(bool b) {
        if (b) {
            title.color = Color.white;
            arrow.GetComponent<Image>().color = new Color32(255, 143, 0, 255);
            line.GetComponent<Image>().color = new Color32(255, 143, 0, 255);
            keyFragment.SetActive(true);
            //keyFragment.GetComponent<Image>().color = new Vector4(255, 255, 255, 128);
            for (int i = 0; i < bulletPoints.Length; i++) {
                bulletPoints[i].color = new Color32(255, 143, 0, 255);
            }
        } else {
            title.color = Color.red;
            arrow.GetComponent<Image>().color = Color.red;
            line.GetComponent<Image>().color = Color.red;
            keyFragment.SetActive(false);
            for (int i = 0; i < bulletPoints.Length; i++) {
                bulletPoints[i].color = Color.red;
            }
            HideGoButton();
        }
        unlocked = b;
    }

    public void SetCompleted() {
        title.color = Color.white;
        arrow.GetComponent<Image>().color = Color.green;
        line.GetComponent<Image>().color = Color.green;
        keyFragment.SetActive(true);
        keyFragment.GetComponent<Image>().color = Color.green;
        goButton.GetComponent<Image>().color = Color.green;
        for (int i = 0; i < bulletPoints.Length; i++) {
            bulletPoints[i].color = Color.green;
        }
    }

    public void ShowInfo() {
        if (clicked) {
            arrow.GetComponent<RectTransform>().transform.eulerAngles = new Vector3(0, 0, -90);
            StartCoroutine(HideExtraInfo());
            clicked = false;
        } else {
            arrow.GetComponent<RectTransform>().transform.eulerAngles = new Vector3(0, 0, onClickRotate);
            StartCoroutine(ShowExtraInfo());
            clicked = true;
        }
    }

    private IEnumerator ShowGoButton() {
        while (goButton.GetComponent<Image>().fillAmount < 1) {
            goButton.GetComponent<Image>().fillAmount += 0.05f;
            yield return new WaitForSeconds(0.005f);
        }
        goButtonText.SetActive(true);
    }

    private void HideGoButton() {
        goButtonText.SetActive(false);
        goButton.GetComponent<Image>().fillAmount = 0f;
    }

    private IEnumerator ShowExtraInfo() {
        extraInfo.SetActive(true);
        while (clipper.GetComponent<Image>().fillAmount > 0) {
            clipper.GetComponent<Image>().fillAmount -= 0.05f;
            yield return new WaitForSeconds(0.005f);
        }
        clipper.SetActive(false);

        if (unlocked) {
            StartCoroutine(ShowGoButton());
        }
    }

    private IEnumerator HideExtraInfo() {
        HideGoButton();
        clipper.SetActive(true);
        while (clipper.GetComponent<Image>().fillAmount < 1) {
            clipper.GetComponent<Image>().fillAmount += 0.05f;
            yield return new WaitForSeconds(0.005f);
        }
        extraInfo.SetActive(false);
    }
}
