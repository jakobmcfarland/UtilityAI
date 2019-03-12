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

        void GiveGameObject( GameObject gameObject);
    }
}
