using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Text livesText;
    public Text bonesText;
    public int bones;
    public int maxHealth = 100;
    public int lifeCount;

    private void Start()
    {
        bones = 0;
        lifeCount = maxHealth;
    }

    private void Update()
    {
        livesText.text = lifeCount.ToString();
        bonesText.text = bones.ToString();
    }
    public void LoseLife()
    {
        lifeCount--;
        if(lifeCount <= 0)
        {
            Lose();
        }
    }
    public void Lose()
    {

    }
}
