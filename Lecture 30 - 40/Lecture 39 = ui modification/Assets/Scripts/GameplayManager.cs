using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayManager : MonoBehaviour
{
    public static GameplayManager instance;

    [SerializeField] GameObject targetPreFab;
    [SerializeField] GameObject WinPanel;

    public void Awake()
    {
        if (!instance  ) instance=this;
    }

    int score = 0;
    bool haswon = false;
    [SerializeField] Text scoreText;
    private void Start()
    {
        WinPanel.SetActive(false);
        //InvokeRepeating("SpawnTarget", 1f, 1f);
    }

    public void StartSpawningTargets()
    {
        InvokeRepeating("SpawnTarget", 1f, 1f);
    }
    private void Update()
    {
        if (haswon) CancelInvoke("SpawnTarget");
    }

    void SpawnTarget()
    {
        float xPos = Random.Range(-7.5f, 7.5f);
        float yPos = Random.Range(-4f, 4f);

        Vector3 randomtargetPos = new Vector3 (xPos, yPos,0); 

        Instantiate(targetPreFab,randomtargetPos, Quaternion.identity);
    }
    public void IncrementScore()
    {
        score++;
        scoreText.text = score.ToString();
        if(score >=10)
        {
            WinPanel.SetActive(true);
            haswon = true;
        }

        Debug.Log("Score : " + score);
    }
}
