using UnityEngine;

public class AnimateLineRenderer : MonoBehaviour
{
    public float scrollSpeed = 2.0f; // Speed of arrow movement
    private Material lineMaterial;
    private float offset;

    void Start()
    {
        // Get the material instance from LineRenderer
        lineMaterial = GetComponent<LineRenderer>().material;
    }

    void Update()
    {
        offset += Time.deltaTime * scrollSpeed;
        lineMaterial.mainTextureOffset = new Vector2(offset, 0);
    }
}
