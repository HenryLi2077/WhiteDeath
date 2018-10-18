using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetting : MonoBehaviour {

    public static GameSetting instance;

	[System.Serializable]
    public class PickUpSetting
    {
        [Header("Health Pack Setting")]
        public int healAmount = 30;

        [Header("Ammo Pack Setting")]
        public int ammoAmount = 6;
    }
    public PickUpSetting pickUpSetting;

    void Start()
    {
        instance = GetComponent<GameSetting>();
    }
}
