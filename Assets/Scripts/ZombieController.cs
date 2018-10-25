using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Polarith.AI.Move;

public class ZombieController : MonoBehaviour {

    public Animator anim;
    public AIMContext context;
    public AudioManager audioManager;

    public float movementSpeed = 0.5f;
    public float rotationSpeed = 1f;
    public float attackDistance = 2f;
    public float attackDamage = 10f;

    private bool _inAtkRange = false;

    [TargetObjective(true)]
    public int objAsSpeed;

    private void OnEnable()
    {
        if(anim == null)
        {
            anim = GetComponent<Animator>();
        }

        if(context == null)
        {
            context = GetComponent<AIMContext>();
        }

        anim.applyRootMotion = false;
    }

    private void Start()
    {
        InvokeRepeating("Moan", 1f, 3f);
    }

    private void Update()
    {
        // Rotate
        Vector3 targetDirection = context.DecidedDirection;
        float step = rotationSpeed * Time.deltaTime;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, step, 0f);
        transform.rotation = Quaternion.LookRotation(newDirection);

        float speedMultiplier = 1f;
        if(Vector3.Angle(targetDirection, transform.forward) > 50f)
        {
            speedMultiplier = 0f;
        }

        // Move
        Vector3 newPos = transform.position;

        if(objAsSpeed >= 0 && objAsSpeed < context.DecidedValues.Count)
        {
            float magnitude = context.DecidedValues[objAsSpeed] * movementSpeed;
            magnitude = magnitude > movementSpeed ? movementSpeed : magnitude;
            if(!anim.GetBool("Attack"))
            {
                anim.SetFloat("Speed", magnitude * speedMultiplier);
                newPos += newDirection.normalized * anim.GetFloat("Speed") * Time.deltaTime;
                transform.position = newPos;
            }
        }
        else
        {
            if (!anim.GetBool("Attack"))
            {
                anim.SetFloat("Speed", 1f * movementSpeed * speedMultiplier);
                newPos += newDirection.normalized * anim.GetFloat("Speed") * Time.deltaTime;
                transform.position = newPos;
            }
        }

        // Check if player is in attack range
        if (PlayerController.instance != null)
        {
            float distance = Vector3.Distance(PlayerController.instance.transform.position, transform.position);
            //Debug.Log(distance);
            if (distance <= attackDistance)
            {
                _inAtkRange = true;
                anim.SetBool("Attack", true);
            }
            else
            {
                _inAtkRange = false;
                anim.SetBool("Attack", false);
            }
        }
    }

    public void Bite()
    {
        if (_inAtkRange)
        {
            //Debug.Log("BITE!");
            PlayerStats.instance.PlayerTakeDamage(attackDamage);
        }
    }

    void Moan()
    {
        // Make sounds
        int random_num;
        random_num = (int)Random.Range(0, 3);

        switch(random_num)
        {
            case 0:
                audioManager.PlaySound("moan1");
                break;
            case 1:
                audioManager.PlaySound("moan2");
                break;
            case 2:
                audioManager.PlaySound("moan3");
                break;
        }
    }
}
