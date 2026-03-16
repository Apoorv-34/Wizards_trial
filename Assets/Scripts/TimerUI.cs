using UnityEngine;
using TMPro; // Assuming you are using TextMeshPro

public class TimerUI : MonoBehaviour
{
    public TextMeshProUGUI timerText;

    void Update()
    {
        // Fetch the time from the GameTimer Singleton
        if (GameTimer.Instance != null)
        {
            float time = GameTimer.Instance.totalTime;
            
            // Format time to Minutes:Seconds
            float minutes = Mathf.FloorToInt(time / 60);
            float seconds = Mathf.FloorToInt(time % 60);

            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}