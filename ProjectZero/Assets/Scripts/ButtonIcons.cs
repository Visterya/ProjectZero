using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonIcons : MonoBehaviour
{

    [SerializeField] private Button[] lvlButton;
    [SerializeField] private Sprite lockedButton;
    [SerializeField] private Sprite unlockedButton;
    [SerializeField] private int firstLevelBuildIndex;

    private void Awake()
    {
        int unlockedLvl = PlayerPrefs.GetInt(GameManager.instance.lvlUnlock, firstLevelBuildIndex);
        for (int i = 0; i < lvlButton.Length; i++)
        {
            if (i + firstLevelBuildIndex <= unlockedLvl)
            {
                lvlButton[i].interactable = true;
                lvlButton[i].image.sprite = unlockedButton;
                TextMeshProUGUI textButton = lvlButton[i].GetComponentInChildren<TextMeshProUGUI>();
                textButton.text = (i + 1).ToString();
                textButton.enabled = true;
            }
            else
            {
                lvlButton[i].interactable = false;
                lvlButton[i].image.sprite = lockedButton;
                lvlButton[i].GetComponentInChildren<TextMeshProUGUI>().enabled = false;
            }
        }
    }
}
