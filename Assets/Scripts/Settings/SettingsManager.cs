using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Text;
using UnityEditor.PackageManager;
using System.IO;

public class SettingsManager : MonoBehaviour
{
    public static Settings Settings { get; set; }
    string fileName = "Assets/Settings/Settings.json";

    public void Start()
    {
        Settings = new Settings();
        LoadSettings();
    }
    public void SaveSettings()
    {
        string serealizedSettings = Newtonsoft.Json.JsonConvert.SerializeObject(Settings);
        File.WriteAllText(fileName, serealizedSettings);
    }

    public void LoadSettings()
    {
        string settingsText = File.ReadAllText(fileName);
        Settings deserializedSettings = Newtonsoft.Json.JsonConvert.DeserializeObject<Settings>(settingsText);
        Settings = deserializedSettings;
    }
}
