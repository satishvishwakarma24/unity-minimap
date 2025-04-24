using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionPolylineManager : MonoBehaviour
{
    [SerializeField] private LineRenderer pathLine;
    [SerializeField] private float lineHeight = 1.0f; // Height above ground
    [SerializeField] private float lineWidth = 2.0f;
    [SerializeField] private Color lineColor = Color.blue;
    
    private Transform startLocation;
    private Transform destinationLocation;
    
    private void Awake()
    {
        // Create LineRenderer if not assigned
        if (pathLine == null)
        {
            GameObject lineObj = new GameObject("PathLine");
            lineObj.transform.SetParent(transform);
            pathLine = lineObj.AddComponent<LineRenderer>();
            
            // Configure LineRenderer
            pathLine.startWidth = lineWidth;
            pathLine.endWidth = lineWidth;
            pathLine.material = new Material(Shader.Find("Sprites/Default"));
            pathLine.startColor = lineColor;
            pathLine.endColor = lineColor;
            pathLine.positionCount = 0;
        }
        
        HidePath();
    }
    
    public void SetDirectionPoints(Transform start, Transform destination)
    {
        startLocation = start;
        destinationLocation = destination;
        
        if (start != null && destination != null)
        {
            DrawPath();
        }
        else
        {
            HidePath();
        }
    }
    
    public void DrawPath()
    {
        if (startLocation == null || destinationLocation == null)
        {
            Debug.LogWarning("Cannot draw path: start or destination is null");
            return;
        }
        
        // Get positions (simple direct line for now)
        Vector3 startPos = startLocation.position;
        Vector3 endPos = destinationLocation.position;
        
        // Adjust height
        startPos.y = lineHeight;
        endPos.y = lineHeight;
        
        // Set positions to line renderer
        pathLine.positionCount = 2;
        pathLine.SetPosition(0, startPos);
        pathLine.SetPosition(1, endPos);
        
        // Make sure line is visible
        pathLine.enabled = true;
    }
    
    // For more complex paths with waypoints
    public void DrawPathWithWaypoints(List<Vector3> waypoints)
    {
        if (waypoints == null || waypoints.Count < 2)
        {
            Debug.LogWarning("Cannot draw path: insufficient waypoints");
            return;
        }
        
        // Set the number of points
        pathLine.positionCount = waypoints.Count;
        
        // Set positions to line renderer
        for (int i = 0; i < waypoints.Count; i++)
        {
            Vector3 point = waypoints[i];
            point.y = lineHeight; // Set consistent height
            pathLine.SetPosition(i, point);
        }
        
        // Make sure line is visible
        pathLine.enabled = true;
    }
    
    public void HidePath()
    {
        if (pathLine != null)
        {
            pathLine.enabled = false;
        }
    }
}