﻿using UnityEngine;

public class TimeManager : MonoBehaviour {

    public static TimeManager instance;

    public float slowdownFactor = 0.05f;
    public float slowdownLength = 2f;

    void Start()
    {
        instance = GetComponent<TimeManager>();
    }

    void Update()
    {
        Time.timeScale += (1f / slowdownLength) * Time.unscaledDeltaTime;
        Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
    }

    public void DoSlowmotion()
    {
        Time.timeScale = slowdownFactor;
    }
}
