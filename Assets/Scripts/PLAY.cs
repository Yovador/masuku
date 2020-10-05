using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PLAY : MonoBehaviour
{
    [SerializeField] private string LevelToLoad; 
    [SerializeField] private bool creditCharger = false;

    private void Awake()
    {
        if (creditCharger)
        {
            SceneManager.LoadScene(LevelToLoad);
        }
    }


    public void LoadLevel()
    {
        SceneManager.LoadScene(LevelToLoad);
    }
}
