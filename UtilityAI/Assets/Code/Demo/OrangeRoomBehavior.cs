/* 
 *  File:   GreyRoomDownBehavior.cs
 *  By:     Jakob McFarland
 *  Date:   3/12/2019
 * 
 *  Brief:  
 *     Demo grey room down Behavior class.
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Code.UtilityAI;

namespace Assets.Code.Demo
{
    public class OrangeRoomBehavior : IBehavior
    {
        AILevelGenerator generator;
        GameObject parent;

        public int GetPointCount()
        {
            int points = 50;

            return points;
        }

        public void GiveGameObject(GameObject gameObject, string tag)
        {
            if (tag == "generator")
            {
                generator = gameObject.GetComponent<AILevelGenerator>();
            }
            else if (tag == "parent")
            {
                parent = gameObject;
            }
        }

        public void RunBehavior()
        {
            Transform prevTrasnform = generator.prevRoom.GetComponent<Transform>();

			GameObject spawn = GameObject.Instantiate(generator.orangeRoom,
				prevTrasnform.position + Vector3.up * generator.roomWidth, Quaternion.identity);
			int height = Random.Range(0, 1);

			for (int i = 0; i < height; ++i)
			{
				prevTrasnform = spawn.GetComponent<Transform>();

				spawn = GameObject.Instantiate(generator.orangeRoom,
					prevTrasnform.position + Vector3.up * generator.roomWidth, Quaternion.identity);
			}
            spawn.transform.SetParent(parent.transform);

            generator.prevRoom = spawn;
            generator.prevRoomType = "orange";
            generator.prevRoomDirection = "stair";

            generator.currentDirection = Random.Range(0, 4);

        }
    }
}