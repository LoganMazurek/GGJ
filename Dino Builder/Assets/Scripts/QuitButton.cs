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
        //Options - 1
        //Miles Level -2
        //Nick Level -3
        //Victory - 4
        //Loss - 5

        switch (button.gameObject.name)
        {
            case "QUIT":
                Application.Quit();
                break;
            case "PLAY":
                SceneManager.LoadScene(2);
                break;
            case "OPTIONS":
                SceneManager.LoadScene(1);
                break;
            default:
                break;
        }
    }
}
