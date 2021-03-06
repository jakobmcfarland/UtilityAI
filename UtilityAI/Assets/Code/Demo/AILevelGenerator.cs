﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Code.UtilityAI;
using Assets.Code.Demo;

public class AILevelGenerator : MonoBehaviour
{
    public bool asYouGo = false;
    public float distToCont = 1100;
    public GameObject canvas;
    public GameObject player;
    public GameObject roomParent;
    public BehaviorMaster behaviorMaster = new BehaviorMaster();
    public BehaviorMaster branchingMaster = new BehaviorMaster();
    public GameObject greyRoom;
    public GameObject greenRoom;
    public GameObject blueRoom;
    public GameObject orangeRoom;
    public GameObject purpleRoom;
    public GameObject yellowPillar;
    public GameObject textPrefab;

    public int currentDirection = 2;
    public float roomWidth = 5;
    public string prevRoomDirection;
    public string prevRoomType;
    public GameObject prevRoom;
    public int numOfRooms = 500;
    public int numOfBranchingRooms = 20;

    Vector3 playerStartPos;
    public bool textSpawned = false;

    void Start()
    {
        playerStartPos = player.transform.position;
        // Template for adding behavior, add any needed
        // game objects and insert the proper type

        // List of behaviors
        IBehavior greyDown = new GreyRoomDownBehavior();
        initializeRoom(behaviorMaster, greyDown);
        initializeRoom(branchingMaster, greyDown);

        IBehavior greyLeft = new GreyRoomLeftBehavior();
        initializeRoom(behaviorMaster, greyLeft);
        initializeRoom(branchingMaster, greyLeft);

        IBehavior greyRight = new GreyRoomRightBehavior();
        initializeRoom(behaviorMaster, greyRight);
        initializeRoom(branchingMaster, greyRight);

        IBehavior greyUp = new GreyRoomUpBehavior();
        initializeRoom(behaviorMaster, greyUp);
        initializeRoom(branchingMaster, greyUp);

        IBehavior greenDown = new GreenRoomDownBehavior();
        initializeRoom(behaviorMaster, greenDown);
        initializeRoom(branchingMaster, greenDown);

        IBehavior greenLeft = new GreenRoomLeftBehavior();
        initializeRoom(behaviorMaster, greenLeft);
        initializeRoom(branchingMaster, greenLeft);

        IBehavior greenRight = new GreenRoomRightBehavior();
        initializeRoom(behaviorMaster, greenRight);
        initializeRoom(branchingMaster, greenRight);

        IBehavior greenUp = new GreenRoomUpBehavior();
        initializeRoom(behaviorMaster, greenUp);
        initializeRoom(branchingMaster, greenUp);

        IBehavior blueDown = new BlueRoomDownBehavior();
        initializeRoom(behaviorMaster, blueDown);
        initializeRoom(branchingMaster, blueDown);

        IBehavior blueLeft = new BlueRoomLeftBehavior();
        initializeRoom(behaviorMaster, blueLeft);
        initializeRoom(branchingMaster, blueLeft);

        IBehavior blueRight = new BlueRoomRightBehavior();
        initializeRoom(behaviorMaster, blueRight);
        initializeRoom(branchingMaster, blueRight);

        IBehavior blueUp = new BlueRoomRightBehavior();
        initializeRoom(behaviorMaster, blueUp);
        initializeRoom(branchingMaster, blueUp);

        IBehavior purpleUp = new PurpleRoomUpBehavior();
        initializeRoom(behaviorMaster, purpleUp);

        IBehavior purpleDown = new PurpleRoomDownBehavior();
        initializeRoom(behaviorMaster, purpleDown);

        //IBehavior yellowPillar = new YellowPillarBehavior();
        //initializeRoom(behaviorMaster, yellowPillar);
        //initializeRoom(branchingMaster, blueUp);

        IBehavior orange = new OrangeRoomBehavior();
        initializeRoom(behaviorMaster, orange); 

        prevRoom = GameObject.Instantiate(greyRoom, Vector3.zero, Quaternion.identity);
        prevRoomType = "grey";
        prevRoomDirection = "down";
        prevRoom.transform.SetParent(roomParent.transform);

        // Runs probabilityDecide until all of the rooms are created
        for (int i = 0; i < numOfRooms; i++)
        {
            behaviorMaster.probabilityDecide();
        }
    }

    private void Update()
    {
        if (asYouGo && Vector3.Distance(prevRoom.transform.position, Camera.main.transform.position) <= distToCont)
        {
            for (int i = 0; i < numOfRooms; i++)
            {
                behaviorMaster.probabilityDecide();
            }
        }
        if (Input.GetKeyDown(KeyCode.R) && !textSpawned)
        {
            textSpawned = true;
            GameObject tempText = Instantiate(textPrefab);
            tempText.transform.SetParent(canvas.transform);
            tempText.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
            tempText.GetComponent<roomNumberText>().demoManager = gameObject;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            reloadRooms();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
        }
    }

    public void CreateBranchingRooms()
    {
        for (int i = 0; i < numOfBranchingRooms; i++)
        {
            branchingMaster.probabilityDecide();
        }
    }

    void initializeRoom(BehaviorMaster behaviorMaster_, IBehavior room)
    {
        room.GiveGameObject(gameObject, "generator");
        room.GiveGameObject(roomParent, "parent");
        behaviorMaster_.AddBehavior(room);
    }

    public void reloadRooms()
    {

        textSpawned = false;
        // Resets the player
        player.transform.position = playerStartPos;
        // Destroys all previous rooms
        foreach (Transform t in roomParent.GetComponentsInChildren<Transform>())
        {
            if (t.gameObject != roomParent)
            {
                Destroy(t.gameObject);
            }
        }
        // Spawns first room
        prevRoom = GameObject.Instantiate(greyRoom, Vector3.zero, Quaternion.identity);
        prevRoomType = "grey";
        prevRoomDirection = "down";
        prevRoom.transform.SetParent(roomParent.transform);
        // Runs probabilityDecide until all of the rooms are created
        for (int i = 0; i < numOfRooms; i++)
        {
            behaviorMaster.probabilityDecide();
        }
    }
}
