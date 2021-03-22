using System;
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
    public GameObject gameManager;

    public float moveSpeed;
    public float rotateSpeed;

    public Vector3 inputMovement;
    public Vector3 otherMovement;

    public Vector3 curPos;
    public Vector3 lastPos;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager");

        if (photonView.isMine)
        {
            gameManager.GetComponent<GameManager>().thisPlayer = gameObject.transform;
            playerCamera.SetActive(true);
            playernameText.text = PhotonNetwork.playerName;
        }
        else
        {
            playerCamera.SetActive(false);
            playernameText.text = photonView.owner.name;
            playernameText.color = Color.yellow;
        }
    }


    private void Update()
    {
        if (photonView.isMine)
        {
            if (!Pause.paused)
            {
                CheckInput();
                rotateToMovement();
            }
        }
        else
        {
            CheckMovement();
        }

        bool pause = Input.GetKeyDown(KeyCode.Escape);
        if (pause)
        {
            GameObject.Find("pause").GetComponent<Pause>().TogglePause();
        }
    }

    private void CheckMovement()
    {
        curPos = gameObject.transform.position;
        otherMovement = curPos - lastPos;
        if (otherMovement.magnitude != 0)
        {
            var rotation = Quaternion.LookRotation(inputMovement);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotateSpeed);
        }
        lastPos = curPos;
    }

    private void rotateToMovement()
    {
        if (inputMovement.magnitude == 0)
        {
            return;
        }
        var rotation = Quaternion.LookRotation(inputMovement);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotateSpeed);
    }

    private void CheckInput()
    {
        inputMovement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        transform.Translate(inputMovement * Time.deltaTime * moveSpeed, Space.World);
    }
}
