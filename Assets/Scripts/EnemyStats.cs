using UnityEngine;

public class EnemyStats : MonoBehaviour {

    public Animator anim;
    public GameObject ai;
    public AudioManager audioManager;

    public float health = 100f;
    private float distance;

    private bool called = false;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(health <= 0f && called == false)
        {
            EnemyKilled();
            called = true;
        }

        // Detect distance
        if(PlayerMotor.instance != null)
        {
            distance = Vector3.Distance(this.transform.position, PlayerMotor.instance.gameObject.transform.position);
            if (distance >= 50f)
            {
                this.gameObject.SetActive(false);
            }
        }
    }

    public void TakeDamage(float _amount)
    {
        health -= _amount;
        if(health <= 0f)
        {
            Debug.Log("Target Destroyed!");
        }
    }

    void EnemyKilled()
    {
        GetComponent<ZombieController>().enabled = false;
        ai.SetActive(false);
        anim.SetBool("killed", true);
        Invoke("EnemyDisabled", 2f);
    }

    private void OnEnable()
    {
        health = 100f;
        called = false;
        GetComponent<ZombieController>().enabled = true;
        ai.SetActive(true);
    }

    void EnemyDisabled()
    {
        PlayerStats.instance.score += 100;
        anim.SetBool("killed", false);
        gameObject.SetActive(false);
    }
}
