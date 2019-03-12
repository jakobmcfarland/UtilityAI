using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Code.UtilityAI;

public class BehaviorMaster
{
    // List of all behaviors in the BehaviorMaster
    private List<IBehavior> behaviors;
    // Adds a new behavior to the behavior list
    public void AddBehavior(IBehavior behavior)
    {
        behaviors.Add(behavior);
    }
    public IBehavior GetBehavior()
    {
        return behaviors[0];
    }
    public void staticDecide()
    {
        List<int> pointCounts = getPointCounts();
        int maxIndex = 0, i, currMax = pointCounts[0];
        for (i = 1; i < pointCounts.Capacity; i++)
        {
            if (pointCounts[i] > currMax)
            {
                currMax = pointCounts[i];
                maxIndex = i;
            }
        }

    }
    public void probabilityDecide()
    {

    }
    private List<int> getPointCounts()
    {
        List<int> pointCounts = new List<int>();
        foreach (IBehavior iB in behaviors)
        {
            pointCounts.Add(iB.GetPointCount());
        }
        return pointCounts;
    }
}
