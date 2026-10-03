using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class OptionsManager
{
    public static OptionsSave optionsSave;
    public static string SavePath { get { return Application.persistentDataPath + "/options.tcsf"; } }

    public static bool ShaderOn
    {
        get 
        {
            LoadOptions();
            return optionsSave.shaderOn; 
        }
        set
        {
            LoadOptions();
            optionsSave.shaderOn = value;
            SaveOptions();
        }
    }


    public static void LoadOptions()
    {
        if(optionsSave == null)
        {
            if (DataSaver.CheckIfFileExists(SavePath))
            {
                optionsSave = DataSaver.LoadData<OptionsSave>(SavePath);
            }
            else
            {
                optionsSave = new OptionsSave(1);
                DataSaver.SaveData(optionsSave, SavePath);
            }
        }
    }

    public static void SaveOptions()
    {
        DataSaver.SaveData(optionsSave, SavePath);
    }

}

[Serializable]
public class OptionsSave : SaveData
{
    public bool shaderOn = true;

    public OptionsSave() { }
    public OptionsSave(int _)
    {
        shaderOn = true;
    }
}