using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpike : MonoBehaviour
{
    //script honek, "Player" taga duen elementuarekin kolisionatu duen edo ez detektatuko du eta kolisioa izatean, elementua ezabatuko da.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
    }
}
