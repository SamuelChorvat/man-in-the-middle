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
    private bool clicked = false;

    public void Awake() {
        SetUnlocked(unlocked);
        arrow.GetComponent<RectTransform>().transform.eulerAngles = new Vector3(0, 0, -90);
        StartCoroutine(HideExtraInfo1());
        clicked = false;
    }

    public void SetUnlocked(bool b) {
        if (b) {
            title.color = Color.white;
            arrow.GetComponent<Image>().color = new Color32(255, 143, 0, 255);
            line.GetComponent<Image>().color = new Color32(255, 143, 0, 255);
            keyFragment.SetActive(true);
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

    public void ShowInfo() {
        if (clicked) {
            arrow.GetComponent<RectTransform>().transform.eulerAngles = new Vector3(0, 0, -90);
            StartCoroutine(HideExtraInfo1());
            clicked = false;
        } else {
            arrow.GetComponent<RectTransform>().transform.eulerAngles = new Vector3(0, 0, -180);
            StartCoroutine(ShowExtraInfo1());
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
        while (extraInfo.transform.localScale.y < 1) {
            extraInfo.transform.localScale = new Vector3(extraInfo.transform.localScale.x, extraInfo.transform.localScale.y + 0.1f, extraInfo.transform.localScale.z);
            yield return new WaitForSeconds(0.005f);
        }

        if (unlocked) {
            StartCoroutine(ShowGoButton());
        }
    }
    private IEnumerator ShowExtraInfo1() {
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
        while (extraInfo.transform.localScale.y > 0) {
            extraInfo.transform.localScale = new Vector3(extraInfo.transform.localScale.x, extraInfo.transform.localScale.y - 0.1f, extraInfo.transform.localScale.z);
            yield return new WaitForSeconds(0.005f);
        }
        extraInfo.SetActive(false);
    }

    private IEnumerator HideExtraInfo1() {
        HideGoButton();
        clipper.SetActive(true);
        while (clipper.GetComponent<Image>().fillAmount < 1) {
            clipper.GetComponent<Image>().fillAmount += 0.05f;
            yield return new WaitForSeconds(0.005f);
        }
        extraInfo.SetActive(false);
    }
}
