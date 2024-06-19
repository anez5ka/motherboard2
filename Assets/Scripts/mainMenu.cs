using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuManager : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadSceneAsync(0);
        Time.timeScale = 1;
        
    }
    public void Rules()
    {
        SceneManager.LoadSceneAsync(2);
    }
}
