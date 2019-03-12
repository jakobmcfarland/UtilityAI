/*  
 *  File:   IBehavior.cs
 *  By:     Jakob McFarland
 *  Date:   3/11/2019
 * 
 *  Brief:  
 *      Implementation of the behavior interface for
 *      all custom behavior classes.
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using UnityEngine;
using Assets.Code.UtilityAI;

namespace Assets.Code.UtilityAI
{
    public interface IBehavior
    {
        int GetPointCount();

        void GiveGameObject( GameObject gameObject, string tag);

        void RunBehavior();
    }
}
