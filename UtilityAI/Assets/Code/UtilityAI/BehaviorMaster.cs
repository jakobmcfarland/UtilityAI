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
    public IBehavior GetBehavior(int index)
    {
        return behaviors[index];
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
        behaviors[maxIndex].RunBehavior();
    }
    public void probabilityDecide()
    {
        List<int> pointCounts = getPointCounts();
        int pointTotal = 0;
        foreach (int i in pointCounts)
        {
            pointTotal += i;
        }
        int currPointCheck = 0, randNum = Random.Range(1, pointTotal), currIndex = 0;
        foreach (int points in pointCounts)
        {
            if (randNum < points + currPointCheck)
            {
                behaviors[currIndex].RunBehavior();
                break;
            }
            currPointCheck += points;
            currIndex++;
        }
        
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
