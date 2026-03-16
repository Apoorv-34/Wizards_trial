using UnityEngine;

public class ChallengeStarter : MonoBehaviour
{
    private bool hasStarted = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasStarted)
        {
            hasStarted = true;
            // Uses the Timer version of the script (3 seconds)
            SimpleChatBox.Instance.ShowMessage("THE TRIAL BEGINS! COLLECT THE WEAPONS!", 3.0f);
        }
    }
}