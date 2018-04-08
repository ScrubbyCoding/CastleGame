using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walking : MonoBehaviour {


    public float mouseSensitivity = 100.0f;
    public float clampAngle = 80.0f;
    public float movementSpeed;
    public GameObject Player;
    private float rotY = 0.0f; // rotation around the up/y axis
    private float rotX = 0.0f; // rotation around the right/x axis

    void Start()
    {
        Vector3 rot = transform.localRotation.eulerAngles;
        rotY = rot.y;
        rotX = rot.x;
    }

    void Update()
    {
        if (Input.GetKey("w"))
        {
            Player.transform.Translate(transform.forward * movementSpeed * Time.deltaTime);
        }
        if (Input.GetKey("s"))
        {
            Player.transform.Translate(-transform.forward * movementSpeed * Time.deltaTime);
        }
        if (Input.GetKey("d"))
        {
            Player.transform.Translate(transform.right * movementSpeed * Time.deltaTime);
        }
        if (Input.GetKey("a"))
        {
            Player.transform.Translate(-transform.right * movementSpeed * Time.deltaTime);
        }
        Cursor.lockState = CursorLockMode.Locked;
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = -Input.GetAxis("Mouse Y");

        rotY += mouseX * mouseSensitivity * Time.deltaTime;
        rotX += mouseY * mouseSensitivity * Time.deltaTime;

        rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);

        Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
        transform.rotation = localRotation;
    }
}
