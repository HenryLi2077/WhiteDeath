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

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            foreach (GameObject spawnPoint in spawnPoints)
            {
                spawnPoint.SetActive(true);
            }
        }
    }
}
