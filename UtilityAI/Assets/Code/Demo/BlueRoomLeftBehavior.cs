using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Code.UtilityAI;

namespace Assets.Code.Demo
{
    public class BlueRoomLeftBehavior : IBehavior
    {
        AILevelGenerator generator;

        public int GetPointCount()
        {
            int points = 0;

            //if (generator.prevRoomDirection != "right") points += 50;

            //if (generator.prevRoomType == "blue") points -= 50;

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

            //generator.prevRoomType = "Blue";
            //generator.prevRoomDirection = "left";
        }
    }
}
}