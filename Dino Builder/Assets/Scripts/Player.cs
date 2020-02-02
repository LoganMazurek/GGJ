using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static Player instance;
    public int currentBones;
    public int startBones;
    public Text bonesText;
    public Text roundText;
    // Start is called before the first frame update
    void Start()
    {
        currentBones = startBones;
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        bonesText.text = currentBones.ToString();
        if(currentBones <= 0)
        {
            Lose();
        }
        roundText.text = WaveSpawner.instance.waveIndex.ToString() + " / 100";
    }

    public void GetBone(int bone)
    {
        currentBones += bone;
    }

    public void TakeDamage(int dmg)
    {
        currentBones -= dmg;
    }

    void Lose()
    {
        Debug.Log("You lose");
        SceneManager.LoadScene(5);
    }
}
