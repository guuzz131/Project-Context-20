using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField] private string VersionName = "0.1";
    private float bloop;
    [SerializeField] private GameObject go_UsernameMenu;
    [SerializeField] private GameObject go_MainMenu;
    [SerializeField] private GameObject go_CreateGameMenu;
    [SerializeField] private GameObject go_JoinGameMenu;


    [SerializeField] private InputField usernameInput;
    [SerializeField] private InputField CreateGameInput;
    [SerializeField] private InputField JoinGameInput;

    [SerializeField] private GameObject UsernameBtn;
    [SerializeField] private GameObject JoinBtn;
    [SerializeField] private GameObject CreateBtn;
    private void Awake()
    {
        PhotonNetwork.ConnectUsingSettings(VersionName);
    }

    private void Start()
    {
        go_UsernameMenu.SetActive(true);

    }
    private void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby(TypedLobby.Default);
        Debug.Log("Connected");
    }

    public void ChangeUserNameInput()
    {
        if (usernameInput.text.Length >= 1)
        {
            UsernameBtn.SetActive(true);
        }
        else
        {
            UsernameBtn.SetActive(false);
        }
    }
    public void ChangeJoinInput()
    {
        if (JoinGameInput.text.Length >= 4)
        {
            JoinBtn.SetActive(true);
        }
        else
        {
            JoinBtn.SetActive(false);
        }
    }
    public void ChangeCreateInput()
    {
        if (CreateGameInput.text.Length >= 4)
        {
            CreateBtn.SetActive(true);
        }
        else
        {
            CreateBtn.SetActive(false);
        }
    }

    public void SetUsername()
    {
        go_UsernameMenu.SetActive(false);
        go_MainMenu.SetActive(true);
        PhotonNetwork.playerName = usernameInput.text;
    }

    public void CreateGameMenu()
    {
        go_MainMenu.SetActive(false);
        go_CreateGameMenu.SetActive(true);
        CreateBtn.SetActive(false);
    }
     public void ConnectGameMenu()
    {
        go_MainMenu.SetActive(false);
        go_JoinGameMenu.SetActive(true);
        JoinBtn.SetActive(false);
    }
    public void ChangeUsername()
    {
        go_MainMenu.SetActive(false);
        go_UsernameMenu.SetActive(true);
    }

    public void BackToMainMenu()
    {
        go_MainMenu.SetActive(true);
        go_JoinGameMenu.SetActive(false);
        go_CreateGameMenu.SetActive(false);
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
