using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroPortalToScene1 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("Scene1");
        }
    }
}