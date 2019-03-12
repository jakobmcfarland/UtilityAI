/* 
 *  File:   ExampleBehavior.cs
 *  By:     Jakob McFarland
 *  Date:   3/11/2019
 * 
 *  Brief:  
 *      Example implementation of a Behavior class.
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Code.UtilityAI
{
    class ExampleBehavior : IBehavior
    {
        GameObject Owner;

        public int GetPointCount()
        {
            int points = 0;

            if ( Owner.GetComponent<Transform>().position.z > 0.0f) points -= 100;

            if (Owner.GetComponent<Transform>().position.z < 0.0f) points += 200;

            return points;
        }

        public void GiveGameObject(GameObject gameObject, string tag)
        {
            if(tag == "owner") Owner = gameObject;
        }

        public void RunBehavior()
        {
            //example behavior action
            Owner.GetComponent<Transform>().Translate(Vector3.up);
        }
    }
}
