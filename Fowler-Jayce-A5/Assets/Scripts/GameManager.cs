using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    private int scorered;
    private int scoregreen;
    private int timer;

    public TMP_Text scoreDisplay;
    public TMP_Text gameOverDisplay;

    public void AddScore()
    {
        scorered++;
        UpdateScoreDisplay();
    }
    public void AddScoreGreen()
    {
        scoregreen++;
        UpdateScoreDisplay();
    }

    public void RemoveLife()
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
        scoreDisplay.text = $"Scoregreen: {scoregreen}";
        scoreDisplay.text = $"Scorered: {scorered}";
        scoreDisplay.text = $"Timer: {timer}";
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
