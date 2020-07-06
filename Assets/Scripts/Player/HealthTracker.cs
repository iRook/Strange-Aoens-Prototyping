using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthTracker : MonoBehaviour
{
    private PlayerStats PS;

    public int health;
    public int numOfHealth;

    public Image[] healthSprites;
    public Sprite acquiredHealth;
    public Sprite emptyHealth;

    void Start()
    {
        PS = GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        health = (int) PS.currentHealth;

        if (health > numOfHealth)
        {
            health = numOfHealth;
        }

        for (int i = 0; i < healthSprites.Length; i++)
        {
            if (i < health)
            {
                healthSprites[i].sprite = acquiredHealth;
            }
            else
            {
                healthSprites[i].sprite = emptyHealth;
            }

            if (i < numOfHealth)
            {
                healthSprites[i].enabled = true;
            }
            else
            {
                healthSprites[i].enabled = false;
            }
        }
    }
}
