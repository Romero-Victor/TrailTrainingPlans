using System;

namespace Romero.TrailTrainingPlans.Engine
{
    [Serializable]
    public class Parameters
    {

        #region Variables

        public double coefBase, coefIntensity, coefRest;

        #endregion

        #region Constructors
        
        public Parameters(double coefBase, double coefIntensity, double coefRest)
        {
            this.coefBase = coefBase;
            this.coefIntensity = coefIntensity;
            this.coefRest = coefRest;
        }

        #endregion

    }
}