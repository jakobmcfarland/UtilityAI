﻿/* 
 *  File:   Grey.cs
 *  By:     Jakob McFarland
 *  Date:   3/12/2019
 * 
 *  Brief:  
 *     Demo grey room Behavior class.
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Code.UtilityAI;

namespace Assets.Code.Demo
{
    public class GreyRoomRightBehavior : IBehavior
    {
        AILevelGenerator generator;
        GameObject parent;

        public int GetPointCount()
        {
            int points = 0;

			if (generator.prevRoomDirection != "left" && generator.currentDirection != 3) 
			{
				points += 50;

				if (generator.prevRoomType == "grey")
					points += 50;
			}

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
            GameObject spawn = GameObject.Instantiate(generator.greyRoom,
                prevTrasnform.position + Vector3.right * generator.roomWidth, Quaternion.identity);
            spawn.transform.SetParent(parent.transform);

            generator.prevRoom = spawn;
            generator.prevRoomType = "grey";
            generator.prevRoomDirection = "right";
        }
    }
}