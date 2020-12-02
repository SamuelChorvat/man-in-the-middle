using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PKCAnotControl : MonoBehaviour
{
    public GameObject anot1;
    public GameObject anot2;

    public void ShowAnot1() {
        anot1.SetActive(true);
        anot1.GetComponent<DOTweenAnimation>().DOPlay();
    }

    public void ShowAnot2() {
        anot2.SetActive(true);
        anot2.GetComponent<DOTweenAnimation>().DOPlay();
    }

}
