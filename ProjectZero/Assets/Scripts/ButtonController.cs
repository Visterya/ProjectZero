using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public void LoadLevelString(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        GameManager.instance.ThrowLimit = 3;
        Time.timeScale = 1;
    }
}
