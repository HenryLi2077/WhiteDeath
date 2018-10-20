using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour {
	
	void Update () {
        transform.Rotate(Vector3.up, Space.World);
	}
}
