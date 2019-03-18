/*  
 *  File:   CameraController.cs
 *  By:     Freddy Martin
 *  Date:   3/14/2019
 * 
 *  Brief:  
 *      Controls the camera
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public bool movementActive = true;
    public bool rotateActive = true;
    public float cameraSpeed = 10;
    public float sprintMult = 3;
    public KeyCode forwardKey = KeyCode.W;
    public KeyCode backwardKey = KeyCode.S;
    public KeyCode leftKey = KeyCode.A;
    public KeyCode rightKey = KeyCode.D;
    public KeyCode upKey = KeyCode.Space;
    public KeyCode downKey = KeyCode.LeftShift;
    public KeyCode sprintKey = KeyCode.LeftControl;
    public KeyCode unlockMouseKey = KeyCode.Escape;
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            gameObject.AddComponent<Rigidbody>().useGravity = false;
            transform.parent = null;
            movementActive = true;
            rotateActive = true;
        }
        if (movementActive)
        {
            Vector3 direction = Vector3.zero;
            if (Input.GetKey(upKey))
            {
                direction += transform.up;
            }
            if (Input.GetKey(downKey))
            {
                direction -= transform.up;
            }
            if (Input.GetKey(forwardKey))
            {
                direction += transform.forward;
            }
            if (Input.GetKey(backwardKey))
            {
                direction -= transform.forward;
            }
            if (Input.GetKey(rightKey))
            {
                direction += transform.right;
            }
            if (Input.GetKey(leftKey))
            {
                direction -= transform.right;
            }
            direction.Normalize();
            if (Input.GetKey(sprintKey))
            {
                direction *= sprintMult;
            }
            GetComponent<Rigidbody>().velocity = direction * cameraSpeed;
        }
        if (Input.GetKeyDown(unlockMouseKey))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        if (Cursor.lockState == CursorLockMode.None && Input.GetMouseButtonDown(0))
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        if (rotateActive && Cursor.lockState == CursorLockMode.Locked)
        {
            transform.Rotate(new Vector3(-Input.GetAxis("Mouse Y"), 0, 0) * 2, Space.Self);
            if (movementActive)
            {
                transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0) * 2, Space.World);
            }
        }
    }
}
