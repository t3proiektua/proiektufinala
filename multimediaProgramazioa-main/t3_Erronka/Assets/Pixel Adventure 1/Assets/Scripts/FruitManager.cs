using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Data;
using Unity.VisualScripting;

public class FruitManager : MonoBehaviour
{
    public Text fruits; //fruta kopurua emango duen textu elementua
    private int mainmenu = 1, id = 0, kont = 0;
    private string scorePrefsName = "Score";
    private string userPrefsName = "User", userName;
    private float puntuazioa = 0f;
    private float puntuak = 10000f;
    private SqliteDBConect sqlConn = new SqliteDBConect(); //datu base lokalera konekzioa
    private void Update()
    {
        AllFruitsCollected();
    }
    public void AllFruitsCollected()
    {
        if (transform.childCount == 0) //jokoko objektuaren barruan dauden elementuak zerokin alderatuko dira
        {
            if (SceneManager.GetActiveScene().name.Equals("level2")) //bigarren maila pasatuz gero datu base lokalean idatziko du emaitza eta zerbitzariko datu basera konekzioa izanez gero, bertara lokaleko datuak pasatuko ditu.
            {
                if (kont == 0)
                {
                    puntuazioa = puntuak - float.Parse(fruits.text);
                    id = sqlConn.QueryInt("SELECT COUNT(*) FROM Partida ORDER BY COUNT(*) DESC LIMIT 1;");//datu basean dauden registro kopurua itzuliko du
                    
                    DateTime today = DateTime.Today;
                    LoadData();
                    string query = "INSERT INTO Partida(Id, UserName, Puntuazioa, Data) VALUES(" + id + ", '" + userName + "', '" + puntuazioa + "', '" + today.ToString("yyyy-MM-dd") + "');";
                    Debug.Log("query: " + query);
                    sqlConn.Query(query);
                    ExecutePostgresqlProgram executeProgram = new ExecutePostgresqlProgram();//postgresql datu basearekin konektatzeko
                    executeProgram.ExecuteProgram();

                    if (fruits != null)
                    {
                        fruits.text = "0";
                        SaveData();//frutaren kopurua ematen duen aldagaiaren datuak gordetzeko
                    }
                    kont++;
                }
                SceneManager.LoadScene(mainmenu); //main menu eszena kargatzeko
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);//hurrengo eszena kargatzeko
            }
        }
    }
    private void SaveData() //aldagai baten datuak eszena, eszena gordetzeko
    {
        PlayerPrefs.SetFloat(scorePrefsName, float.Parse(fruits.text));
    }
    private void LoadData() //aldagai baten datuak eszena, eszena kargatzeko
    {
        userName = (PlayerPrefs.GetString(userPrefsName, "")).ToString();
    }
}
