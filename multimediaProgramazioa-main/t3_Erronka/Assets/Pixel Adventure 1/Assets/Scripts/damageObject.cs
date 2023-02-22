using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class damageObject : MonoBehaviour
{
    private int mainmenu = 1;
    public Text score;
    [SerializeField] private AudioClip damage;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))//"Player" taga duen elementuarekin kolisionatu duen edo ez detektatuko du
        {
            SoundController.Instance.PlaySound(damage);//Soinua ezarri eta martxan jarriko du
            SceneManager.LoadScene(mainmenu);//menuko eszena kargatuko du
            score.text = "0,00";
        }
    }
}
