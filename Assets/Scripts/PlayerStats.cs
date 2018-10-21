using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public static PlayerStats instance;

    [SerializeField]
    private float maxHealth = 100f;
    private float currentHealth;
    private float healthPercentage;
    public float HealthPercentage()
    {
        return healthPercentage;
    }
    public int score = 0;

    void Start()
    {
        instance = GetComponent<PlayerStats>();
        currentHealth = maxHealth;
    }

    void Update()
    {
        healthPercentage = currentHealth / maxHealth;
        healthPercentage = Mathf.Clamp(healthPercentage, 0f, 1f);
    }

    public void PlayerTakeDamage(float _amount)
    {
        currentHealth -= _amount;
        Debug.Log("Player took " + _amount + " damage.");

        if (currentHealth <= 0f)
        {
            Debug.Log("Player Destroyed!");
        }
    }

    public void PlayerHealed()
    {
        currentHealth += GameSetting.instance.pickUpSetting.healAmount;
    }
}
