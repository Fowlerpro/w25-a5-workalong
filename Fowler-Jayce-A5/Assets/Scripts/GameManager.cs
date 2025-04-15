using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    private int scorered;
    private int scoregreen;
    private float timer = 60;

    public TMP_Text scoreDisplayRed;
    public TMP_Text scoreDisplayGreen;
    public TMP_Text timerDisplay;
    public TMP_Text gameOverDisplay;
    public AsteroidSpawner asteroidSpawner;

    public void AddScoreRed()
    {
        scorered++;
        UpdateScoreDisplayRed();
        asteroidSpawner.CheckSpawnAsteroid(scorered);
    }
    public void AddScoreGreen()
    {
        scoregreen++;
        UpdateScoreDisplayGreen();
        asteroidSpawner.CheckSpawnAsteroid(scoregreen);
    }

    public void Timer()
    {
        timer = timer - Time.deltaTime;
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

    private void UpdateScoreDisplayGreen()
    {
        scoreDisplayGreen.text = $"Scoregreen: {scoregreen}";
        
    }
    private void UpdateScoreDisplayRed()
    {
        scoreDisplayRed.text = $"Scorered: {scorered}";
    }

    private void Start()
    {
        ResetGame();
        UpdateScoreDisplayRed();
        UpdateScoreDisplayGreen();
        gameOverDisplay.enabled = false;
    }
    private void Update()
    {
        timerDisplay.text = $"Timer: {timer}";
        Timer();
        // Reload scene on game over with keypress
        if (IsGameOver())
        {
            Time.timeScale = 0;
            gameOverDisplay.enabled = true;
            if (Input.GetKeyDown(KeyCode.R))
            {
                Scene current = SceneManager.GetActiveScene();
                SceneManager.LoadScene(current.name);
            }
        }
    }
}
