/*  
 *  File:   CameraController.cs
 *  By:     Freddy Martin
 *  Date:   3/14/2019
 * 
 *  Brief:  
 *      Controls the player
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool active = true;
    public float speed = 20;
    public float jumpSpeed = 10;
    public float mouseSensitivity = 3;
    public KeyCode forwardKey = KeyCode.W;
    public KeyCode backKey = KeyCode.S;
    public KeyCode rightKey = KeyCode.D;
    public KeyCode leftKey = KeyCode.A;
    public KeyCode jumpKey = KeyCode.Space;

    void Update()
    {
        if (active)
        {
            transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X") * mouseSensitivity, 0));
            Vector3 direction = Vector3.zero;
            if (Input.GetKey(forwardKey))
            {
                direction -= new Vector3(transform.forward.x, 0, transform.forward.z);
            }
            if (Input.GetKey(backKey))
            {
                direction += new Vector3(transform.forward.x, 0, transform.forward.z);
            }
            if (Input.GetKey(rightKey))
            {
                direction -= new Vector3(transform.right.x, 0, transform.right.z);
            }
            if (Input.GetKey(leftKey))
            {
                direction += new Vector3(transform.right.x, 0, transform.right.z);
            }
            direction.Normalize();
            GetComponent<Rigidbody>().velocity = new Vector3(direction.x * speed, GetComponent<Rigidbody>().velocity.y, direction.z * speed);
            if (!Input.GetKey(forwardKey) && !Input.GetKey(backKey) && !Input.GetKey(rightKey) && !Input.GetKey(leftKey))
            {
                GetComponent<Rigidbody>().velocity = new Vector3(0, GetComponent<Rigidbody>().velocity.y, 0);
            }
            if (Input.GetKeyDown(jumpKey) && Physics.Raycast(transform.position, -transform.up, 1.03f))
            {
                GetComponent<Rigidbody>().velocity += new Vector3(0, jumpSpeed, 0);
            }
        }
    }
}
