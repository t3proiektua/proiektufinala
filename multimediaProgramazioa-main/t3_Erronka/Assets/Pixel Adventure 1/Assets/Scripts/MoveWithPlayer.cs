using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveWithPlayer : MonoBehaviour
{
    public GameObject player; //jokalariari erreferentziaturiko jokoko objektu bat
    private void Start()
    {
        
    }
    void Update()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");// "Player" taga duen elementua aurkituko du
        }
        if (player != null)
        {
            transform.position = player.transform.position + new Vector3(1, 0, -11); // kamara jokalariarekin mugituko da
        }
    }
}
