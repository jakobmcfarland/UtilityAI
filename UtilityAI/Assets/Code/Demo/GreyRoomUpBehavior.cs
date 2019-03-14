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
    public class GreyRoomUpBehavior : IBehavior
    {
        AILevelGenerator generator;

        public int GetPointCount()
        {
            int points = 0;
            if (generator.prevRoomDirection != "down" && generator.currentDirection != 2)
            {
                points = 50;
                if (generator.prevRoomType == "grey") points += 150;

                if (generator.prevRoomType != "blue") points += 50;
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
            GameObject spawn = GameObject.Instantiate(generator.greyRoom,
                prevTrasnform.position + Vector3.forward * generator.roomWidth, Quaternion.identity);

            generator.prevRoom = spawn;
            generator.prevRoomType = "grey";
            generator.prevRoomDirection = "up";
        }
    }
}