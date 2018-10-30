using UnityEngine;
using Unity.Collections;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour {

    public static PlayerMotor instance;

    [SerializeField]
    private Camera cam;
    [SerializeField]
    private Camera deathCam;

    public LayerMask whatIsGround;
    private Vector3 velocity = Vector3.zero;
    private Vector3 jump = Vector3.zero;
    private Vector3 rotation = Vector3.zero;
    private float cameraRotationX = 0f;
    private float currentCameraRotationX = 0f;
    private bool jumpCheck = true;
    [SerializeField]
    private bool grounded = false;

    [SerializeField]
    private Transform groundCheck;

    [SerializeField]
    private float boxHalfExtents = 0.15f;

    [SerializeField]
    private float cameraRotationLimit = 85f;

    public GameObject hud;

    private Rigidbody rb;

    void Start()
    {
        instance = GetComponent<PlayerMotor>();
        rb = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 _velocity, Vector3 _jump)
    {
        velocity = _velocity;
        jump = _jump;
    }

    public void Rotate(Vector3 _rotation)
    {
        rotation= _rotation;
    }

    public void RotateCamera(float _cameraRotationX)
    {
        cameraRotationX = -_cameraRotationX;
    }

    void Update()
    {
        PerformJump();

        // Kill test
        //if(Input.GetKeyDown(KeyCode.K))
        //{
        //    PlayerKilled();
        //}
    }

    void FixedUpdate()
    {
        Vector3 box = new Vector3(boxHalfExtents, boxHalfExtents, boxHalfExtents);
        grounded = Physics.CheckBox(groundCheck.position, box, Quaternion.identity, whatIsGround);

        PerformMovement();
        PerformRotation();
    }

    void PerformMovement()
    {
        if (velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.deltaTime);
        }
    }

    void PerformJump()
    {
        if (grounded && jumpCheck && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(jump);
            jumpCheck = false;
            grounded = false;

            Invoke("LeaveGround", 1f);
        }
    }

    void PerformRotation()
    {
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
        if(cam != null)
        {
            currentCameraRotationX += cameraRotationX;
            currentCameraRotationX = Mathf.Clamp(currentCameraRotationX, -cameraRotationLimit, cameraRotationLimit);

            cam.transform.localEulerAngles = new Vector3(currentCameraRotationX, 0f, 0f);
        }
    }

    public void PlayerKilled()
    {
        TimeManager.instance.DoSlowmotion();
        deathCam.transform.position = cam.transform.position;
        deathCam.transform.rotation = cam.transform.rotation;
        cam.gameObject.SetActive(false);
        deathCam.gameObject.SetActive(true);
        PlayerUI.instance.gameOverScreen.SetActive(true);
        hud.SetActive(false);
        PlayerController.instance.enabled = false;
        WeaponController.instance.enabled = false;
        Timer.instance.death = true;
        Cursor.visible = true;

        Destroy(this.gameObject);
    }

    void LeaveGround()
    {
        jumpCheck = true;
    }
}
