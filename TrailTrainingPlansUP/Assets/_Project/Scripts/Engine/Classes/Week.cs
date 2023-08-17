using Romero.TrailTrainingPlans.Data;
using System;
using System.Collections.Generic;

namespace Romero.TrailTrainingPlans.Engine
{
    [Serializable]
    public class Week
    {

        #region Variables

        public weekTrainingType trainingType;
        public List<Activity> ActivityList;
        public double kmToDo;

        #endregion

    }
}