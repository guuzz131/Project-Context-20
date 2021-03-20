using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Greenscreen : Interactable
{
    public GameObject inventorySprite;
    public GameManager gameManager;

    public override void Interaction()
    {
        if (gameManager.currentState == 4)
        {
            inventorySprite.SetActive(true);
            Tasks.haveGreenscreen = true;
            gameManager.updateGameStatebool = true;
            Destroy(gameObject);
        }
    }
}
