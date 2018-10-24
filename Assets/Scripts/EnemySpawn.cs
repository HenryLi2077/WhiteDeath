using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {

    public float delayTime = 1f;
    public float spawnRate = 0.5f;
    public GameObject[] zombies;
    public int poolAmount = 50;
    public List<GameObject> enemies;
    public List<GameObject> locations;
    public List<GameObject> opened_portals;

	void Start ()
    {
        enemies = new List<GameObject>();
        for (int i = 0; i < poolAmount; i++)
        {
            int type;
            type = (int)Random.Range(0, 4);

            GameObject obj = (GameObject)Instantiate(zombies[type]);
            obj.SetActive(false);
            enemies.Add(obj);
        }

        InvokeRepeating("Spawn", delayTime, spawnRate);
	}

    void Update()
    {
        for (int i = 0; i < locations.Count; i++)
        {
            if(locations[i].activeInHierarchy)
            {
                if(!opened_portals.Contains(locations[i]))
                {
                    opened_portals.Add(locations[i]);
                }
            }
            else
            {
                opened_portals.Remove(locations[i]);
            }
        }
    }

    void Spawn()
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            if(!enemies[i].activeInHierarchy)
            {
                int random;
                random = (int)Random.Range(0, opened_portals.Count);
                enemies[i].transform.position = opened_portals[random].transform.position;
                enemies[i].SetActive(true);
                break;
            }
        }
    }
}
