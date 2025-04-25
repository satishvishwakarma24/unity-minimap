using UnityEngine;

public class MinimapExpandedToggle : MonoBehaviour
{
    public RectTransform border;           // Reference to the border's RectTransform
    public RectTransform miniMap;          // Reference to the MiniMap's RectTransform
    public Vector2 expandedMiniMapSize = new Vector2(1000, 1000);  // Size of the MiniMap when expanded
    public Vector2 collapsedMiniMapSize = new Vector2(470, 470);   // Size of the MiniMap when collapsed

    public Vector2 collapsedPosition;      // Default (collapsed) position of the MiniMap
    public Vector2 expandedPosition;       // Position of the MiniMap when expanded

    public float borderPadding = 30f;      // Padding between the MiniMap and its border

    private bool isExpanded = false;       // Tracks the current state of the MiniMap (expanded/collapsed)

    void Start()
    {
        // Set the initial state of the MiniMap to collapsed
        ApplyMinimapState(collapsedMiniMapSize, collapsedPosition);
    }

    public void ToggleMinimap()
    {
        // Toggle the current state
        isExpanded = !isExpanded;

        // Apply the appropriate state based on the new isExpanded value
        if (isExpanded)
            ApplyMinimapState(expandedMiniMapSize, expandedPosition);
        else
            ApplyMinimapState(collapsedMiniMapSize, collapsedPosition);
    }

    private void ApplyMinimapState(Vector2 miniMapSize, Vector2 position)
    {
        // Adjust the size and position of the MiniMap
        if (miniMap != null)
        {
            miniMap.sizeDelta = miniMapSize;
            miniMap.anchoredPosition = position;
        }

        // Adjust the size of the border based on the new size of the MiniMap and the specified padding
        if (border != null)
        {
            Vector2 borderSize = miniMapSize + new Vector2(borderPadding, borderPadding);
            border.sizeDelta = borderSize;
        }
    }
}


// using UnityEngine;
// using UnityEngine.UI;
// using TMPro;

// public class MinimapExpandedToggle : MonoBehaviour
// {
//     public RectTransform border;           // Border RectTransform
//     public RectTransform miniMap;          // MiniMap RectTransform
//     public Vector2 expandedMiniMapSize = new Vector2(1000   , 1000);
//     public Vector2 collapsedMiniMapSize = new Vector2(470, 470);

//     public Vector2 collapsedPosition;      // Default position
//     public Vector2 expandedPosition;       // New position when expanded

//     public float borderPadding = 30f;      // Padding between minimap and border
//     // public TextMeshProUGUI buttonText;     // (Optional) Button label text

//     private bool isExpanded = false;

//     void Start()
//     {
//         // Initial state (collapsed)
//         ApplyMinimapState(collapsedMiniMapSize, collapsedPosition);
//     }

//     public void ToggleMinimap()
//     {
//         isExpanded = !isExpanded;

//         if (isExpanded)
//             ApplyMinimapState(expandedMiniMapSize, expandedPosition);
//         else
//             ApplyMinimapState(collapsedMiniMapSize, collapsedPosition);

//     }

//     private void ApplyMinimapState(Vector2 miniMapSize, Vector2 position)
//     {
//         if (miniMap != null)
//         {
//             miniMap.sizeDelta = miniMapSize;
//             miniMap.anchoredPosition = position;
//         }

//         if (border != null)
//         {
//             Vector2 borderSize = miniMapSize + new Vector2(borderPadding, borderPadding);
//             border.sizeDelta = borderSize;
//         }
//     }
// }
