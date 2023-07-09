using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HPbarHandler : MonoBehaviour
{
    public Image HealthBar;
    public float maxHP = 50;
    public float currentHealth = 10;
    public float hpDropRate = 0.2f;
    private float calculateHealth;
    
    void FixedUpdate()
    {
        calculateHealth = currentHealth / maxHP;
        HealthBar.fillAmount = Mathf.MoveTowards(HealthBar.fillAmount, calculateHealth, Time.deltaTime);
        if (currentHealth > 0)
        {
            currentHealth -= hpDropRate * Time.fixedDeltaTime;
        }
    }
}
