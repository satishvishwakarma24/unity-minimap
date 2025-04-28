using UnityEngine;

public class StaticMarker : MonoBehaviour
{
    private Quaternion initialRotation;

    void Start()
    {
        // Store the original rotation
        initialRotation = transform.rotation;
    }

    void LateUpdate()
    {
        // Reset rotation every frame
        transform.rotation = initialRotation;
    }
}

