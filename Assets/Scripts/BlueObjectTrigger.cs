using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueObjectTrigger : LeverBehaviour
{
    public override void ActionOnInteraction()
    {
        objectToControl.SetActive(!objectToControl.activeSelf);
        Destroy(gameObject);
    }
}
