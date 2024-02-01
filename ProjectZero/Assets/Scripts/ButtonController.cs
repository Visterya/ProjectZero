using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public void LoadLevelString(string sceneName)
    {
        FadeCanvas.fader.FaderLoadString(sceneName);
        Time.timeScale = 1f;
        GameManager.instance.ThrowLimit = 3;

    }
    public void RestartLevel()
    {
        FadeCanvas.fader.FaderLoadInt(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
        GameManager.instance.ThrowLimit = 3;
    }
}
