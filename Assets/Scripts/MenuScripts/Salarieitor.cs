using System;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class Salarieitor : MonoBehaviour
{
    public Button trabajar;

    public Button noTrabajar;

    public Button cobrar;

    public Text horas;

    public Text dinero;

    private void Start()
    {
        if (!DataSaver.CheckIfFileExists(Application.persistentDataPath + "/salarieitor"))
        {
            DataSaver.CreateFolder(Application.persistentDataPath + "/salarieitor");
            DataSaver.CreateTxt(Application.persistentDataPath + "/salarieitor/last.tcsf", new string[1] { "" });
            DataSaver.CreateTxt(Application.persistentDataPath + "/salarieitor/hours.tcsf", new string[1] { "0" });
        }
        if (DataSaver.ReadTxt(Application.persistentDataPath + "/salarieitor/last.tcsf")[0] == "")
        {
            noTrabajar.gameObject.SetActive(value: false);
            trabajar.gameObject.SetActive(value: true);
        }
        else
        {
            noTrabajar.gameObject.SetActive(value: true);
            trabajar.gameObject.SetActive(value: false);
        }
        int num = Convert.ToInt32(DataSaver.ReadTxt(Application.persistentDataPath + "/salarieitor/hours.tcsf")[0]);
        horas.text = "Horas trabajadas: " + num / 60;
    }

    private void Update()
    {
    }

    public void Comenzar()
    {
        DataSaver.ModifyTxt(Application.persistentDataPath + "/salarieitor/last.tcsf", new string[1] { DateTime.Now.ToString(CultureInfo.InvariantCulture) });
        noTrabajar.gameObject.SetActive(value: true);
        trabajar.gameObject.SetActive(value: false);
    }

    public void Finalizar()
    {
        int num = Convert.ToInt32(DataSaver.ReadTxt(Application.persistentDataPath + "/salarieitor/hours.tcsf")[0]);
        DateTime dateTime = DateTime.Parse(DataSaver.ReadTxt(Application.persistentDataPath + "/salarieitor/last.tcsf")[0], CultureInfo.InvariantCulture);
        Debug.Log(dateTime);
        int num2 = (int)(DateTime.Now - dateTime).TotalMinutes;
        num += num2;
        horas.text = "Horas trabajadas: " + num / 60;
        DataSaver.ModifyTxt(Application.persistentDataPath + "/salarieitor/hours.tcsf", new string[1] { num.ToString() ?? "" });
        DataSaver.ModifyTxt(Application.persistentDataPath + "/salarieitor/last.tcsf", new string[1] { "" });
        noTrabajar.gameObject.SetActive(value: false);
        trabajar.gameObject.SetActive(value: true);
    }

    public void Cobrar()
    {
        int num = Convert.ToInt32(DataSaver.ReadTxt(Application.persistentDataPath + "/salarieitor/hours.tcsf")[0]);
        horas.text = "Horas trabajadas: " + num / 60;
        dinero.text = "Dinero a pagar: " + (float)num * 0.75f / 60f + "€";
        DataSaver.ModifyTxt(Application.persistentDataPath + "/salarieitor/hours.tcsf", new string[1] { "0" });
    }
}
