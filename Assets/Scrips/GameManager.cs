using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject GameCanvas;
    public GameObject PauseMenu;
    public GameObject SceneCamera;

    public PhotonPlayer Player;
    public Transform thisPlayer;
    public string[] gameStates;
    public int currentState;
    public Text PingText;

    public bool updateGameStatebool;

    private void Awake()
    {
        GameCanvas.SetActive(true);
    }

    private void Update()
    {
        PingText.text = "Ping: " + PhotonNetwork.GetPing();

        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                PhotonView photonView = PhotonView.Get(this);
                photonView.RPC("UpdateGameState", PhotonTargets.All);
            }
        }
        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                PhotonView photonView = PhotonView.Get(this);
                photonView.RPC("RemoveGameState", PhotonTargets.All);
            }
        }
        if (updateGameStatebool)
        {
            PhotonView photonView = PhotonView.Get(this);
            photonView.RPC("UpdateGameState", PhotonTargets.All);
            updateGameStatebool = false;
        }
    }

    public void SpawnPlayer()
    {
        float randomValue = Random.Range(-1f,1f);
        PhotonNetwork.Instantiate(playerPrefab.name, new Vector3(this.transform.position.x + randomValue, this.transform.position.y, this.transform.position.z), Quaternion.identity, 0);
        GameCanvas.SetActive(false);
        SceneCamera.SetActive(false);
    }

    public void PauseMenuCanvas()
    {
        PauseMenu.SetActive(true);
    }

    [PunRPC]
    public void UpdateGameState()
    {
        currentState += 1;
    }

    [PunRPC]
    public void RemoveGameState()
    {
        currentState -= 1;
    }
}
