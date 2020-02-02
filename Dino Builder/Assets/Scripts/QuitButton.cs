using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuitButton : MonoBehaviour
{
    Button button;
    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        //SCENES:
        //Start Scene -0
        //Options - 
        //Miles Level -1
        //Nick Level -2
        //Victory - 3
        //Loss - 4

        switch (button.gameObject.name)
        {
            case "QUIT":
                Application.Quit();
                break;
            case "PLAY":
                SceneManager.LoadScene(1);
                break;
            case "OPTIONS":
                //SceneManager.LoadScene(1);
                break;
            case "MAIN MENU":
                SceneManager.LoadScene(0);
                break;
            case "NEXT ROUND":
                WaveSpawner.instance.ButtonPressed = true;
                break;
            default:
                break;
        }
    }
}
