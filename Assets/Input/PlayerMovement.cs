using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;

public class PlayerMovement : MonoBehaviour { // For future reference: Behaviour != Behavior (ig Unity is British)
    public float moveSpeed = 3.0f;
    public float mouseSensitivity = 0.1f;
    // Locks camera so it doesn't go too far up
    public float verticalLookLimit = 80.0f;
    private float xRotation = 0f;

    private CharacterController characterController;
    private Transform cameraTransform;

    private PlayerControls playerControls;
    private InputAction moveAction;
    private InputAction lookAction;

    private void Awake() {
        characterController = GetComponent<CharacterController>();
        
        // Get the main camera's transform
        cameraTransform = Camera.main.transform;

        playerControls = new PlayerControls();
        moveAction = playerControls.Player.Move;
        lookAction = playerControls.Player.Look;
    }

    private void OnEnable() {
        moveAction.Enable();
        lookAction.Enable();
    }

    private void OnDisable() {
        moveAction.Disable();
        lookAction.Disable();
    }

    private void Update() {
        // Either WASD or joystick depending on player's system
        Vector2 input = moveAction.ReadValue<Vector2>();

        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        forward.y = 0;
        right.y = 0;
        // Makes these unit vectors...I have no idea why Unity is making me do math rn
        // Supposedly should do this when a component is unnecessary
        forward.Normalize();
        right.Normalize();

        Vector3 desiredMoveDirection = forward * input.y + right * input.x;

        // Moves in specified direction and speed
        characterController.Move(desiredMoveDirection * moveSpeed * Time.deltaTime);

        
        // ----------------- Camera Controls ----------------- //

        // Checks for VR
        if (XRSettings.isDeviceActive) return;

        Vector2 lookInput = playerControls.Player.Look.ReadValue<Vector2>();
        float mouseX = lookInput.x * mouseSensitivity;
        float mouseY = lookInput.y * mouseSensitivity;

        xRotation -= mouseY;
        // Keeps player from flipping camera everywhere
        xRotation = Mathf.Clamp(xRotation, -verticalLookLimit, verticalLookLimit);

        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Rotates player in direction of mouse (only horizontally, of course)
        transform.Rotate(Vector3.up * mouseX);
    }
}
