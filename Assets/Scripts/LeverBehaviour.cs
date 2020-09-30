using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverBehaviour : InteractibleObject
{

    [SerializeField] private GameObject objectToControl;
    [SerializeField] private PlayerController player;

    public override void ActionOnInteraction()
    {

        if (Input.GetButtonDown("Use") && player.GetcharacterColor() == 0)
        {
            objectToControl.SetActive(!objectToControl.activeSelf);
        }
    }
}
