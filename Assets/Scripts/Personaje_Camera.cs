using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje_Camera : MonoBehaviour
{
    public Camera PCamera;

    private float horizontalMove;
    private float verticalMove;
    private float limitMax = 75;
    private float limitMin = -75;
    private float horizontalSpeed;
    private float veticalSpeed;
    public Vector3 camForward;
    public Vector3 camRight;
    private Vector3 movePlayer;
    private Vector3 playerInput;

    public CharacterController player;
    public float sensibilidad;
    public float PlayerSpeed;

    float h;
    float v;
    float limitRotation;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");

        playerInput = new Vector3(horizontalMove, 0, verticalMove);
        playerInput = Vector3.ClampMagnitude(playerInput, 1);

        limitCam();
        camDirection();

        movePlayer = playerInput.x * camRight + playerInput.z * camForward;



        PCamera.transform.localEulerAngles = new Vector3(limitRotation, 0, 0);

        player.Move(movePlayer * PlayerSpeed * Time.deltaTime);

    }

    void camDirection()
    {
        camForward = PCamera.transform.forward;
        camRight = PCamera.transform.right;

        camForward.y = 0;
        camRight.y = 0;

        camForward = camForward.normalized;
        camRight = camRight.normalized;
    }

    void limitCam()
    {
        Vector3 directionZ = transform.forward * verticalMove;
        Vector3 directionX = transform.right * horizontalMove;

        Vector3 velocity = (directionZ + directionX).normalized * horizontalSpeed;


        h = horizontalSpeed = Input.GetAxis("Mouse X");

        Vector3 rotation = new Vector3(0, 0, h) * sensibilidad;

        v = veticalSpeed = Input.GetAxis("Mouse Y");

        float camRot = v * sensibilidad;

        limitRotation -= camRot;

        limitRotation = Mathf.Clamp(limitRotation, limitMin, limitMax);

        transform.Rotate(0, h, 0);
    }

}
