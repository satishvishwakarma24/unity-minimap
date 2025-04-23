using UnityEngine;
using UnityEngine.UI;

public class MiniMapToggle : MonoBehaviour
{
    [Header("UI References")]
    public RectTransform canvasMiniMap;          // Parent RectTransform
    public RectTransform borderRect;
    public RectTransform miniMapRect;
    public Text noteText;
    public Camera miniMapCamera;                // Assign your MiniMap_Camera here

    [Header("Sizes")]
    private readonly Vector2 collapsedSize_Border = new Vector2(430, 430);
    private readonly Vector2 collapsedSize_Map = new Vector2(400, 400);
    private readonly Vector2 expandedSize_Border = new Vector2(1050, 1050);
    private readonly Vector2 expandedSize_Map = new Vector2(1000, 1000);

    [Header("Camera Settings")]
    public float collapsedOrthoSize = 50f;
    public float expandedOrthoSize = 100f;

    private bool isExpanded = false;

    void Start()
    {
        SetMinimapState(isExpanded);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            isExpanded = !isExpanded;
            SetMinimapState(isExpanded);
        }
    }

    void SetMinimapState(bool expand)
    {
        if (expand)
        {
            // Size
            borderRect.sizeDelta = expandedSize_Border;
            miniMapRect.sizeDelta = expandedSize_Map;

            // Center the Canvas
            canvasMiniMap.anchorMin = new Vector2(0.5f, 0.5f);
            canvasMiniMap.anchorMax = new Vector2(0.5f, 0.5f);
            canvasMiniMap.pivot = new Vector2(0.5f, 0.5f);
            canvasMiniMap.anchoredPosition = Vector2.zero;

            // Update Camera View
            if (miniMapCamera != null)
                miniMapCamera.orthographicSize = expandedOrthoSize;

            // Text
            noteText.text = "Press 'M' to Collapse Minimap";
        }
        else
        {
            // Size
            borderRect.sizeDelta = collapsedSize_Border;
            miniMapRect.sizeDelta = collapsedSize_Map;

            // Move to default bottom-right corner (customize this if needed)
            canvasMiniMap.anchorMin = new Vector2(1, 0);
            canvasMiniMap.anchorMax = new Vector2(1, 0);
            canvasMiniMap.pivot = new Vector2(1, 0);
            canvasMiniMap.anchoredPosition = new Vector2(-20, 20); // Padding from corner

            // Update Camera View
            if (miniMapCamera != null)
                miniMapCamera.orthographicSize = collapsedOrthoSize;

            // Text
            noteText.text = "Press 'M' to Expand Minimap";
        }
    }
}
