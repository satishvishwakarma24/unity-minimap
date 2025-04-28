using UnityEngine;

public class DirectionMenuController : MonoBehaviour
{
    public Transform startPoint;       // Drag a GameObject representing start location
    public Transform endPoint;         // Drag a GameObject representing end location
    public LineRenderer lineRenderer;  // Assign LineRenderer in Inspector

    public void OnDirectionSelected()
    {
        if (startPoint != null && endPoint != null)
        {
            DrawPolyline(startPoint.position, endPoint.position);
        }
    }

    void DrawPolyline(Vector3 start, Vector3 end)
    {
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, start);
        lineRenderer.SetPosition(1, end);
    }
}
