using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class rules : MonoBehaviour
{
    public void close()
    {
        SceneManager.LoadSceneAsync(1);
    }
}
