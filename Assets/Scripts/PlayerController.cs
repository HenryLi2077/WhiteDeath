﻿using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {

    public AudioManager audioManager;

    [SerializeField]
    private GameObject flashlight;

    [SerializeField]
    private float speed = 5f;

    public float stamina = 1f;
    [SerializeField]
    private float staminaReduce = 1f;
    [SerializeField]
    private float staminaRegen = 0.3f;
    [SerializeField]
    private float sprintFactor = 1.5f;
    [SerializeField]
    private float durability = 1;

    [SerializeField]
    private float jumpForce = 500f;

    [SerializeField]
    private float lookSensitivity = 3f;

    public static PlayerController instance;
    private PlayerMotor motor;

    void Start()
    {
        motor = GetComponent<PlayerMotor>();
        instance = GetComponent<PlayerController>();
    }

    void Update()
    {
        // Move Player and Jump
        float _xMov = Input.GetAxisRaw("Horizontal");
        float _zMov = Input.GetAxisRaw("Vertical");

        Vector3 _movH = transform.right * _xMov;
        Vector3 _movV = transform.forward * _zMov;
        Vector3 _movU = transform.up;

        Vector3 _velocity = (_movH + _movV).normalized * speed;
        Vector3 _jump = _movU * jumpForce;

        if(Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
        {
            stamina -= staminaReduce* (1/ durability) * Time.deltaTime;
            if(stamina >= 0.01f)
            {
                motor.Move(_velocity * sprintFactor, _jump);
            }
            else
            {
                motor.Move(_velocity, _jump);
            }
        }
        else
        {
            stamina += staminaRegen * Time.deltaTime;
            motor.Move(_velocity, _jump);
        }

        stamina = Mathf.Clamp(stamina, 0f, 1f);

        // Rotate Screen
        float _yRot = Input.GetAxisRaw("Mouse X");

        Vector3 _rotation = new Vector3(0f, _yRot, 0f) * lookSensitivity;

        motor.Rotate(_rotation);

        float _xRot = Input.GetAxisRaw("Mouse Y");

        float _cameraRotationX = _xRot * lookSensitivity;

        motor.RotateCamera(_cameraRotationX);

        // Flashlight
        if(Input.GetKeyDown(KeyCode.F))
        {
            flashlight.SetActive(!flashlight.activeSelf);
            audioManager.PlaySound("Flashlight");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Health"))
        {
            PickUpEnable.instance.SpawnHealth(other.gameObject.transform.position);
            Destroy(other.gameObject);
            audioManager.PlaySound("health");
            PlayerStats.instance.PlayerHealed();
        }

        if (other.gameObject.CompareTag("Ammo"))
        {
            PickUpEnable.instance.SpawnAmmo(other.gameObject.transform.position);
            Destroy(other.gameObject);
            audioManager.PlaySound("ammo");
            WeaponController.instance.PickUpAmmo();
        }
    }
}
