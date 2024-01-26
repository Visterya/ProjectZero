using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField]private GameObject _winPanel;
    [SerializeField]private GameObject _losePanel;
    [SerializeField] private TextMeshProUGUI throwLimitText;

    private void Start()
    {
        GameManager.instance.RegisterUIManager(this);
    }
    private void Update()
    {
        ThrowLimitText();
    }

    public void WinPanel()
    {
        _winPanel.SetActive(true);
    }
    public void LosePanel()
    {
        _losePanel.SetActive(true);
    }

    public void LoadLevelString(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ThrowLimitText()
    {
        throwLimitText.text = GameManager.instance.ThrowLimit.ToString();
    }
}
