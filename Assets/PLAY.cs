using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PLAY : MonoBehaviour
{
    public string LevelToLoad;

    void LoadLevel()
    {
        SceneManager.LoadScene(LevelToLoad);
    }
}
