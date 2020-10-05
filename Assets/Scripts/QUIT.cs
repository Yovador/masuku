using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class QUIT : MonoBehaviour
{
    public void quit()
    {
        Debug.Log("Has Quit Game");
        Application.Quit();
    }
}
