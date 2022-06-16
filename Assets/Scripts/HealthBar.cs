using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public static float health;
    Image healthImage;
    float Maximumhealth = 100f;                                         // max health value of 100
    // Start is called before the first frame update
    void Start()
    {
        healthImage = GetComponent<Image>();
        health = Maximumhealth;                                         // at start get component 
        print("starting health =" + health);
    }

    // Update is called once per frame
    void Update()
    {
        healthImage.fillAmount = health / Maximumhealth;                // fill amount based on getting health tags.
        print("Remaining health =" + health);
        if (health <= 1)                                                // if health value decreases below value, stop the game
        {
            Stopgame.Gameover = true;
        }
    }
}

