using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroCryptoController : MonoBehaviour
{
    public void ClickBackButton() {
        SceneManager.LoadScene("MainMenu");
    }
}
