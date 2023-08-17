using Romero.TrailTrainingPlans.Engine;
using System.IO;
using UnityEngine;

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

        #region Setters

        public void SetProfile(Profile profile)
        {
            userProfile = profile;
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

    }

}
