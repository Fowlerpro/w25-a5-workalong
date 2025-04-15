using UnityEngine;

public class GameStart : MonoBehaviour
{
    public GameObject startScreen;
    public bool isPaused = true;
    [SerializeField] KeyCode start = KeyCode.Space;

    // Update is called once per frame
    void Update()
    {
        
        if (isPaused)
        {
            Time.timeScale = 0f;
        }
        if (Input.GetKey(start))
        {
            isPaused = false;
         startScreen.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}
