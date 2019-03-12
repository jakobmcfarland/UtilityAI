using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Code.UtilityAI;

public class BehaviorMaster
{
    private List<IBehavior> behaviors;
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
        int maxIndex;
        int i;
        for (i = 0; i < pointCounts.Capacity; i++)
        {

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
