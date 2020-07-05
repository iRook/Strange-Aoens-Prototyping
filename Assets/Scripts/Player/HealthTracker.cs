using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthTracker : MonoBehaviour
{
    private PlayerStats PS;

    public int numOfHealth;

    public Image[] health;
    public Sprite acquiredHealth;
    public Sprite emptyHealth;

    void Start()
    {
        PS = GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        numOfHealth = PS.currentHealth;

        for (int i = 0; i < health.Length; i++)
        {
            if (i < numOfHealth)
            {
                health[i].enabled = true;
            }
            else
            {
                health[i].enabled = false;
            }
        }
    }
}
