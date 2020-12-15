using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnownDemoControl : MonoBehaviour
{
    public GameObject knownDemo;

    public void ShowDemo() {
        knownDemo.SetActive(true);
        knownDemo.GetComponent<DOTweenAnimation>().DOPlay();
    }
}
