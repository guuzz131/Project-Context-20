using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField] private string VersionName = "0.1";
    [SerializeField] private GameObject UsernameMenu;
    [SerializeField] private GameObject ConnectPanel;

    [SerializeField] private InputField usernameInput;
    [SerializeField] private InputField CreateGameInput;
    [SerializeField] private InputField JoinGameInput;

    [SerializeField] private GameObject StartBtn;

    private void Awake()
    {
        PhotonNetwork.ConnectUsingSettings(VersionName);

    }
    private void Start()
    {
        UsernameMenu.SetActive(true);

    }
    private void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby(TypedLobby.Default);
        Debug.Log("Connected");
    }

    public void ChangeUserNameInput()
    {
        if (usernameInput.text.Length >= 3)
        {
            StartBtn.SetActive(true);
        }
        else
        {
            StartBtn.SetActive(false);
        }
    }

    public void SetUsername()
    {
        UsernameMenu.SetActive(false);
        PhotonNetwork.playerName = usernameInput.text;
    }

    public void CreateGame()
    {
        PhotonNetwork.CreateRoom(CreateGameInput.text, new RoomOptions() { maxPlayers = 5 }, null);

    }

    public void JoinGame()
    {
        PhotonNetwork.JoinRoom(JoinGameInput.text);
    }

    private void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("MainGame");
    }
}
