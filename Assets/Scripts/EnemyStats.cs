using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour {

    public float health = 100f;

    public void TakeDamage(float _amount)
    {
        health -= _amount;
        if(health <= 0f)
        {
            Debug.Log("Target Destroyed!");
        }
    }
}
