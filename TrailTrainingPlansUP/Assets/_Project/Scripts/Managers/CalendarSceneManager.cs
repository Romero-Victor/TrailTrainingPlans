using Romero.TrailTrainingPlans.CalendarScene;
using System;
using TMPro;
using UnityEngine;

namespace Romero.TrailTrainingPlans.Management
{

    public class CalendarSceneManager : MonoBehaviour
    {

        #region Variables

        public TMP_Text profileNameText;
        public WeekDisplay[] weeks;

        private MainSceneManager mainManager;
        private DateTime firstDayDisplayed;

        #endregion

        #region Unity Methods

        private void Awake()
        {
            mainManager = GameObject.Find("GlobalManager").GetComponent<MainSceneManager>();
            profileNameText.text = "Bienvenue " + mainManager.GetProfileName();
            // Le premier jour à afficher est le lundi de la semaine, sauf quand on est dimanche (0), et on affiche alors lundi de la semaine d'après
            SetFirstDayDisplayed(DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + 1));
        }

        #endregion

        #region Private Methods

        private void SetFirstDayDisplayed(DateTime firstDayDisplayed)
        {
            this.firstDayDisplayed = firstDayDisplayed;
            for (int i = 0; i < weeks.Length; i++)
            {
                weeks[i].SetFirstDayOfTheWeek(firstDayDisplayed.AddDays(i * 7 - 7));
            }
        }

        #endregion

        #region Buttons

        /// <summary>
        /// Close the application
        /// </summary>
        public void ButtonQuit()
        {
            Application.Quit();
        }

        public void ButtonNextWeek()
        {
            SetFirstDayDisplayed(firstDayDisplayed.AddDays(7));
        }

        public void ButtonPreviousWeek()
        {
            SetFirstDayDisplayed(firstDayDisplayed.AddDays(-7));
        }

        #endregion

    }

}
