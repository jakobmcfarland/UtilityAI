using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Code.UtilityAI;

public class AILevelGenerator : MonoBehaviour
{
    public BehaviorMaster behaviorMaster;
    public GameObject greyRoom;
    public GameObject greenRoom;
    public GameObject blueRoom;
    public GameObject prevRoom;
    public int numOfRooms = 20;
    void Start()
    {
        // Template for adding behavior, add any needed
        // game objects and insert the proper type

        //IBehavior behavior1 = new ExampleBehavior();
        //behavior1.GiveGameObject(gameObject, "owner");
        //behavior1.GiveGameObject(greyRoom, "room");
        //behaviorMaster.AddBehavior(behavior1);

        // List of behaviors


        // Runs probabilityDecide until all of the rooms are created
        for (int i = 0; i < numOfRooms; i++)
        {
            behaviorMaster.probabilityDecide();
        }
    }
}
