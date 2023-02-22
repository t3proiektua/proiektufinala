using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static System.Net.WebRequestMethods;

public class Login : MonoBehaviour
{
    public InputField username;
    private string userPrefsName = "User";
    public void LogIn()//erabiltzaileak baimena duen edo ez ikusiko du 
    {
        SqliteDBConect con = new SqliteDBConect(); //datu base lokalera konektatuko da
        DataSet dsUsuarios = con.Query("SELECT * FROM Langilea");//langilea taulako erregistro guztiak lortuko ditugu
        Boolean aurkituta = false;
        for (int i = 0; i < dsUsuarios.Tables[0].Rows.Count;i++)//erregistro guztiak ikusiko ditugu gure erabiltzailea aurkitu arte edota erregistro gabe gelditu arte
        {
            if (username.text.Trim().Equals(dsUsuarios.Tables[0].Rows[i]["UserName"].ToString().Trim()))//erregistroa aurkitzean bukletik irtengo da eta aldagaiaren balioa aldatuko du
            {
                aurkituta = true;
                break;
            }
        }
        if (aurkituta)//erabiltzailea aurkitu badu, datua gordeko du eta jolasten hasiko da
        {
            SaveData();
            Play();
        }
        else
        {
            Debug.Log("Zure erabiltzailea ez da existitzen");
        }
    }
    public void Play()
    {
        SceneManager.LoadScene(2);//jokoa kargatuko du
    }
    private void SaveData()
    {
        PlayerPrefs.SetString(userPrefsName, username.text);//datua gordeko du
    }
}
