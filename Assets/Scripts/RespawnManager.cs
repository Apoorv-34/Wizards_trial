using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    [Header("Settings")]
    public float fallThreshold = -10f;
    public Vector3 respawnCoordinates = new Vector3(0, 2, 0);

    // We don't cache these in Start anymore to ensure we catch them even if added later
    
    void Update()
    {
        if (transform.position.y < fallThreshold)
        {
            Debug.Log("Threshold reached! Forcing Respawn...");
            Respawn();
        }
    }

    void Respawn()
    {
        // SOLUTION: Check if there is a CharacterController and disable it briefly
        CharacterController cc = GetComponent<CharacterController>();
        
        if (cc != null)
        {
            cc.enabled = false; // Turn off the controller so we can move the object
            transform.position = respawnCoordinates;
            cc.enabled = true;  // Turn it back on
        }
        else
        {
            // If no CharacterController, just move normally
            transform.position = respawnCoordinates;
        }

        // Reset Physics (Rigidbody) if it exists
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}