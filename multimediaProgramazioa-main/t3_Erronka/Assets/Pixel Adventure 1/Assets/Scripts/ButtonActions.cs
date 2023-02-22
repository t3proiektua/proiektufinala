using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonActions : MonoBehaviour
{
    public void playAgain()
    {
        //Jokoaren lehen eszena kargatuko du
        SceneManager.LoadScene(2);
    }
    public void QuitGame()
    {
        //Jolasten dagoen edo ez ikusteko
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                    Application.Quit(); //Jokotik irtetzeko
        #endif
    }
}
