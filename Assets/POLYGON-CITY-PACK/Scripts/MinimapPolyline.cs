using UnityEngine;

public class MinimapPolyline : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public Transform[] points; // Set this in Inspector or via code

    void Start()
    {
        if (lineRenderer == null)
            lineRenderer = GetComponent<LineRenderer>();

        lineRenderer.positionCount = points.Length;

        for (int i = 0; i < points.Length; i++)
        {
            lineRenderer.SetPosition(i, points[i].position);
        }
    }
}
