using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkGround : MonoBehaviour
{
    public static bool isGrounded;
    //lurrean dagoen edo ez ikusiko da script honetan
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("TileMap"))
        {
            isGrounded = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("TileMap"))
        {
            isGrounded = false;
        }
    }
}
