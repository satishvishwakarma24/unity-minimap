using UnityEngine;

public class CanvasToggleManager : MonoBehaviour
{
    public Canvas[] canvases; // List of all canvases you want to control

    private Canvas activeCanvas = null;

    // Call this method from your Button's OnClick(), and pass the Canvas you want to open/close
    public void ToggleCanvas(Canvas canvasToToggle)
    {
        if (activeCanvas != null && activeCanvas != canvasToToggle)
        {
            activeCanvas.gameObject.SetActive(false);
        }

        bool shouldActivate = !(canvasToToggle.gameObject.activeSelf);

        canvasToToggle.gameObject.SetActive(shouldActivate);

        activeCanvas = shouldActivate ? canvasToToggle : null;
    }
}

