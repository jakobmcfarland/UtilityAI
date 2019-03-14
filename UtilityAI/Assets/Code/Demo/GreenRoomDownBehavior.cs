using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Code.UtilityAI;

namespace Assets.Code.Demo
{
    public class GreenRoomDownBehavior : IBehavior
    {
        AILevelGenerator generator;

        public int GetPointCount()
        {
            int points = 0;
            if (generator.prevRoomDirection != "up" && generator.currentDirection != 0)
            {
                points = 50;

                if (generator.prevRoomType == "green") points += 50;

                if (generator.prevRoomType == "grey") points += 100;
            }

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
            GameObject spawn = GameObject.Instantiate(generator.greenRoom,
                prevTrasnform.position + Vector3.back * generator.roomWidth, Quaternion.identity);

            generator.prevRoom = spawn;
            generator.prevRoomType = "green";
            generator.prevRoomDirection = "down";
        }
    }
}