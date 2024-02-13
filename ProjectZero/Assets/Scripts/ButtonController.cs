using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class ButtonController : MonoBehaviour
{
    public void LoadLevelString(string sceneName)
    {
        FadeCanvas.fader.FaderLoadString(sceneName);
        Time.timeScale = 1f;
        GameManager.instance.ThrowLimit = 5;

    }
    public void RestartLevel()
    {
        FadeCanvas.fader.FaderLoadInt(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
        GameManager.instance.ThrowLimit = 5;
    }

    public void OnClickTween(RectTransform rectTransform)
    {
        rectTransform.DOScale(rectTransform.localScale * 1.25f, .25f).SetLoops(2, LoopType.Yoyo);
    }
}
