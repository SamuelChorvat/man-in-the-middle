using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EBCDemoQuest : MonoBehaviour
{
    public GameObject demoObj;

    public void StartDemo() {
        demoObj.SetActive(true);
        this.gameObject.GetComponent<DOTweenAnimation>().DORestart();
    }
}
