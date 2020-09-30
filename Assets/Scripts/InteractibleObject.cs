using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractibleObject : MonoBehaviour
{
    protected bool isPlayerInReach;

    private void Update()
    {
        if (isPlayerInReach)
        {
            ActionOnInteraction();
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            isPlayerInReach = true;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            isPlayerInReach = false;
        }
    }

    public virtual void ActionOnInteraction()
    {
        Destroy(gameObject);
    }


}
