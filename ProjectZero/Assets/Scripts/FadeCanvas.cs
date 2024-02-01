using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeCanvas : MonoBehaviour
{
    public static FadeCanvas fader;

    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private float changeValue;
    [SerializeField] private float waitTime;
    [SerializeField] private bool fadeStarted = false;

    private void Awake()
    {
        if(fader == null)
        {
            fader = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        StartCoroutine(FadeIn());
    }

    public void FaderLoadString(string levelName)
    {
        StartCoroutine(FadeOutString(levelName));
    }
    public void FaderLoadInt(int levelInd)
    {
        StartCoroutine(FadeOutInt(levelInd));
    }


    IEnumerator FadeIn()
    {
        fadeStarted = false;
        while(canvasGroup.alpha > 0)
        {
            if(fadeStarted)
            {
                yield break;
            }
            canvasGroup.alpha -= changeValue;
            yield return new WaitForSeconds(waitTime);
        }
    }

    IEnumerator FadeOutString(string levelName)
    {
        if(fadeStarted)
        {
            yield break;
        }
        fadeStarted = true;
        while(canvasGroup.alpha < 1)
        {
            canvasGroup.alpha += changeValue;
            yield return new WaitForSeconds(waitTime);
        }
        SceneManager.LoadScene(levelName);
        yield return new WaitForSeconds(0.01f);
        StartCoroutine(FadeIn());
    }
    IEnumerator FadeOutInt(int levelInd)
    {
        if (fadeStarted)
        {
            yield break;
        }
        fadeStarted = true;
        while (canvasGroup.alpha < 1)
        {
            canvasGroup.alpha += changeValue;
            yield return new WaitForSeconds(waitTime);
        }
        SceneManager.LoadScene(levelInd);
        yield return new WaitForSeconds(0.01f);
        StartCoroutine(FadeIn());
    }
}
