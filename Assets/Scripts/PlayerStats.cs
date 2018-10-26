using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public static PlayerStats instance;
    public AudioManager audioManager;
    public GameObject hud;

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
        audioManager.PlaySound("hit");
        Debug.Log("Player took " + _amount + " damage.");

        if (currentHealth <= 0f)
        {
            hud.SetActive(false);
            PlayerMotor.instance.PlayerKilled();
            Debug.Log("Player Destroyed!");
        }
    }

    public void PlayerHealed()
    {
        currentHealth += GameSetting.instance.pickUpSetting.healAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0f, 100f);
        Debug.Log(currentHealth);
    }
}
