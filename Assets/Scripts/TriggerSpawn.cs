using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSpawn : MonoBehaviour {

    public GameObject[] spawnPoints;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            foreach (GameObject spawnPoint in spawnPoints)
            {
                Debug.Log("123");

                spawnPoint.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            foreach (GameObject spawnPoint in spawnPoints)
            {
                spawnPoint.SetActive(false);
            }
        }
    }
}
