using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using System.Security.Cryptography;
using System.Text;

public class HashControl : MonoBehaviour
{
    public GameObject hashDemo;
    public TMP_InputField messageInput;
    public TextMeshProUGUI messageHash;

    public RevealContinueButton but;
    private bool butRevealed = false;

    public void ShowDemo() {
        hashDemo.SetActive(true);
        hashDemo.GetComponent<DOTweenAnimation>().DOPlay();
    }

    public void GetHash() {
        if (!messageInput.text.Equals("")) {
            MD5 md5 = MD5.Create();
            byte[] bytes = md5.ComputeHash(Encoding.UTF8.GetBytes(messageInput.text));
 
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++) {
                builder.Append(bytes[i].ToString("x2"));
            }

            messageHash.text = builder.ToString();

            if (!butRevealed) {
                but.StartReveal();
                butRevealed = true;
            }
            
        }
    }
}
