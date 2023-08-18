using Romero.TrailTrainingPlans.Engine;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Romero.TrailTrainingPlans.Management
{

    public class MainSceneManager : MonoBehaviour
    {

        #region Variables

        private Profile userProfile;

        #endregion

        #region Unity Methods

        private void Awake()
        {
            // Never destroy the manager
            DontDestroyOnLoad(gameObject);
        }

        #endregion

        #region Data Management

        public void SaveData()
        {
            userProfile.Save();
        }

        public void LoadData(string fileName)
        {
            string jsonString = File.ReadAllText(fileName);
            userProfile = JsonUtility.FromJson<Profile>(jsonString);
        }

        #endregion

        #region Scene Management

        public void LoadCalendarScene()
        {
            SceneManager.LoadScene("CalendarView");
        }

        #endregion

        #region Setters/Getters

        public void SetProfile(Profile profile)
        {
            userProfile = profile;
        }

        public string GetProfileName()
        {
            return userProfile.name;
        }

        #endregion

    }

}
