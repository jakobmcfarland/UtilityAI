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
    public class YellowPillarBehavior : IBehavior
    {
        AILevelGenerator generator;
        GameObject parent;


        public int GetPointCount()
        {
            int points = 0;

            if (generator.prevRoomDirection != "stair" && generator.prevRoomType == "blue")
            {
                points += 100;
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
            GameObject spawn = GameObject.Instantiate(generator.yellowPillar, 
                prevTrasnform.position, Quaternion.identity);
            spawn.transform.SetParent(parent.transform);

            //generator.prevRoomType = "pillar";
        }
    }
}