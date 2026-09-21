using System.Collections;
using System.Collections.Generic;
using System;

[Serializable]
public abstract class SaveData { }

[Serializable]
public class StringArraySaveData : SaveData
{
    public string[] saves;
    public StringArraySaveData(string[] statsSave)
    {
        saves = statsSave;
    }
}
