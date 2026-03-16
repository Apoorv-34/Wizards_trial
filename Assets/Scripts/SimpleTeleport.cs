using UnityEngine;
using UnityEngine.SceneManagement;

public class SimpleTeleport : MonoBehaviour
{
    [Tooltip("Type the exact name of the scene you want to go to")]
    public string sceneName;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object touching the portal is the Player
        if (other.CompareTag("Player"))
        {
            Debug.Log("Teleporting to " + sceneName);
            SceneManager.LoadScene(sceneName);
        }
    }
}