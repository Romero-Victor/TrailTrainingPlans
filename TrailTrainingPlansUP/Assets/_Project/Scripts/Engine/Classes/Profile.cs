using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Romero.TrailTrainingPlans.Engine
{
    [Serializable]
    public class Profile
    {

        #region Variables

        public string name;
        public List<Season> seasons;
        public Parameters parameters;

        #endregion

        #region Constructors

        public Profile(string name) 
        {
            this.name = name;
            parameters = new Parameters(1, 0.6, 1);
        }

        #endregion

        #region Save and Load

        public void Save()
        {
            string dir = @"Saves";
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            var jsonData = JsonUtility.ToJson(this);
            string fileName = "Saves/" + name + ".json";
            File.WriteAllText(fileName, jsonData);
        }

        #endregion

    }
}