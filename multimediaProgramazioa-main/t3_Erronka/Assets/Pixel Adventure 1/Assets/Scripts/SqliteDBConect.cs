using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;
using Mono.Data.Sqlite;
using static Unity.Burst.Intrinsics.X86.Avx;
using System;

public class SqliteDBConect : MonoBehaviour
{
    private static SqliteDBConect instance;
    private string dbName = "URI=file:datubasea_jokoa.db";
    private void Awake()
    {
        instance = this; 
    }
    // Start is called before the first frame update
    void Start()
    {
        CreateDB(); //funtzio honetan datu baseko taulak sortuko dira ez badaude sortuta
    }
    public void CreateDB()
    {
        using (var connection = new SqliteConnection(dbName))//datu basera konektatu
        {
            connection.Open();
            using (var comand = connection.CreateCommand())
            {
                comand.CommandText = "CREATE TABLE IF NOT EXISTS Partida(Id INT, UserName VARCHAR(100), Puntuazioa numeric, Data date);";
                comand.ExecuteNonQuery();//kontsulta exekutatu
                comand.CommandText = "CREATE TABLE IF NOT EXISTS Langilea(Email VARCHAR(100), Izena VARCHAR(100), UserName VARCHAR(100), JaiotzaData date, Taldea int);";
                comand.ExecuteNonQuery();
            }
            connection.Close();
        }
    }
    public DataSet Query(string q) //datu basean kontsulta egin eta dataset bat bidaliko du, datu baseko erregistroak bidaliz horrela
    {
        DataSet dataSet = new DataSet();
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();
            using (var comand = connection.CreateCommand())
            {
                comand.CommandText = q;
                using (IDataReader reader = comand.ExecuteReader())
                {
                    DataTable dataTable = new DataTable();
                    dataSet.Tables.Add(dataTable);
                    dataTable.Load(reader);
                }
            }
            connection.Close();
        }
        return dataSet;
    }
    public int QueryInt(string q)//datu basean kontsulta egin eta int bat bidaliko du, datu baseko erregistro kopurua bidaliz adibidez
    {
        int id = 0;
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();
            using (var comand = connection.CreateCommand())
            {
                comand.CommandText = q;
               id = Convert.ToInt32(comand.ExecuteScalar());
            }
            connection.Close();
        }
        return id;
    }
}
