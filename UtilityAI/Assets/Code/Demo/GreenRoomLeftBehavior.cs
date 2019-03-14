using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Code.UtilityAI;

namespace Assets.Code.Demo
{
    public class GreenRoomLeftBehavior : IBehavior
    {
        AILevelGenerator generator;

        public int GetPointCount()
        {
            int points = 0;

			if (generator.prevRoomDirection != "right" && generator.currentDirection != 1)
			{
				points += 50;

				if (generator.prevRoomType == "green")
					points += 200;
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
                prevTrasnform.position + Vector3.left * generator.roomWidth, Quaternion.identity);

            generator.prevRoom = spawn;
            generator.prevRoomType = "green";
            generator.prevRoomDirection = "left";
        }
    }
}