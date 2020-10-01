﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractibleObject : MonoBehaviour
{
    protected bool isPlayerInReach;
    protected PlayerController playerController;


    private void Start()
    {
        playerController = (PlayerController)GameObject.FindGameObjectWithTag("Player").GetComponent("PlayerController");
    }

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
