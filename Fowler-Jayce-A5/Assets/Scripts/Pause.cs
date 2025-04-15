using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject pauseScreen;
    public bool isPaused;
    [SerializeField] KeyCode resume = KeyCode.P;
    // Update is called once per frame
    void Update()
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
