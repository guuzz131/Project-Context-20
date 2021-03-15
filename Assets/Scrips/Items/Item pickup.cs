using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Itempickup : Interactable
{
    public bool pickup;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager");
        player = gameManager.GetComponent<GameManager>().thisPlayer;
    }

    private void Update()
    {
        pickup = Input.GetKeyDown(KeyCode.E);
        if (pickup && !hasInteracted)
        {
            float distance = Vector3.Distance(player.position, transform.position);
            if (distance <= radius)
            {
                hasInteracted = true;
            }
        }
    }
}
