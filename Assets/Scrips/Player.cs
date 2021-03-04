using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Photon.MonoBehaviour
{
    public PhotonView photonView;
    public Rigidbody rdbd;
    public GameObject playerCamera;
    public Text playernameText;

    public float moveSpeed;

    private void Awake()
    {
        if (photonView.isMine)
        {
            playerCamera.SetActive(true);
            playernameText.text = PhotonNetwork.playerName;
        }
        else
        {
            playerCamera.SetActive(false);
            playernameText.text = photonView.owner.name;
            playernameText.color = Color.green;
        }
    }


    private void Update()
    {
        if (photonView.isMine)
        {
            CheckInput();
        }
    }

    private void CheckInput()
    {
        /*
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position = new Vector3(transform.position.x * moveSpeed * Time.deltaTime * -1, transform.position.y, transform.position.z);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position = new Vector3(transform.position.x * moveSpeed * Time.deltaTime, transform.position.y, transform.position.z);
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z * moveSpeed * Time.deltaTime);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z * moveSpeed * Time.deltaTime * -1);
        }*/
        var inputMovement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        transform.Translate(inputMovement * Time.deltaTime * moveSpeed, Space.World);
        //var move = new Vector3(Input.GetAxisRaw("Horizontal"), 0);
        //transform.position += move * moveSpeed * Time.deltaTime;
    }
}
