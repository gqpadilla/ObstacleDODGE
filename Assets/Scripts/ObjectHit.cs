using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class ObjectHit : MonoBehaviour
{
    private static readonly int BaseColor = Shader.PropertyToID("_BaseColor");

    void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
            return;

        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        var properties = new MaterialPropertyBlock();
        meshRenderer.GetPropertyBlock(properties);
        properties.SetColor(BaseColor, Color.black);
        meshRenderer.SetPropertyBlock(properties);
        Debug.Log("Something hit me.", this);
    }
}
