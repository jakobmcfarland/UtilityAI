using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float cameraSpeed = 10;
    public float sprintMult = 3;
    public KeyCode forwardKey = KeyCode.W;
    public KeyCode sprintKey = KeyCode.LeftShift;
    public KeyCode unlockMouseKey = KeyCode.Escape;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        if (Input.GetKey(forwardKey))
        {
            Vector3 direction = transform.forward;
            if (Input.GetKey(sprintKey))
            {
                direction *= sprintMult;
            }
            GetComponent<Rigidbody>().velocity = direction * cameraSpeed;
        }
        if (Input.GetKeyDown(unlockMouseKey))
        {
            Cursor.lockState = CursorLockMode.None;
        }
        if (Cursor.lockState == CursorLockMode.None && Input.GetMouseButtonDown(0))
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        if (Cursor.lockState == CursorLockMode.Locked)
        {
            transform.Rotate(new Vector3(-Input.GetAxis("Mouse Y"), 0, 0) * 2, Space.Self);
            transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0) * 2, Space.World);
        }
    }
}
