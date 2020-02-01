using UnityEngine;

public class BuildNode : MonoBehaviour
{
    public Color hoverColor;

    private GameObject turret;

    private Color startColor;
    private Renderer rend;

    private void OnMouseDown()
    {
        if(turret != null)
        {
            Debug.Log("Can't build there");//TODO: display to screen
        }


    }
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
