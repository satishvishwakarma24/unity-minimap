using Unity.VisualScripting;
using UnityEngine;

public class LimitCamera : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    void LateUpdate()
    {
        // Keep the camera's position updated with the player's position,
        // but don't change the rotation of the camera.
        Vector3 newPosition = player.position;
        newPosition.y = transform.position.y; // Keep the camera's original height
        transform.position = newPosition;

        // Optional: If you want to ensure the camera is always looking straight down,
        // you can uncomment the line below.
        // transform.rotation = Quaternion.Euler(90f, 0f, 0f);
    }
}
