using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [Header("Game Settings")]
    public int requiredIngots = 6;
    public string winSceneName = "WinScene";

    [Header("Visual References")]
    [Tooltip("Drag the first part of your portal here")]
    public GameObject portalVisual1; 

    [Tooltip("Drag the second part of your portal here")]
    public GameObject portalVisual2;

    private void OnTriggerEnter(Collider other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();

        if (playerInventory != null)
        {
            // Logic Check: stop them if they don't have enough
            if (playerInventory.NumberOfDiamonds >= requiredIngots)
            {
                SceneManager.LoadScene(winSceneName);
            }
            else
            {
                Debug.Log("Access Denied! You need " + requiredIngots + " ingots.");
            }
        }
    }

    void Update()
    {
        PlayerInventory player = FindObjectOfType<PlayerInventory>();

        // Safety check to make sure we found the player and the script is running
        if (player != null)
        {
            // 1. Check if we have enough items (True or False)
            bool isUnlocked = player.NumberOfDiamonds >= requiredIngots;

            // 2. Control Visual Object 1
            if (portalVisual1 != null)
            {
                portalVisual1.SetActive(isUnlocked);
            }

            // 3. Control Visual Object 2
            if (portalVisual2 != null)
            {
                portalVisual2.SetActive(isUnlocked);
            }
        }
    }
}