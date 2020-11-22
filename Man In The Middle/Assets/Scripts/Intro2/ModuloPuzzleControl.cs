using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuloPuzzleControl : MonoBehaviour
{
    public GameObject firstNumber;
    public DOTweenAnimation firstNumberAnim;

    public void DisplayFirstNo() {
        firstNumber.SetActive(true);
        firstNumberAnim.DORestart();
    }
}
