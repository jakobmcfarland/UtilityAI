using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Code.UtilityAI;

namespace Assets.Code.Demo
{
    public class BlueRoomUpBehavior : IBehavior
    {
        AILevelGenerator generator;

        public int GetPointCount()
        {
            int points = 0;

            if (generator.prevRoomDirection != "down" && generator.prevRoomType == "blue" && generator.currentDirection != 2) points += 60;

            return points;
        }

        public void GiveGameObject(GameObject gameObject, string tag)
        {
            if (tag == "generator")
            {
                generator = gameObject.GetComponent<AILevelGenerator>();
            }
        }

        public void RunBehavior()
        {
            Transform prevTrasnform = generator.prevRoom.GetComponent<Transform>();
            GameObject spawn = GameObject.Instantiate(generator.blueRoom, 
                prevTrasnform.position + Vector3.forward * generator.roomWidth, Quaternion.identity);

            generator.prevRoom = spawn;
            generator.prevRoomType = "blue";
            generator.prevRoomDirection = "up";
        }
    }
}