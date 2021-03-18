using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Haarverf : Interactable
{
    public GameObject inventorySprite;

    public override void Interaction()
    {
        inventorySprite.SetActive(true);
        Tasks.haveHaarverf = true;
        Destroy(gameObject);
    }
}

