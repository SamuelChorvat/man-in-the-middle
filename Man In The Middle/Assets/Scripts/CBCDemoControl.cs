using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CBCDemoControl : MonoBehaviour
{
    public void ShowDemo() {
        this.gameObject.GetComponent<RectTransform>().localScale = new Vector3(0, 0, 0);
        this.gameObject.SetActive(true);
        this.gameObject.GetComponent<DOTweenAnimation>().DORestart();
    }
}
