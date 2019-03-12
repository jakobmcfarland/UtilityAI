using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Code.UtilityAI
{
    class ExampleBehavior : IBehavior
    {
        public int GetPointCount()
        {
            int points;

            points += 100;

            points += 200;

            points += 300;

            return points;
        }
    }
}
