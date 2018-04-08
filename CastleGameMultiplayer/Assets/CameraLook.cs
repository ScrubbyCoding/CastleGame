using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{

    public float mouseSensitivity = 100.0f;
    public float clampAngle = 80.0f;
    public float movementSpeed;
    public GameObject Player;
    private float rotY = 0.0f; // rotation around the up/y axis
    private float rotX = 0.0f; // rotation around the right/x axis
    public Material Green;
    public GameObject Selected;
    public GameObject Empty;

    void Start()
    {
        Vector3 rot = transform.localRotation.eulerAngles;
        rotY = rot.y;
        rotX = rot.x;
    }

    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, 5))
        {
            if (hit.transform.tag == "Placeable")
            {
                 Selected.GetComponent<MeshRenderer>().enabled = false;
                 Selected = hit.transform.gameObject;
                 Selected.GetComponent<MeshRenderer>().enabled = true;
            }
            
            if (hit.transform.tag != "Placeable")
            {
                
                Selected.GetComponent<MeshRenderer>().enabled = false;
                Selected = Empty;
            }
        }
        else
        {
            Selected.GetComponent<MeshRenderer>().enabled = false;
        }
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
