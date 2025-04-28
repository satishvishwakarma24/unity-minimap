using UnityEngine;

public class MoveArrowOnLine : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public float scrollSpeed = 2f;
    private Material lineMaterial;
    private float offset;

    void Start()
    {
        lineMaterial = lineRenderer.material;
    }

    // void Update()
    // {
    //     offset += Time.deltaTime * scrollSpeed;
    //     lineMaterial.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    // }
//forward moving 
    void Update()
{
    offset -= Time.deltaTime * scrollSpeed; // use -= instead of +=
    lineMaterial.SetTextureOffset("_MainTex", new Vector2(offset, 0));
}
}
