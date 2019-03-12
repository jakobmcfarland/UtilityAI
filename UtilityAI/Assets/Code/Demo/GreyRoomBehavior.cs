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
    public class GreyRoomBehavior : IBehavior
    {
        GameObject room;

        public int GetPointCount()
        {
            int points = 0;

            if (Owner.GetComponent<Transform>().position.z > 0.0f) points -= 100;

            if (Owner.GetComponent<Transform>().position.z < 0.0f) points += 200;

            return points;
        }

        public void GiveGameObject(GameObject gameObject, string tag)
        {
            if (tag == "owner") Owner = gameObject;
        }

        public void RunBehavior()
        {
            //example behavior action
            Owner.GetComponent<Transform>().Translate(Vector3.up);
        }
    }
}