using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretShopButton : MonoBehaviour
{
    Button button;
    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        switch (button.gameObject.name)
        {
            case "CATAPULT":
                BuildManager.instance.PurchaseCatapultTurret();
                break;
            case "SPEAR":
                BuildManager.instance.PurchaseSpearTurret();
                break;
            case "BALLISTA":
                BuildManager.instance.PurchaseBallistaTurret();
                break;
            default:
                break;
        }
    }
}
