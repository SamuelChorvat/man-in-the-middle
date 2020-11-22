using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayAttacks : MonoBehaviour
{
    public Text toCheck;
    public string checkAgainst;

    public GameObject attacks;

    private bool revealed = false;

    private void Update() {
        if (toCheck.text.Equals(checkAgainst) && !revealed) {
            revealed = true;
            attacks.SetActive(true);
        }
    }
}
