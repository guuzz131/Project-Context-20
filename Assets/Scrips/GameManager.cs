using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject GameCanvas;
    public GameObject SceneCamera;
    public Text PingText;

    private void Awake()
    {
        GameCanvas.SetActive(true);
    }

    private void Update()
    {
        PingText.text = "Ping: " + PhotonNetwork.GetPing();
    }

    public void SpawnPlayer()
    {
        float randomValue = Random.Range(-1f,1f);
        PhotonNetwork.Instantiate(playerPrefab.name, new Vector3(this.transform.position.x * randomValue, this.transform.position.y, this.transform.position.z), Quaternion.identity, 0);
        GameCanvas.SetActive(false);
        SceneCamera.SetActive(false);
    }
}
