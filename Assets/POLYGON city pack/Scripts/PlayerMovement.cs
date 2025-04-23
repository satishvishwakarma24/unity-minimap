using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f; // Speed of the player

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); // Get horizontal input (A/D or Left/Right arrow keys)
        float moveVertical = Input.GetAxis("Vertical"); // Get vertical input (W/S or Up/Down arrow keys)

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical); // Create movement vector

        transform.Translate(movement * speed * Time.deltaTime, Space.World); // Move the player
    }

    // This function is called every fixed framerate frame
    void FixedUpdate()
    {
        // To prevent capsule from tilting or rotating due to physics interactions
        transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);
    }
}