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
    public class GreyRoomDownBehavior : IBehavior
    {
        AILevelGenerator generator;

        public int GetPointCount()
        {
            int points = 50;

            //if (generator.prevRoomType == "grey") points += 100;

            //if (generator.prevRoomType != "blue") points += 50;

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
            //generator.prevRoomDirection = "down";
        }
    }
}