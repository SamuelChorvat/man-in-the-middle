using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevealSections : MonoBehaviour
{
    public GameObject intro;
    public GameObject attacks;

    public void Reveal() {
        intro.SetActive(true);
        //attacks.SetActive(true);
    }


}
