using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverBehaviour : InteractibleObject
{

    [SerializeField] private GameObject objectToControl;

    public override void ActionOnInteraction()
    {

        if (Input.GetButtonDown("Use") && playerController.GetcharacterColor() == 0)
        {
            objectToControl.SetActive(!objectToControl.activeSelf);
            Destroy(gameObject);
        }
    }
}
