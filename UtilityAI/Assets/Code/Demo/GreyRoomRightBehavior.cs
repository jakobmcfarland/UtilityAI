/* 
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

        public int GetPointCount()
        {
            int points = 0;

            //if (generator.prevRoomDirection != "left") points += 50;

            //if (generator.prevRoomType == "grey") points += 50;

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
            //example behavior action
            //Vector3 translation = generator.prevObject

            //generator.prevRoomType = "Grey";
            //generator.prevRoomDirection = "right";
        }
    }
}