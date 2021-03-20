using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PasswordScript : MonoBehaviour
{
    public Canvas passwordCanvas;
    public Canvas finishCanvas;
    public TMP_InputField passwordInput;
    public TMP_Text passwordText;
    public TMP_Text interactText;
    public string password;

    private bool fieldActive;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            passwordCanvas.gameObject.SetActive(true);
        }
    }

    public void Submit()
    {
        passwordCanvas.gameObject.SetActive(false);
        if (passwordInput.text == password)
        {
            finishCanvas.gameObject.SetActive(true);
        }
        else
        {
            passwordCanvas.gameObject.SetActive(false);
        }
    }
}
