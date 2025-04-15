using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    private int scorered;
    private int scoregreen;
    private int timer;

    public TMP_Text scoreDisplayRed;
    public TMP_Text scoreDisplayGreen;
    public TMP_Text timerDisplay;
    public TMP_Text gameOverDisplay;
    public AsteroidSpawner asteroidSpawner;

    public void AddScore()
    {
        scorered++;
        UpdateScoreDisplay();
        asteroidSpawner.CheckSpawnAsteroid(scorered);
    }
    public void AddScoreGreen()
    {
        scoregreen++;
        UpdateScoreDisplay();
        asteroidSpawner.CheckSpawnAsteroid(scoregreen);
    }

    public void Timer()
    {

        if (IsGameOver())
        {
            gameOverDisplay.enabled = true;
        }
    }

    public void ResetGame()
    {
        scorered = 0;
        scoregreen = 0;
        timer = 60;
    }

    public bool IsGameOver()
    {
        return timer <= 0;
    }

    private void UpdateScoreDisplay()
    {
        scoreDisplayGreen.text = $"Scoregreen: {scoregreen}";
        scoreDisplayRed.text = $"Scorered: {scorered}";
        timer = Timer
        timerDisplay.text = $"Timer: {timer}";
    }

    private void Start()
    {
        ResetGame();
        UpdateScoreDisplay();
        gameOverDisplay.enabled = false;
    }
    private void Update()
    {
        // Reload scene on game over with keypress
        if (IsGameOver())
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Scene current = SceneManager.GetActiveScene();
                SceneManager.LoadScene(current.name);
            }
        }
    }
}
