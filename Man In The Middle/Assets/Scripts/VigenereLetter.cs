﻿using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VigenereLetter : MonoBehaviour
{
    public string letter;
    public VigenereController vig;

    private bool solved = false;

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.GetComponent<TMP_InputField>().text.Equals(letter, StringComparison.OrdinalIgnoreCase) && !solved) {
            this.gameObject.GetComponent<TMP_InputField>().interactable = false;
            this.gameObject.GetComponent<Image>().enabled = false;
            this.gameObject.transform.Find("Text Area").Find("Text").GetComponent<TextMeshProUGUI>().color = Color.green;
            solved = true;
            vig.addCorrect();
        }
    }
}
