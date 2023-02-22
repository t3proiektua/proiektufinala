using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEditor;
using UnityEngine;

public class ExecutePostgresqlProgram : MonoBehaviour
{
    public void ExecuteProgram()
    {
        try
        {
            //Zerbitzaria martxan jartzeko prozesua jarriko du martxan
            ProcessStartInfo processServer = new ProcessStartInfo();
            processServer.FileName = "java";
            processServer.Arguments = "-jar " + "C:/Users/elorza.karmele/Desktop/Github/multimediaProgramazioa/exeServer/dist/exeServer.jar";
            processServer.UseShellExecute = false;

            Process process = new Process();
            process.StartInfo = processServer;
            process.Start();          
        }
        catch (Exception ex)
        {
            UnityEngine.Debug.Log("Error al ejecutar el servidor: " + ex.Message);
        }
        try
        {
            //Bezeroa martxan jartzeko prozesua jarriko du martxan
            ProcessStartInfo processClient = new ProcessStartInfo();
            processClient.FileName = "java";
            processClient.Arguments = "-jar " + "C:/Users/elorza.karmele/Desktop/Github/multimediaProgramazioa/exeClient_/dist/exeClient_.jar";
            processClient.UseShellExecute = false;

            Process process2 = new Process();
            process2.StartInfo = processClient;
            process2.Start();
            SqliteDBConect con = new SqliteDBConect(); //datu base lokalera konektatuko da
            con.Query("DELETE FROM Partida"); //Datu base lokaleko erregistro guztiak ezabatuko dira
        }
        catch (Exception ex) { UnityEngine.Debug.Log("Error al ejecutar el cliente: " + ex.Message); }
    }
}