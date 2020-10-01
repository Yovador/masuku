using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangerBehaviour : InteractibleObject
{

    [SerializeField] private int colorToSwitchTo;
    

    public override void ActionOnInteraction()
    {
        playerController.SetcharacterColor(colorToSwitchTo);
    }

}
