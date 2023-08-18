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
            mainSceneManager = GameObject.Find("GlobalManager").GetComponent<MainSceneManager>();
            ButtonBackToProfileSelection();
        }

        #endregion

        #region Buttons Callbacks

        /// <summary>
        /// Load the data of the selected profile and load the calendar scene
        /// </summary>
        public void ButtonValidateProfileChoice()
        {
            if (profileChoiceDropdown.captionText.text != "") 
            {
                mainSceneManager.LoadData("Saves/" + profileChoiceDropdown.captionText.text + ".json");
                mainSceneManager.LoadCalendarScene();
            }
        }

        /// <summary>
        /// Open the "create new profile" view
        /// </summary>
        public void ButtonCreateNewProfile()
        {
            profileCreationView.SetActive(true);
            profileSelectionView.SetActive(false);
        }

        /// <summary>
        /// Open the profile selection view. Also add the profiles saves to the options of the dropdown menu
        /// </summary>
        public void ButtonBackToProfileSelection()
        {

            // Création et ajout des options
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

            profileChoiceDropdown.ClearOptions();
            profileChoiceDropdown.AddOptions(options);

            // Affichage des bonnes fenêtres
            profileSelectionView.SetActive(true);
            profileCreationView.SetActive(false);

        }

        /// <summary>
        /// Creates a new profile object and save it in a json file. Also goes back to the selection view
        /// </summary>
        public void ButtonCreateAndSaveProfile()
        {
            Profile newProfile = new Profile(newProfileName.text);
            mainSceneManager.SetProfile(newProfile);
            mainSceneManager.SaveData();
            ButtonBackToProfileSelection();
        }

        /// <summary>
        /// Close the application
        /// </summary>
        public void ButtonQuit()
        {
            Application.Quit();
        }

        #endregion

    }

}