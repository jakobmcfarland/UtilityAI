﻿/*  
 *  File:   BehaviorMaster.cs
 *  By:     Freddy Martin
 *  Date:   3/14/2019
 * 
 *  Brief:  
 *      Manager for IBehaviors and use of IBehaviors
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Code.UtilityAI;

public class BehaviorMaster
{
    // List of all behaviors in the BehaviorMaster
	private List<IBehavior> behaviors;

	public BehaviorMaster()
	{
		behaviors = new List<IBehavior>();
	}

    // Adds a new behavior to the behavior list
    public void AddBehavior(IBehavior behavior)
    {
        behaviors.Add(behavior);
    }
    // Removes a behavior at the given index
    public void RemoveBehavior(int index)
    {
        behaviors.RemoveAt(index);
    }
    // Returns the behavior at the given index
    public IBehavior GetBehavior(int index)
    {
        return behaviors[index];
    }
    // Runs the action of the highest point behavior
    public void staticDecide()
    {
        List<int> pointCounts = getPointCounts();
        int maxIndex = 0, i, currMax = pointCounts[0];
        // Finds the largest point behavior
        for (i = 1; i < pointCounts.Count; i++)
        {
            if (pointCounts[i] > currMax)
            {
                currMax = pointCounts[i];
                maxIndex = i;
            }
        }
        behaviors[maxIndex].RunBehavior();
    }
    // Randomly runs an action, with chances based on point totals
    public void probabilityDecide()
    {
        List<int> pointCounts = getPointCounts();
        int pointTotal = 0;
        // Loops through pointCounts and adds them to pointTotal
        foreach (int i in pointCounts)
        {
            pointTotal += i;
        }
        int currPointCheck = 0, randNum = Random.Range(1, pointTotal + 1), currIndex = 0;
        // Loops through the points and runs the one which falls in the correct range
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
    // Returns a list of ints with each of the behaviors
    private List<int> getPointCounts()
    {
        List<int> pointCounts = new List<int>();
        // Loops through behaviors and adds their point values to the end of the list
        foreach (IBehavior iB in behaviors)
        {
            pointCounts.Add(iB.GetPointCount());
        }
        return pointCounts;
    }
}
