using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageAlternate : MonoBehaviour
{
    public Image toAlternate;
    public Sprite one;
    public Sprite two;


    public float delay;
    public Text toCheck;
    public string checkAgainst;
    //private bool lockDisp;

    public void Start() {
        StartCoroutine(Alternate());
    }

    private IEnumerator Alternate() {
        while (true) {
            if (!toAlternate.sprite.name.Equals(one.name) && toCheck.text.Equals(checkAgainst)) {
                toAlternate.sprite = one;
            } else if (toCheck.text.Equals(checkAgainst)) {
                toAlternate.sprite = two;
            }

            yield return new WaitForSeconds(delay);
        }
    }


}
