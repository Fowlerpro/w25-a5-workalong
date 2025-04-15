using UnityEngine;

public class GameStart : MonoBehaviour
{
    public GameObject startScreen;
    public bool isStarted = true;
    [SerializeField] KeyCode start = KeyCode.Space;

    // Update is called once per frame
    void Update()
    {
        
        if (isStarted)
        {
            Time.timeScale = 0f;
        }
        if (Input.GetKey(start))
        {
            isStarted = false;
         startScreen.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}
