using UnityEngine;

public class Scroll : MonoBehaviour
{
    private Renderer myRenderer;
    private Material myMaterial;
    
    private float offset;

    [SerializeField] private float increase;
    [SerializeField] private float speed;
    [SerializeField] private string sortingLayer;
    [SerializeField] private int sortingOrder;
    // Start is called before the first frame update
    void Start()
    {
        myRenderer = GetComponent<MeshRenderer>();
        myMaterial = myRenderer.material;

        myRenderer.sortingLayerName = sortingLayer;
        myRenderer.sortingOrder = sortingOrder;

    }

    private void FixedUpdate()
    {
        offset += increase;
        myMaterial.SetTextureOffset("_MainTex", new Vector2((offset * speed) / 1000, 0));
    }
    
}
