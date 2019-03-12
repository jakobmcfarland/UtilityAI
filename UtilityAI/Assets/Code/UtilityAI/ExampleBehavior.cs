using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Code.UtilityAI
{
    class ExampleBehavior : IBehavior
    {
        public List<int> GetPointCount()
        {
            List<int> points = new List<int>();

            points.Add(100);

            points.Add(200);

            points.Add(300);

            return points;
        }
    }
}
