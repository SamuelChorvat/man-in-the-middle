using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrequencyAnalysisController : MonoBehaviour
{
    public DOTweenAnimation[] revealAnims;
    public GameObject[] revealObjects;

    public void ShowPuzzle() {
        for (int i = 0; i < revealObjects.Length; i++) {
            revealObjects[i].SetActive(true);
        }

        for (int i = 0; i < revealAnims.Length; i++) {
            revealAnims[i].DORestart();
        }
    }
}
