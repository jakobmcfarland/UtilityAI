﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class roomNumberText : MonoBehaviour
{
    public GameObject demoManager;
    void Start()
    {
        
    }
    void Update()
    {
        Text textComp = GetComponent<Text>();
        if (Input.GetKeyDown(KeyCode.Backspace) && GetComponent<Text>().text.Length > 0)
        {
            textComp.text = GetComponent<Text>().text.Substring(0, GetComponent<Text>().text.Length - 1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            textComp.text += '0';
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            textComp.text += '1';
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            textComp.text += '2';
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            textComp.text += '3';
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            textComp.text += '4';
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            textComp.text += '5';
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            textComp.text += '6';
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            textComp.text += '7';
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            textComp.text += '8';
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            textComp.text += '9';
        }
        if (Input.GetKeyDown(KeyCode.KeypadEnter) && GetComponent<Text>().text != "")
        {
            demoManager.GetComponent<AILevelGenerator>().numOfRooms = int.Parse(textComp.text);
            demoManager.GetComponent<AILevelGenerator>().reloadRooms();
            Destroy(gameObject);
        }
    }
}
