using UnityEngine;
using UnityEngine.InputSystem; // Required for the New Input System

public class HeadBobber : MonoBehaviour
{
    [Header("Bobbing Settings")]
    public float walkingBobSpeed = 14f;
    public float walkingBobAmount = 0.05f;
    public float sprintingBobSpeed = 18f;
    public float sprintingBobAmount = 0.11f;

    [Header("FOV Settings")]
    public float defaultFOV = 60f;
    public float sprintFOV = 75f;
    public float fovSpeed = 8f; // How fast the zoom transition happens

    [Header("References")]
    public CharacterController controller;
    private Camera mainCamera;

    private float timer = 0;
    private float defaultPosY;

    void Start()
    {
        mainCamera = GetComponent<Camera>();
        defaultPosY = transform.localPosition.y;

        // Ensure the camera starts at the correct FOV
        if (mainCamera != null) mainCamera.fieldOfView = defaultFOV;
    }

    void Update()
    {
        if (controller.isGrounded && controller.velocity.magnitude > 0.1f)
        {
            // Handle Sprinting Input
            bool isSprinting = Keyboard.current.leftShiftKey.isPressed;

            // Choose values based on sprint state
            float currentSpeed = isSprinting ? sprintingBobSpeed : walkingBobSpeed;
            float currentAmount = isSprinting ? sprintingBobAmount : walkingBobAmount;
            float targetFOV = isSprinting ? sprintFOV : defaultFOV;

            // 1. FOV SHIFTING (The Speed Feel)
            if (mainCamera != null)
            {
                mainCamera.fieldOfView = Mathf.Lerp(mainCamera.fieldOfView, targetFOV, Time.deltaTime * fovSpeed);
            }

            // 2. HEAD BOBBING
            timer += Time.deltaTime * currentSpeed;
            transform.localPosition = new Vector3(
                transform.localPosition.x,
                defaultPosY + Mathf.Sin(timer) * currentAmount,
                transform.localPosition.z
            );
        }
        else
        {
            // Reset to Idle
            timer = 0;

            // Return FOV to normal when standing still
            if (mainCamera != null)
            {
                mainCamera.fieldOfView = Mathf.Lerp(mainCamera.fieldOfView, defaultFOV, Time.deltaTime * fovSpeed);
            }

            transform.localPosition = new Vector3(
                transform.localPosition.x,
                Mathf.Lerp(transform.localPosition.y, defaultPosY, Time.deltaTime * 8f),
                transform.localPosition.z
            );
        }
    }
}