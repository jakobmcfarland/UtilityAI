/*  
 *  File:   Elevator.cs
 *  By:     Freddy Martin
 *  Date:   3/14/2019
 * 
 *  Brief:  
 *      Causes the player to rise on trigger
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public float elevateSpeed = 5;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerMovement>() != null)
        {
            other.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(other.gameObject.GetComponent<Rigidbody>().velocity.x, elevateSpeed, other.gameObject.GetComponent<Rigidbody>().velocity.z);
        }
    }
}
