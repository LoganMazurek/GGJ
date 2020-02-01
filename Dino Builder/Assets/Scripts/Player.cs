using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int currentBones;
    public int startBones;
    public int currentLives;
    public int maxLives;
    public Text bonesText;
    public Text livesText;
    // Start is called before the first frame update
    void Start()
    {
        currentBones = startBones;
        currentLives = maxLives;
    }

    // Update is called once per frame
    void Update()
    {
        bonesText.text = currentBones.ToString();
        livesText.text = currentLives.ToString();
        if(currentLives <= 0)
        {
            Lose();
        }
    }

    public void GetBone(int bone)
    {
        currentBones += bone;
    }

    public void TakeDamage(int dmg)
    {
        currentLives -= dmg;
    }

    void Lose()
    {
        Debug.Log("You lose");
    }
}
