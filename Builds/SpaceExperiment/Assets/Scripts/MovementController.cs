using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementController : MonoBehaviour
{
    public Rigidbody PlayerBody;




    [Header("Controls")]
    public KeyCode Forward = KeyCode.W;
    public KeyCode Backward = KeyCode.S;
    public KeyCode Left = KeyCode.A;
    public KeyCode Right = KeyCode.D;
    public KeyCode Up = KeyCode.Space;
    public KeyCode Down = KeyCode.LeftControl;
    public KeyCode Brake = KeyCode.LeftShift;


    public KeyCode CursorLockToggle = KeyCode.L;


    [Header("Movement Modifiers")]
    public bool ScreenLock = false;
    public float ForceMultiplier = 1000f;
    public float BrakeMultiplier = 0.99f;
    public float mouseSensitivity = 100.0f;
    public float clampAngle = 80.0f;

    private float rotY = 0.0f; // rotation around the up/y axis
    private float rotX = 0.0f; // rotation around the right/x axis




    // Start is called before the first frame update
    void Start()
    {
        PlayerBody = this.GetComponent<Rigidbody>();

        Vector3 rot = transform.localRotation.eulerAngles;
        rotY = rot.y;
        rotX = rot.x;
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.anyKey)
        {
            Vector3 _movementModifier = new Vector3(0, 0, 0);

            if (Input.GetKey(Forward))
            {
                PlayerBody.AddForce(transform.forward * ForceMultiplier);
            }
            if (Input.GetKey(Backward))
            {
                PlayerBody.AddForce(-transform.forward * ForceMultiplier);
            }

            if (Input.GetKey(Left))
            {
                PlayerBody.AddForce(-transform.right * ForceMultiplier);
            }
            if (Input.GetKey(Right))
            {
                PlayerBody.AddForce(transform.right * ForceMultiplier);
            }

            if (Input.GetKey(Up))
            {
                PlayerBody.AddForce(transform.up * ForceMultiplier);
            }
            if (Input.GetKey(Down))
            {
                PlayerBody.AddForce(-transform.up * ForceMultiplier);
            }

            if (Input.GetKey(Brake))
            {
                PlayerBody.velocity = PlayerBody.velocity * BrakeMultiplier;
            }


            if (Input.GetKeyDown(CursorLockToggle)){
                ScreenLock = !ScreenLock;

                Cursor.lockState = ScreenLock ? CursorLockMode.Locked : CursorLockMode.None;
            }

        }

        if (ScreenLock)
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = -Input.GetAxis("Mouse Y");

            rotY += mouseX * mouseSensitivity * Time.deltaTime;
            rotX += mouseY * mouseSensitivity * Time.deltaTime;

            rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);

            Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
            transform.rotation = localRotation;
        }

    }
}
