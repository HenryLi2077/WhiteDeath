using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpEnable : MonoBehaviour {

    public static PickUpEnable instance;

    public GameObject prefab;

    void Start()
    {
        instance = GetComponent<PickUpEnable>();
    }

    public void Spawn(Vector3 _location)
    {
        StartCoroutine(Respawn(_location));
    }

    IEnumerator Respawn(Vector3 location)
    {
        yield return new WaitForSeconds(5);
        Instantiate(prefab, location, Quaternion.identity);
    }
}
