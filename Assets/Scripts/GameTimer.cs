using UnityEngine;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{
    public static GameTimer Instance; 

    public float totalTime = 300f; // 5 minutes
    public bool isRunning = false;

    private void Awake()
    {
        // CHANGED LOGIC: Prioritize the NEW timer
        if (Instance != null)
        {
            // If an old timer exists (from a previous run), destroy it!
            Destroy(Instance.gameObject); 
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); // Keep this new one alive
    }

    private void Start()
    {
        // Automatically start the timer as soon as Scene 1 loads
        StartTimer(); 
    }

    void Update()
    {
        if (isRunning)
        {
            totalTime -= Time.deltaTime;

            if (totalTime <= 0)
            {
                totalTime = 0;
                GameOver();
            }
        }
    }

    public void StartTimer() => isRunning = true;
    public void StopTimer() => isRunning = false;

    void GameOver()
    {
        isRunning = false;
        SceneManager.LoadScene("LoseScene"); 
    }
}