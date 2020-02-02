using UnityEngine;
using UnityEngine.EventSystems;

public class BuildNode : MonoBehaviour
{
    private Renderer rend;
    public Color hoverColor;
    private Color startColor;
    public Vector3 positionOffset;
    BuildManager buildManager;

    private GameObject turret;
   
    private void OnMouseDown()
    {
        if(buildManager.GetTurretToBuild() == null)
        {
            return;
        }
        if(turret != null)
        {
            Debug.Log("Can't build there");//TODO: display to screen
            return;
        }

        GameObject turretToBuild = buildManager.GetTurretToBuild();
        switch(turretToBuild.gameObject.name)
        {
            case "Spear":
                Player.instance.currentBones -= buildManager.spearCost;
                break;
            case "Catapult":
                Player.instance.currentBones -= buildManager.catapultCost;
                break;
            case "Ballista":
                Player.instance.currentBones -= buildManager.ballistaCost;
                break;
            default:
                break;
        }
        
        turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
    }
    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (buildManager.GetTurretToBuild() == null)
            return;
        rend.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
