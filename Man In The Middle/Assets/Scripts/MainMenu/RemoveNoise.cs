using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RemoveNoise : MonoBehaviour
{
    public _2dxFX_NoiseAnimated noise;
    public float delay = 0.05f;

    public Text toCheck;
    public string checkAgainst;

    private bool removed = false;

    private void Update() {
        if(toCheck.text.Equals(checkAgainst) && !removed) {
            StartCoroutine(Remove());
            removed = true;
        }
    }

    public IEnumerator Remove() {
        while (noise.Noise > 0) {
            noise.Noise -= 0.05f;
            yield return new WaitForSeconds(delay);
        }
    }


}
