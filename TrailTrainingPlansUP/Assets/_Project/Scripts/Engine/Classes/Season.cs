using System;
using System.Collections.Generic;

namespace Romero.TrailTrainingPlans.Engine
{
    [Serializable]
    public class Season
    {

        #region Variables

        public List<Goal> seasonGoals;
        public Week[] weeks;
        public double originalSeasonGoal;
        public object computedSeasonGoal;

        #endregion

    }
}
