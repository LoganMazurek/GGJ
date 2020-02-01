using UnityEngine;

public class BuildNode : MonoBehaviour
{
    public Color hoverColor;
    private Color startColor;
    private Renderer rend;
    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }
    private void OnMouseEnter()
    {
        rend.material.color = hoverColor;
    }
    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
