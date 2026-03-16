using UnityEngine;

public class FloatingObject : MonoBehaviour
{
    // PUBLIC VARIABLES - You can adjust these in the Inspector
    [Header("Wobble Settings")]
    [Tooltip("How high up and down it moves from the start point.")]
    public float amplitude = 0.25f; 

    [Tooltip("How fast it wobbles up and down.")]
    public float speed = 1.5f;

    // PRIVATE VARIABLES - Used internally by the script
    private Vector3 startPos;
    private float timeOffset;

    void Start()
    {
        // Remember where the object started
        startPos = transform.position;
        // Create a random starting point in the sine wave so multiple objects don't move identically
        timeOffset = Random.Range(0f, 2f * Mathf.PI);
    }

    void Update()
    {
        // Calculate the new Y position using a sine wave based on time
        // Mathf.Sin goes smoothly between -1 and 1 over time.
        float newY = startPos.y + Mathf.Sin((Time.time + timeOffset) * speed) * amplitude;

        // Apply the new position to the object, keeping X and Z the same
        transform.position = new Vector3(startPos.x, newY, startPos.z);
    }
}