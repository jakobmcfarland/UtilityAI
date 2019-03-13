using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Code.UtilityAI;
using Assets.Code.Demo;

public class AILevelGenerator : MonoBehaviour
{
    public BehaviorMaster behaviorMaster = new BehaviorMaster();
    public GameObject greyRoom;
    public GameObject greenRoom;
    public GameObject blueRoom;
	public GameObject orangeRoom;

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
        greyDown.GiveGameObject(gameObject, "generator");
        behaviorMaster.AddBehavior(greyDown);

        IBehavior greyLeft = new GreyRoomLeftBehavior();
        greyLeft.GiveGameObject(gameObject, "generator");
        behaviorMaster.AddBehavior(greyLeft);

        IBehavior greyRight = new GreyRoomRightBehavior();
        greyRight.GiveGameObject(gameObject, "generator");
        behaviorMaster.AddBehavior(greyRight);

        IBehavior greenDown = new GreenRoomDownBehavior();
        greenDown.GiveGameObject(gameObject, "generator");
        behaviorMaster.AddBehavior(greenDown);

        IBehavior greenLeft = new GreenRoomLeftBehavior();
        greenLeft.GiveGameObject(gameObject, "generator");
        behaviorMaster.AddBehavior(greenLeft);

        IBehavior greenRight = new GreenRoomRightBehavior();
        greenRight.GiveGameObject(gameObject, "generator");
        behaviorMaster.AddBehavior(greenRight);

        IBehavior blueDown = new BlueRoomDownBehavior();
        blueDown.GiveGameObject(gameObject, "generator");
        behaviorMaster.AddBehavior(blueDown);

        IBehavior blueLeft = new BlueRoomLeftBehavior();
        blueLeft.GiveGameObject(gameObject, "generator");
        behaviorMaster.AddBehavior(blueLeft);

        IBehavior blueRight = new BlueRoomRightBehavior();
        blueRight.GiveGameObject(gameObject, "generator");
        behaviorMaster.AddBehavior(blueRight);

		IBehavior orange = new OrangeRoomBehavior();
		orange.GiveGameObject(gameObject, "generator");
		behaviorMaster.AddBehavior(orange);

        prevRoom = GameObject.Instantiate(greyRoom, Vector3.zero, Quaternion.identity);
        prevRoomType = "grey";
        prevRoomDirection = "down";

        // Runs probabilityDecide until all of the rooms are created
        for (int i = 0; i < numOfRooms; i++)
        {
            behaviorMaster.probabilityDecide();
        }
    }
}
