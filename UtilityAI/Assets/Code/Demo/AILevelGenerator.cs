using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Code.UtilityAI;
using Assets.Code.Demo;

public class AILevelGenerator : MonoBehaviour
{
    public GameObject roomParent;
    public BehaviorMaster behaviorMaster = new BehaviorMaster();
    public GameObject greyRoom;
    public GameObject greenRoom;
    public GameObject blueRoom;
	public GameObject orangeRoom;

    public int currentDirection = 2;
	public float roomWidth = 5;
    public string prevRoomDirection;
    public string prevRoomType;
    public GameObject prevRoom;
    public int numOfRooms = 10;


    void Start()
    {
        // Template for adding behavior, add any needed
        // game objects and insert the proper type

        // List of behaviors
        IBehavior greyDown = new GreyRoomDownBehavior();
        initializeRoom(greyDown);

        IBehavior greyLeft = new GreyRoomLeftBehavior();
        initializeRoom(greyLeft);

        IBehavior greyRight = new GreyRoomRightBehavior();
        initializeRoom(greyRight);

        IBehavior greyUp = new GreyRoomUpBehavior();
        initializeRoom(greyUp);

        IBehavior greenDown = new GreenRoomDownBehavior();
        initializeRoom(greenDown);

        IBehavior greenLeft = new GreenRoomLeftBehavior();
        initializeRoom(greenLeft);

        IBehavior greenRight = new GreenRoomRightBehavior();
        initializeRoom(greenRight);

        IBehavior greenUp = new GreenRoomUpBehavior();
        initializeRoom(greenUp);

        IBehavior blueDown = new BlueRoomDownBehavior();
        initializeRoom(blueDown);

        IBehavior blueLeft = new BlueRoomLeftBehavior();
        initializeRoom(blueLeft);

        IBehavior blueRight = new BlueRoomRightBehavior();
        initializeRoom(blueRight);

        IBehavior blueUp = new BlueRoomRightBehavior();
        initializeRoom(blueUp);

        IBehavior orange = new OrangeRoomBehavior();
        initializeRoom(orange);

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
        if (Input.GetKeyDown(KeyCode.R))
        {
            reloadRooms();
        }
    }

    void initializeRoom(IBehavior room)
    {
        room.GiveGameObject(gameObject, "generator");
        room.GiveGameObject(roomParent, "parent");
        behaviorMaster.AddBehavior(room);
    }

    void reloadRooms()
    {
        // Destroys all previous rooms
        foreach(Transform t in roomParent.GetComponentsInChildren<Transform>())
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
