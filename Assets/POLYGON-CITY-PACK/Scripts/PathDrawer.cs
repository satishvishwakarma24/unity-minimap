using UnityEngine;
using UnityEngine.AI;

// Continuously calculate the path from Player to Destination,
// Draws it using LineRenderer.

public class PathDrawer : MonoBehaviour
{
    public Transform player;             // Assign the Player GameObject here
    public Transform destinationObject;  // Assign the Destination GameObject here

    private NavMeshPath path;
    private LineRenderer lineRenderer;

    void Start()
    {
        // Debug.Log("Start method called.");
        path = new NavMeshPath();
        Debug.Log("NavMeshPath initialized.");
        lineRenderer = GetComponent<LineRenderer>();
        Debug.Log("LineRenderer component fetched.");
    }

    void Update()
    {
        // Debug.Log("Update method called.");

        if (destinationObject == null || player == null)
        {
            Debug.LogWarning("Destination object is null. Skipping path calculation.");
            Debug.LogWarning("Player object is null. Skipping path calculation.");
            return;
        }


        // Debug.Log("Both player and destination exist. Attempting to calculate path.");

        // Calculate the path
        if (NavMesh.CalculatePath(player.position, destinationObject.position, NavMesh.AllAreas, path))
        {
            // Debug.Log("Path successfully calculated.");
            DrawPath();
        }
        else
        {
            Debug.LogWarning("Failed to calculate path.");
        }
    }

    void DrawPath()
    {
        // Debug.Log("DrawPath method called.");
        if (path.corners.Length < 2)
        {
            // Debug.LogWarning("Path has less than 2 corners. Cannot draw path.");
            return;
        }

        // Debug.Log($"Drawing path with {path.corners.Length} corners.");

        lineRenderer.positionCount = path.corners.Length;
        // Debug.Log($"LineRenderer position count set to {path.corners.Length}.");

        lineRenderer.SetPositions(path.corners);
        // Debug.Log("LineRenderer positions updated with path corners.");
    }

    // Call this method when destination changes at runtime
    public void SetDestination(Transform newDestination)
    {
        // Debug.Log("SetDestination method called.");
        destinationObject = newDestination;
        Debug.Log($"New destination set: {newDestination.name}");
    }
}
