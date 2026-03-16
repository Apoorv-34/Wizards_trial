using UnityEngine;
using UnityEngine.InputSystem; // 1. Namespace required for New Input

[RequireComponent(typeof(CharacterController))]
public class FirstPersonController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float walkSpeed = 6f;
    public float runSpeed = 10f;
    public float jumpHeight = 1.5f;
    public float gravity = -9.81f;

    [Header("Camera Settings")]
    public Camera playerCamera;
    public float mouseSensitivity = 15f; // Increased default because New Input raw values are smaller
    public float lookXLimit = 85f;

    // Private variables
    private CharacterController characterController;
    private Vector3 moveDirection = Vector3.zero;
    private float rotationX = 0;
    private bool isRunning = false;

    // 2. Define Input Actions
    private InputAction moveAction;
    private InputAction lookAction;
    private InputAction jumpAction;
    private InputAction sprintAction;

    void Awake()
    {
        characterController = GetComponent<CharacterController>();

        // Lock cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // 3. Initialize Actions (Hardcoded for WASD/Keyboard to make it easy)
        moveAction = new InputAction("Move", binding: "<Gamepad>/leftStick");
        moveAction.AddCompositeBinding("Dpad")
            .With("Up", "<Keyboard>/w")
            .With("Down", "<Keyboard>/s")
            .With("Left", "<Keyboard>/a")
            .With("Right", "<Keyboard>/d");

        lookAction = new InputAction("Look", binding: "<Mouse>/delta");
        jumpAction = new InputAction("Jump", binding: "<Keyboard>/space");
        sprintAction = new InputAction("Sprint", binding: "<Keyboard>/leftShift");
    }

    // 4. Important: Enable/Disable Inputs when the script turns on/off
    void OnEnable()
    {
        moveAction.Enable();
        lookAction.Enable();
        jumpAction.Enable();
        sprintAction.Enable();
    }

    void OnDisable()
    {
        moveAction.Disable();
        lookAction.Disable();
        jumpAction.Disable();
        sprintAction.Disable();
    }

    void Update()
    {
        HandleMouseLook();
        HandleMovement();
    }

    void HandleMouseLook()
    {
        // Read mouse delta from New Input
        Vector2 lookInput = lookAction.ReadValue<Vector2>();

        // Note: We multiply by Time.deltaTime to smooth it out independent of frame rate
        float lookX = lookInput.x * mouseSensitivity * Time.deltaTime;
        float lookY = lookInput.y * mouseSensitivity * Time.deltaTime;

        rotationX += -lookY;
        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);

        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.rotation *= Quaternion.Euler(0, lookX, 0);
    }

    void HandleMovement()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        // Read sprint button
        isRunning = sprintAction.IsPressed();

        // Read WASD input
        Vector2 inputVector = moveAction.ReadValue<Vector2>();

        float curSpeedX = (isRunning ? runSpeed : walkSpeed) * inputVector.y; // Vertical (W/S)
        float curSpeedY = (isRunning ? runSpeed : walkSpeed) * inputVector.x; // Horizontal (A/D)

        float movementDirectionY = moveDirection.y;

        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        if (characterController.isGrounded)
        {
            // Read Jump button
            if (jumpAction.triggered)
            {
                moveDirection.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }
            else
            {
                moveDirection.y = -2f;
            }
        }
        else
        {
            moveDirection.y = movementDirectionY + (gravity * Time.deltaTime);
        }

        characterController.Move(moveDirection * Time.deltaTime);
    }
}