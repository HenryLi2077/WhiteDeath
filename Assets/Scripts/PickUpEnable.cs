using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpEnable : MonoBehaviour {

    public static PickUpEnable instance;

    public GameObject[] prefab;

    void Start()
    {
        instance = GetComponent<PickUpEnable>();
    }

    public void SpawnHealth(Vector3 _location)
    {
        StartCoroutine(RespawnHealth(_location));
    }

    public void SpawnAmmo(Vector3 _location)
    {
        StartCoroutine(RespawnAmmo(_location));
    }

    IEnumerator RespawnHealth(Vector3 location)
    {
        yield return new WaitForSeconds(5);
        Instantiate(prefab[0], location, Quaternion.identity);
    }

    IEnumerator RespawnAmmo(Vector3 location)
    {
        yield return new WaitForSeconds(5);
        Instantiate(prefab[1], location, Quaternion.identity);
    }
}
