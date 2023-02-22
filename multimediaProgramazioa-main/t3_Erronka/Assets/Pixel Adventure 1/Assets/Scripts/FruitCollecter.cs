using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FruitCollecter : MonoBehaviour
{
    private string scorePrefsName = "Score";
    public Text fruitsCollected;
    public Text fruits;
    [SerializeField] private AudioClip collect;
    private void Awake()
    {
        LoadData();//datuak kargatuko dira
    }
    private void OnApplicationQuit()
    {
        PlayerPrefs.Save();
        PlayerPrefs.DeleteAll();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))//fruta elementuak "Player" taga duen elementuarekin talka egin al duen ikusiko du
        {
            SoundController.Instance.PlaySound(collect);//frutarekin kolisionatzean, soinua entzungo da
            GetComponent<SpriteRenderer>().enabled = false;
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            Destroy(gameObject, 0.5f);//kolisionatutako fruta ezabatuko da
        }     
    }
    private void OnDestroy()
    {
        //fruta elementua ezabatzean kontadoreari bat gehituko zaio eta datua gordeko du
        if (fruits != null)
        {
            fruits.text = (Int32.Parse(fruits.text) + 1).ToString();
        }
        SaveData();
    }
    private void SaveData()//aldagai baten datuak eszena, eszena gordetzeko
    {
        PlayerPrefs.SetFloat(scorePrefsName, float.Parse(fruitsCollected.text));
    }
    private void LoadData()//aldagai baten datuak eszena, eszena kargatzeko
    {
        fruitsCollected.text = (PlayerPrefs.GetFloat(scorePrefsName, 0)).ToString();
    }
}
