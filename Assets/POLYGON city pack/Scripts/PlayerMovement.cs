using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f; // Speed of the player
    public float mouseSensitivity = 100f; // Mouse sensitivity for rotation

    private float yRotation = 0f; // Y-axis rotation value
    private Rigidbody rb; // Reference to the Rigidbody component
    private Camera mainCamera; // Reference to the main camera

    void Start()
    {
        Debug.Log("Player Initialized: Use WASD/Arrow keys to move and Mouse to rotate.");

        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody component not found on the player object!");
        }

        mainCamera = Camera.main;
        if (mainCamera == null)
        {
            Debug.LogError("Main camera not found. Ensure your camera is tagged as 'MainCamera'.");
        }

        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor to the center
        Cursor.visible = false;
    }

    void Update()
    {
        // Rotate the player around Y-axis based on mouse X movement
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        yRotation += mouseX;
        transform.rotation = Quaternion.Euler(0f, yRotation, 0f);
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); // Get horizontal input
        float moveVertical = Input.GetAxis("Vertical"); // Get vertical input

        // Calculate movement direction relative to camera's orientation
        Vector3 forward = mainCamera.transform.forward;
        Vector3 right = mainCamera.transform.right;
        forward.y = 0;
        right.y = 0;
        forward.Normalize();
        right.Normalize();

        Vector3 movement = (forward * moveVertical + right * moveHorizontal).normalized;

        // Move the player by setting the velocity
        rb.linearVelocity = movement * speed;

        // Prevent capsule from tilting or rotating due to physics interactions
        rb.rotation = Quaternion.Euler(0f, rb.rotation.eulerAngles.y, 0f);
    }
}


//using UnityEngine;

//public class PlayerMovement : MonoBehaviour
//{
//    public float speed = 5.0f; // Speed of the player
//    public float mouseSensitivity = 100f; // Mouse sensitivity for rotation
//    private float yRotation = 0f; // Y-axis rotation value

//    private Rigidbody rb; // Reference to the Rigidbody component
//    private Camera mainCamera; // Reference to the main camera

//    void Start()
//    {
//        rb = GetComponent<Rigidbody>();
//        if (rb == null)
//        {
//            Debug.LogError("Rigidbody component not found on the player object!");
//        }

//        mainCamera = Camera.main;
//        if (mainCamera == null)
//        {
//            Debug.LogError("Main camera not found. Ensure your camera is tagged as 'MainCamera'.");
//        }

//        Cursor.lockState = CursorLockMode.Locked; // Lock cursor for better mouse control
//        Cursor.visible = false;
//    }

//    void Update()
//    {
//        // Handle mouse rotation
//        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
//        yRotation += mouseX;
//        transform.rotation = Quaternion.Euler(0f, yRotation, 0f);
//    }

//    void FixedUpdate()
//    {
//        float moveHorizontal = Input.GetAxis("Horizontal"); // A/D or Left/Right arrow keys
//        float moveVertical = Input.GetAxis("Vertical"); // W/S or Up/Down arrow keys

//        // Calculate movement direction relative to camera's orientation
//        Vector3 forward = mainCamera.transform.forward;
//        Vector3 right = mainCamera.transform.right;
//        forward.y = 0;
//        right.y = 0;
//        forward.Normalize();
//        right.Normalize();

//        Vector3 movement = (forward * moveVertical + right * moveHorizontal).normalized;

//        // Move the player
//        rb.linearVelocity = movement * speed;

//        // Prevent rotation from physics (lock to y-axis only)
//        rb.rotation = Quaternion.Euler(0f, rb.rotation.eulerAngles.y, 0f);
//    }
//}
