using UnityEngine;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    private GameObject turretToBuild;
    public GameObject spearTurretPrefab;
    public GameObject ballistaTurretPrefab;
    public GameObject catapultTurretPrefab;
    public int spearCost;
    public int catapultCost;
    public int ballistaCost;
    public Text catapultCostText;
    public Text spearCostText;
    public Text ballistaCostText;

    public void PurchaseSpearTurret()
    {
        if (Player.instance.currentBones >= spearCost)
        {
            SetTurretToBuild(spearTurretPrefab);
            Player.instance.currentBones -= spearCost;
            Debug.Log("Spear turret purchased");
        }
    }

    public void PurchaseBallistaTurret()
    {
        if (Player.instance.currentBones >= ballistaCost)
        {
            Debug.Log("Ballista turret purchased");
            SetTurretToBuild(ballistaTurretPrefab);
            Player.instance.currentBones -= ballistaCost;
        }
            
    }

    public void PurchaseCatapultTurret()
    {
        if (Player.instance.currentBones >= catapultCost)
        {
            Debug.Log("Catapult turret purchased");
            SetTurretToBuild(catapultTurretPrefab);
            Player.instance.currentBones -= catapultCost;
        }
    }

    public void SetTurretToBuild(GameObject turret)
    {
        turretToBuild = turret;
    }
    private void Awake()
    {
        spearCostText.text = spearCost.ToString();
        catapultCostText.text = catapultCost.ToString();
        ballistaCostText.text = ballistaCost.ToString();
        if(instance != null)
        {
            Debug.LogError("More than 1 buildManager you dummy");
            return;
        }
        instance = this;
    }
    
    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }


}
