using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {

    public static Timer instance;

    public GameObject hud;

    public int time_m = 3;
    public int time_s = 0;

    public bool death = false;

    void Start ()
    {
        instance = GetComponent<Timer>();
        InvokeRepeating("CountDown", 1f, 1f);
	}
	
	void CountDown()
    {
        if (death)
            return;

        if(!(time_m == 0 && time_s == 0))
        {
            if (time_s > 0)
            {
                time_s--;
            }
            else
            {
                time_s = 59;
                time_m--;
            }
        }
        else
        {
            PlayerUI.instance.victoryScreen.SetActive(true);
            hud.SetActive(false);
            Time.timeScale = 0;
            TimeManager.instance.enabled = false;
            PlayerController.instance.enabled = false;
            WeaponController.instance.enabled = false;
        }
    }
}
