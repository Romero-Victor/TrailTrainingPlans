using System;
using UnityEngine;

namespace Romero.TrailTrainingPlans.CalendarScene
{

    public class WeekDisplay : MonoBehaviour
    {

        #region Variables

        public DayDisplay[] days;

        private DateTime firstDayOfTheWeek = DateTime.Today;

        #endregion

        #region Setters/Getters

        public void SetFirstDayOfTheWeek(DateTime date)
        {
            firstDayOfTheWeek = date;
            for (int i = 0; i < days.Length; i++)
            {
                days[i].SetDateOfTheDay(firstDayOfTheWeek.AddDays(i));
            }
        }

        #endregion

    }

}
