using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private UIManager _uiManager;
    [HideInInspector] public string lvlUnlock = "LevelUnlock";

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void GameWin()
    {
        int nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextLevel > PlayerPrefs.GetInt(lvlUnlock, 0))
        {
            PlayerPrefs.SetInt(lvlUnlock, nextLevel);
        }
        _uiManager.WinPanel();
    }

    public void GameLose()
    {
        _uiManager.LosePanel();
    }

    public void RegisterUIManager(UIManager uiManager)
    {
        _uiManager = uiManager;
    }



}
