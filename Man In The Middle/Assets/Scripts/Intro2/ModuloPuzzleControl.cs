using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuloPuzzleControl : MonoBehaviour
{
    public GameObject firstNumber;
    public DOTweenAnimation firstNumberAnim;

    public GameObject[] numbers;
    public ModuloNumber[] numbersScripts;

    public void DisplayFirstNo() {
        firstNumber.SetActive(true);
        firstNumberAnim.DORestart();
    }

    public void ResetPuzzle() {
        StopAllCoroutines();
        for (int i = 0; i < numbers.Length;  i++) {
            numbersScripts[i].ResetNumber();
            numbers[i].SetActive(false);
        }
    }
}
