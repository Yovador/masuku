using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractibleObject : MonoBehaviour
{
    protected bool isPlayerInReach;
    protected PlayerController playerController;
    private AudioSource audioSource;
    [SerializeField] protected AudioClip sound;
    private AudioManager audioManager;



    private void Start()
    {

        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
        audioSource = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioSource>();
        playerController = (PlayerController)GameObject.FindGameObjectWithTag("Player").GetComponent("PlayerController");
        if (sound == null)
        {
            sound = audioManager.GetDefaultSound();
        }
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
        AudioSource.PlayClipAtPoint(sound, transform.position);
    }


}
