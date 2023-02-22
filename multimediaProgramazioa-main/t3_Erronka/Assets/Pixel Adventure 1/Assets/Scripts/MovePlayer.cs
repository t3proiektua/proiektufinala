using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float runSpeed = 2;
    public float jumpSpeed = 4;
    public float doubleJumpSpeed = 3.5f;

    //public bool betterJump = false;
    public bool canDoubleJump = false;
    public float fallMultiplier = 0.5f;
    public float lowJumpMultiplier = 1f;

    Rigidbody2D rb2D;

    public SpriteRenderer rbRenderer;
    public Animator rbAnimator;
    public float offsetY = 2f;
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>(); //scripta duen objektuaren rigidbody2d elementua erantsiko dio rb2D aldagaiari
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))//Erabiltzailearen teklatua detektatuko du eta gainera ikusiko du espazio tekla sakatu duen edo ez
        {
            if (checkGround.isGrounded) //lurrean dagoen edo ez ikusiko du
            {
                rbAnimator.SetBool("Jump", false);//animazioak kargatuko ditu
                rbAnimator.SetBool("Run", true);
                canDoubleJump = true;//doble saltoa egitea baimenduko du
                rb2D.velocity = new Vector2(rb2D.velocity.x, jumpSpeed);//salto egingo du
            }
            else
            {
                //salto doblea egin nahi duen edo ez detektatuko da
                if (Input.GetKeyDown(KeyCode.Space) && canDoubleJump)
                {
                    rbAnimator.SetBool("Jump", false);
                    rbAnimator.SetBool("DoubleJump", true);
                    rb2D.velocity = new Vector2(rb2D.velocity.x, doubleJumpSpeed);
                    canDoubleJump = false;
                }
            }
            rbAnimator.SetBool("Run", false);
            
        }
        if (!checkGround.isGrounded)//lurrean dagoen edo ez ikusteko, hori jakinda, animazio bat edo beste kargatu behar duelako
        {
            rbAnimator.SetBool("Jump", true);
            rbAnimator.SetBool("Run", false);
        }
        else
        {
            rbAnimator.SetBool("Jump", false);
            rbAnimator.SetBool("DoubleJump", false);
        }
      
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //ezker eskubi mugitzeko baldintzak izango dira
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            rb2D.velocity = new Vector2(-runSpeed, rb2D.velocity.y);
            rbRenderer.flipX = true;
            rbAnimator.SetBool("Run", true);

        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            rb2D.velocity = new Vector2(runSpeed, rb2D.velocity.y);
            rbRenderer.flipX = false;
            rbAnimator.SetBool("Run", true);
        }
        else
        {
            rb2D.velocity = new Vector2(0, rb2D.velocity.y);
            rbAnimator.SetBool("Run", false);
        }
       
        //if (betterJump)
        //{
        //    if (rb2D.velocity.y < 0)
        //    {
        //        rb2D.velocity += Vector2.up * Physics2D.gravity.y * fallMultiplier * Time.deltaTime;
        //    }
        //    if (rb2D.velocity.y > 0 && Input.GetKey(KeyCode.Space))
        //    {
        //        rb2D.velocity += Vector2.up * Physics2D.gravity.y * lowJumpMultiplier * Time.deltaTime;
        //    }
        //}
        
    }
}
