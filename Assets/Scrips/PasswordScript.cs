using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PasswordScript : MonoBehaviour
{
    public Canvas passwordCanvas;
    public InputField passwordtInput;
    public Text passwordtText;
    public Text interactText;
    public string password;

    private bool fieldActive;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            passwordCanvas.gameObject.SetActive(true);
        }
    }

    private void Submit()
    {
        passwordCanvas.gameObject.SetActive(false);
        if (passwordtInput.text == password)
        {
            PhotonNetwork.LoadLevel("MainMenu");
        }
        else
        {

        }
    }
}
