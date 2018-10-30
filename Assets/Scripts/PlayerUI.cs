using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    public GameObject victoryScreen;

    [SerializeField]
    Text score_L;

    [SerializeField]
    Text score_W;

    [SerializeField]
    Text timer;

    void Start()
    {
        instance = GetComponent<PlayerUI>();
        Cursor.visible = false;
    }

    void Update()
    {
        SetHealthAmount(PlayerStats.instance.HealthPercentage());
        SetStaminaAmount(PlayerController.instance.stamina);
        SetAmmoAmount(WeaponController.instance.currentAmmo, WeaponController.instance.AmmoSettings.totalAmmo);
        score_L.text = "Score: " + PlayerStats.instance.score;
        score_W.text = "Score: " + PlayerStats.instance.score;
        if(Timer.instance.time_s < 10)
            timer.text = Timer.instance.time_m + ":0" + Timer.instance.time_s;
        else
            timer.text = Timer.instance.time_m + ":" + Timer.instance.time_s;

        if (Input.GetKeyDown(KeyCode.P))
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

    public void ReturnMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
