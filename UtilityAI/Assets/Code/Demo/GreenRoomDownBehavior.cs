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
            int points = 50;

            //if (generator.prevRoomType == "green") points += 50;

            //if (generator.prevRoomType == "grey") points += 100;

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

            //generator.prevRoomType = "Green";
            //generator.prevRoomDirection = "down";
        }
    }
}