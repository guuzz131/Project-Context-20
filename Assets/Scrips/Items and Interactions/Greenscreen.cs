using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Greenscreen : Interactable
{
    public GameObject inventorySprite;

    public override void Interaction()
    {
        inventorySprite.SetActive(true);
        Tasks.haveGreenscreen = true;
        Destroy(gameObject);
    }
}
