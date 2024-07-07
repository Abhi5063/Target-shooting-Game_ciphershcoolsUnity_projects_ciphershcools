using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameplayManager : MonoBehaviour
{
    public static GameplayManager instance;

    [SerializeField] GameObject targetPreFab;
    [SerializeField] GameObject WinPanel;
    [SerializeField] Text scoreText;
    [SerializeField] Button restartButton;

    private int score = 0;
    private bool haswon = false;
    private bool haslose = false;

    public int Score => score; // Expose score as a public property

    private void Awake()
    {
        if (!instance) instance = this;
    }

    private void Start()
    {
        WinPanel.SetActive(false);
        restartButton.gameObject.SetActive(false);
        scoreText.text = score.ToString();
        StartSpawningTargets();
        restartButton.onClick.AddListener(RestartGame);
    }

    public void StartSpawningTargets()
    {
        InvokeRepeating("SpawnTarget", 1f, 2f); // Spawns every 2 seconds
    }

    private void Update()
    {
        if (haswon || haslose)
        {
            CancelInvoke("SpawnTarget");
        }
    }

    void SpawnTarget()
    {
        float xPos = Random.Range(-7.5f, 7.5f);
        float yPos = Random.Range(-4f, 4f);

        Vector3 randomtargetPos = new Vector3(xPos, yPos, -1);

        Instantiate(targetPreFab, randomtargetPos, Quaternion.identity);
    }

    public void IncrementScore()
    {
        score++;
        scoreText.text = score.ToString();
        CheckWinConditions();
        Debug.Log("Score : " + score);
    }

    void CheckWinConditions()
    {
        if (score >= 20)
        {
            WinPanel.SetActive(true);
            restartButton.gameObject.SetActive(true);
            haswon = true;
        }
    }

    public void TimerRanOut()
    {
        if (!haswon) // Only show LosePanel if not already won
        {
            Debug.Log("Timer ran out. Game over!");
            haslose = true;
            // Handle other game over actions here if needed
            restartButton.gameObject.SetActive(true);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
