using Romero.TrailTrainingPlans.Engine;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

namespace Romero.TrailTrainingPlans.Management
{

    public class StartSceneManager : MonoBehaviour
    {

        #region Variables

        [Header("Profile selection view")]
        public GameObject profileSelectionView;
        public TMP_Dropdown profileChoiceDropdown;

        [Header("Profile creation view")]
        public GameObject profileCreationView;
        public TMP_InputField newProfileName;

        private MainSceneManager mainSceneManager;

        #endregion

        #region Unity Methods

        private void Awake()
        {
            ButtonBackToProfileSelection();
            mainSceneManager = GameObject.Find("GlobalManager").GetComponent<MainSceneManager>();

            string dir = @"Saves";
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            List<string> options = new List<string>();
            foreach (string file in Directory.GetFiles("Saves"))
            {
                // J'enlève le "/Saves"
                string fileName = file.Substring(6);
                // J'enlève le ".json"
                fileName = fileName.Substring(0, fileName.Length - 5);
                // J'ajoute le choix au menu
                options.Add(fileName);
            }
            profileChoiceDropdown.AddOptions(options);
        }

        #endregion

        #region Buttons Callbacks

        public void ButtonValidateProfileChoice()
        {
            mainSceneManager.LoadData("Saves/" + profileChoiceDropdown.captionText.text + ".json");
            Debug.Log("TODO : Load calendar scene");
        }

        public void ButtonCreateNewProfile()
        {
            profileCreationView.SetActive(true);
            profileSelectionView.SetActive(false);
        }

        public void ButtonBackToProfileSelection()
        {
            profileSelectionView.SetActive(true);
            profileCreationView.SetActive(false);
        }

        public void ButtonCreateAndSaveProfile()
        {
            Profile newProfile = new Profile(newProfileName.text);
            mainSceneManager.SetProfile(newProfile);
            mainSceneManager.SaveData();
            Debug.Log("TODO : Open the main profile page scene (calendar?)");
        }

        #endregion

    }

}
