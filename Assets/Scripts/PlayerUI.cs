using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour {

    public static PlayerUI instance;

    [SerializeField]
    RectTransform healthBarFill;
    [SerializeField]
    Text healthText;

    [SerializeField]
    RectTransform staminaBarFill;

    [SerializeField]
    Text ammoText;

    [SerializeField]
    GameObject pauseScreen;

    public GameObject gameOverScreen;

    [SerializeField]
    Text score_L;

    [SerializeField]
    Text score_W;

    void Start()
    {
        instance = GetComponent<PlayerUI>();
    }

    void Update()
    {
        SetHealthAmount(PlayerStats.instance.HealthPercentage());
        SetStaminaAmount(PlayerController.instance.stamina);
        SetAmmoAmount(WeaponController.instance.currentAmmo, WeaponController.instance.AmmoSettings.totalAmmo);
        score_L.text = "Score: " + PlayerStats.instance.score;

        if(Input.GetKeyDown(KeyCode.P))
        {
            PauseGame();
        }
    }

    void SetHealthAmount(float _amount)
    {
        healthBarFill.localScale = new Vector3(_amount, 1f, 1f);
        healthText.text = ((int)(_amount * 100)).ToString() + "%";
    }

    void SetStaminaAmount(float _amount)
    {
        staminaBarFill.localScale = new Vector3(_amount, 1f, 1f);
    }

    void SetAmmoAmount(int _currentAmmo, int _totalAmmo)
    {
        ammoText.text = _currentAmmo + "/" + _totalAmmo;
    }

    void PauseGame()
    {
        pauseScreen.SetActive(!pauseScreen.activeSelf);

        if (pauseScreen.activeSelf)
        {
            Time.timeScale = 0;
            TimeManager.instance.enabled = false;
            PlayerController.instance.enabled = false;
            WeaponController.instance.enabled = false;
        }
        else
        {
            Time.timeScale = 1;
            TimeManager.instance.enabled = true;
            PlayerController.instance.enabled = true;
            WeaponController.instance.enabled = true;
        }
    }
}
