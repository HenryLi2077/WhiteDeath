using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour {

    public float health = 100f;

    void Update()
    {
        if(health <= 0f)
        {
            EnemyKilled();
        }
    }

    public void TakeDamage(float _amount)
    {
        health -= _amount;
        if(health <= 0f)
        {
            Debug.Log("Target Destroyed!");
        }
    }

    void EnemyKilled()
    {
        PlayerStats.instance.score += 10;
        Destroy(gameObject);
    }
}
