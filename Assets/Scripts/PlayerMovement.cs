using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D playerRb;
    [SerializeField] float jumpForce;

    //Death Controller
    public bool isDead = false;
    Animator animator;

    //start controller
    public bool isStart;

    int angle;
    int maxAngle = 10;
    int minAngle = -60;

    //ScoreController
    [SerializeField] ScoreController scoreController;

    //AudioSource
    [SerializeField] AudioSource jump;
    [SerializeField] AudioSource hit;


    void Start()
    {
        isStart = false;
        playerRb = GetComponent<Rigidbody2D>();
        playerRb.gravityScale = 0;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!isDead)
        {
            BirdJump();
            BirdRotation();
        }
        else
        {
            animator.enabled = false;
        }

        if (isStart)
        {
            playerRb.gravityScale = 1;
        }

        if (Input.GetMouseButtonDown(0) && !isStart)
        {
            isStart = true;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Obstacle"))
        {
            if (!isDead)
            {
                hit.Play();
            }
            isDead = true;
        }
    }

    void BirdJump()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //                                                                              SFX
            jump.Play();

            playerRb.velocity = Vector2.zero;
            playerRb.velocity = new Vector2(playerRb.velocity.x, jumpForce);
        }
    }

    void BirdRotation()
    {
        if (playerRb.velocity.y > 0)
        {
            if (angle <= maxAngle)
            {
                angle += 4;
            }
        }
        else if (playerRb.velocity.y < -1.2)
        {
            if (angle > minAngle)
            {
                angle -= 1;
            }
        }

        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ScoreArea"))
        {
            scoreController.Scored();
        }
    }


}
