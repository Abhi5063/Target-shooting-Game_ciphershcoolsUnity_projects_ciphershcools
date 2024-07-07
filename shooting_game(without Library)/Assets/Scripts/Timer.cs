using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeValue = 60f;
    private bool isTimerRunning = false;
    private float currentTime;
    public GameObject LosePanel;
    public Button StartButton;

    private Text timerText;
    private Text scoreText;

    private void Awake()
    {
        timerText = GetComponent<Text>();
    }

    private void Start()
    {
        if (LosePanel != null)
        {
            LosePanel.SetActive(false);
        }

        isTimerRunning = false;
        currentTime = timeValue;

        if (StartButton != null)
        {
            StartButton.onClick.AddListener(StartTimer);
        }

        UpdateTimerText();
    }

    private void Update()
    {
        if (isTimerRunning)
        {
            currentTime -= Time.deltaTime;
            if (currentTime <= 0.0f || (GameplayManager.instance != null && GameplayManager.instance.Score >= 20))
            {
                if (currentTime <= 0.0f)
                {
                    currentTime = 0.0f;
                    isTimerRunning = false;
                    if (LosePanel != null)
                    {
                        LosePanel.SetActive(true);
                        GameplayManager.instance.TimerRanOut(); // Notify GameplayManager that timer ran out
                    }
                }
                else if (GameplayManager.instance.Score >= 20)
                {
                    isTimerRunning = false;
                }
            }
            UpdateTimerText();
        }
    }

    void UpdateTimerText()
    {
        int min = Mathf.FloorToInt(currentTime / 60.0f);
        int sec = Mathf.FloorToInt(currentTime % 60.0f);

        timerText.text = string.Format("{0:00}:{1:00}", min, sec);
    }

    void StartTimer()
    {
        Debug.Log("Timer started.");
        isTimerRunning = true;
    }
}
