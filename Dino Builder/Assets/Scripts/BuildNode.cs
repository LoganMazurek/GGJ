using UnityEngine;

public class BuildNode : MonoBehaviour
{
    private Renderer rend;
    public Color hoverColor;
    private Color startColor;
    public Vector3 positionOffset;

    private GameObject turret;
   
    private void OnMouseDown()
    {
        if(turret != null)
        {
            Debug.Log("Can't build there");//TODO: display to screen
            return;
        }

        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
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
