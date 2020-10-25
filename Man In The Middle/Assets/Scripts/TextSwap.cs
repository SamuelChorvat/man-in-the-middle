using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextSwap : MonoBehaviour
{
    public GameObject oldText;
    public GameObject newText;

    public void swapText() {
        oldText.SetActive(false);
        newText.SetActive(true);
    }
}
