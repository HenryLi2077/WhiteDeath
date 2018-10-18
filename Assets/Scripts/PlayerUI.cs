using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour {

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
    [SerializeField]
    GameObject player;
    [SerializeField]
    GameObject shotgun;

    void Update()
    {
        SetHealthAmount(PlayerStats.instance.HealthPercentage());
        SetStaminaAmount(PlayerController.instance.stamina);
        SetAmmoAmount(WeaponController.instance.currentAmmo, WeaponController.instance.AmmoSettings.totalAmmo);

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
            player.GetComponent<PlayerController>().enabled = false;
            shotgun.GetComponent<WeaponController>().enabled = false;
        }
        else
        {
            Time.timeScale = 1;
            player.GetComponent<PlayerController>().enabled = true;
            shotgun.GetComponent<WeaponController>().enabled = true;
        }
    }
}
