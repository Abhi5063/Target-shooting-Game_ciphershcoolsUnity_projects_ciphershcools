using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    [SerializeField] GameObject startPanel;
    [SerializeField] GameObject gamePanel;

    void ShowPanel(GameObject panelToShow)
    {
        startPanel.SetActive(false);
        gamePanel.SetActive(false);

        panelToShow.SetActive(true);
    }

    public void OnclickStartButton()
    {
        ShowPanel(gamePanel);
        GameplayManager.instance.StartSpawningTargets();
    }
}
