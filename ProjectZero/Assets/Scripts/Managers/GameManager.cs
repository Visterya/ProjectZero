using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private UIManager _uiManager;
    private int throwLimit = 5;
    private bool gameWon;
    public bool GameWon { get { return gameWon; } }
    public int ThrowLimit { get { return throwLimit; } set{ throwLimit = value; if (throwLimit <= 0) throwLimit = 0; } }
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
        Time.timeScale = 0f;
        gameWon = true;
    }

    public void GameLose()
    {
        _uiManager.LosePanel();
        Time.timeScale = 0f;
        gameWon = false;
    }

    public void RegisterUIManager(UIManager uiManager)
    {
        _uiManager = uiManager;
    }



}
