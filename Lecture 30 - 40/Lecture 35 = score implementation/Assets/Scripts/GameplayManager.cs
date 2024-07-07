using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayManager : MonoBehaviour
{
    public static GameplayManager instance;

    [SerializeField] GameObject targetPreFab;

    public void Awake()
    {
        if (!instance  ) instance=this;
    }

    int score = 0;
    [SerializeField] Text scoreText;
    private void Start()
    {
        InvokeRepeating("SpawnTarget", 1f, 1f);
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
        Debug.Log("Score : " + score);
    }
}
