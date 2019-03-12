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

            points += 100;

            points += 200;

            points += 300;

            return points;
        }

        public void GiveGameObject(GameObject gameObject)
        {
            Owner = gameObject;
        }
    }
}
