using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class MovePlayerMobile : MonoBehaviour
{
    Boolean isLeft = false, isRight = false, isJump = false;

    public float runSpeed = 2;
    public float jumpSpeed = 4;
    public float doubleJumpSpeed = 3.5f;

    //public bool betterJump = false;
    public bool canDoubleJump = false;
    public float fallMultiplier = 0.5f;
    public float lowJumpMultiplier = 1f;
    public float speedForce = 2000;

    Rigidbody2D rb2D;

    public SpriteRenderer rbRenderer;
    public Animator rbAnimator;
    public float offsetY = 2f;
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>(); //scripta duen objektuaren rigidbody2d elementua erantsiko dio rb2D aldagaiari
    }

    // Update is called once per frame
    void Update()
    {
        if (isJump)//Erabiltzailearen teklatua detektatuko du eta gainera ikusiko du espazio tekla sakatu duen edo ez
        {
            if (checkGround.isGrounded) //lurrean dagoen edo ez ikusiko du
            {
                rbAnimator.SetBool("Jump", false);//animazioak kargatuko ditu
                rbAnimator.SetBool("Run", true);
                canDoubleJump = true;//doble saltoa egitea baimenduko du
                rb2D.velocity = new Vector2(rb2D.velocity.x, jumpSpeed);//salto egingo du
                isJump = false;
            }
            else
            {
                //salto doblea egin nahi duen edo ez detektatuko da
                if (isJump && canDoubleJump)
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
    void FixedUpdate()
    {
        //ezker eskubi mugitzeko baldintzak izango dira
        if (isLeft)
        {
            rb2D.velocity = new Vector2(-runSpeed, rb2D.velocity.y);
            rbRenderer.flipX = true;
            rbAnimator.SetBool("Run", true);

        }
        else if (isRight)
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
    }
    public void jump()
    {
        isJump = true;
    }
    public void left()
    {
        isLeft = true;
    }
    public void right()
    {
        isRight = true;
    }
    public void releasejump()
    {
        isJump = false;
    }
    public void releaseleft()
    {
        isLeft = false;
    }
    public void releaseright()
    {
        isRight = false;
    }
}
