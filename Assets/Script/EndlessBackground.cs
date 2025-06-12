using UnityEngine;

public class EndlessBackground : MonoBehaviour
{
    private MeshRenderer mr;
    private Material mat;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mr = GetComponent<MeshRenderer>();
        mat = mr.material;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 offset = new Vector2(transform.position.x / transform.localScale.x, transform.position.y / transform.localScale.z);
        mat.mainTextureOffset = offset;
    }
}
