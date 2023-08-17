using Romero.TrailTrainingPlans.Data;
using System;

namespace Romero.TrailTrainingPlans.Engine
{
    [Serializable]
    public class Activity
    {

        #region Variables

        public DateTime date;
        public sportType sportType;
        public string name;
        public double km;
        public double durationInSeconds;

        #endregion

    }

}
