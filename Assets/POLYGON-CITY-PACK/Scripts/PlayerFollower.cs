using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    public Transform playerTransform; // To hold the reference to the player transform
    public Vector3 offset; // Offset distance between the player and camera

    void LateUpdate()
    {
        // Check if the player transform is not null
        if (playerTransform != null)
        {
            // Set the position of the camera to be the same as the player's but with the offset
            transform.position = playerTransform.position + offset;
        }
    }
}