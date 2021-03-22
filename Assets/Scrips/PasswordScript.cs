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

    public GameManager gameManager;

    private bool fieldActive;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == gameManager.thisPlayer.gameObject)
        {
            passwordCanvas.gameObject.SetActive(true);
        }
    }

    public void Submit()
    {
        passwordCanvas.gameObject.SetActive(false);
        if (passwordInput.text == password)
        {
            GameCompleted();
        }
        else
        {
            passwordCanvas.gameObject.SetActive(false);
        }
    }

    [PunRPC]
    public void GameCompleted()
    {
        finishCanvas.gameObject.SetActive(true);
    }
}
