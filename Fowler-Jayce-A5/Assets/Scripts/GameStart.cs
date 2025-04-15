using UnityEngine;

public class GameStart : MonoBehaviour
{
    public GameObject startScreen;
    public GameObject pauseScreen;
    public bool isStarted = true;
    public bool isPaused = false;
    [SerializeField] KeyCode resume = KeyCode.P;
    [SerializeField] KeyCode start = KeyCode.Space;

    // Update is called once per frame
    void Update()
    {
        Pause();
        if (isStarted == true)
        {
            Time.timeScale = 0f;
            if (Input.GetKey(start))
            {
                isStarted = false;
                startScreen.SetActive(false);
                Time.timeScale = 1f;
            }
        }
        void Pause()
        {
            if (Input.GetKeyDown(resume))
            {
                isPaused = !isPaused;

            }
            if (isPaused)
            {
                AddMenu();
                Time.timeScale = 0f;

            }
            else
            {
                RemoveMenu();
                Time.timeScale = 1f;
            }
        }
            void AddMenu()
        {
            pauseScreen.SetActive(true);
        }
        void RemoveMenu()
        {
            pauseScreen.SetActive(false);
        }

    }
}