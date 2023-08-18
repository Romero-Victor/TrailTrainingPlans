using System;
using TMPro;
using UnityEngine;

namespace Romero.TrailTrainingPlans.CalendarScene
{

    public class DayDisplay : MonoBehaviour
    {

        #region Variables

        public TMP_Text dateDisplay;

        private DateTime date = DateTime.Today;

        #endregion

        #region Getters/Setters

        public void SetDateOfTheDay(DateTime date)
        {
            this.date = date;
            dateDisplay.text = date.ToString("d");
        }

        #endregion

    }

}
