using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RedText : MonoBehaviour
{
    public Text toCheck;
    public string checkAgainst;

    // Update is called once per frame
    void Update()
    {
        if (toCheck.text.Equals(checkAgainst)) {
            toCheck.text = "<color=red>PROTOCOL ATTACKS</color>";
        }
    }
}
